using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Abstraction.Notifiers;

namespace Controls.Navs
{
    [DataContract]
    public class Element : Notifier
    {
        [DataMember]
        protected String id;

        [DataMember]
        protected String text;

        [DataMember]
        protected String tag;

        [DataMember]
        protected String template;

        [DataMember]
        protected String version = "4.0";

        [DataMember]
        protected String cssClass = "";

        protected Boolean htmlMode;
        protected Boolean largeViewPort;
        protected Boolean editMode;

        

        /*
        depthLevel keeps track of the menu items level during 
        rendering process.
        */
        protected static int depthLevel = 0;

        protected String baseUri;

        protected Element parentElement = null;
        //protected Boolean parentLocaleEnabled = false;

        protected ElementType elementType = ElementType.HTML;

        protected List<ItemAttribute> versionAttributes = new List<ItemAttribute>();

        [DataMember]
        protected List<ItemAttribute> attributes = new List<ItemAttribute>();

        [DataMember]
        protected List<ItemAttribute> styles = new List<ItemAttribute>();

        [DataMember]
        protected Boolean authenticationMode = false;

        //List of authorized users constructed from deserialized users or constructor initialized.
        [DataMember]
        protected List<String> users = new List<String>();

        //List of authorized roles constructed from deserialized roles or constructor initialized.
        [DataMember]
        protected List<String> roles = new List<String>();
        
        //users that are required to be authenticated against navigation
        protected String authenticatedUser = null;

        //roles that are required to be authenticated against navigation
        protected String[] authenticatedRoles = null;

        //protected Boolean localeMode = false;
        //protected Boolean dataStoreMode = false;
        //protected ReloadableResourceBundleMessageSource messageSource;
        //protected LocaleItemRepository localeItemRepository;

        protected String localeCode;

        public Element()
        {
            initialize();
        }

        public Element(String tag, String text, String cssClass)
        {
            this.text = text;
            this.tag = tag;

            if (attributes == null)
            {
                attributes = new List<ItemAttribute>();
            }

            attributes.Add(new ItemAttribute("class", cssClass));
        }

        public Element(String tag, String text, String cssClass, String template)
        {
            this.text = text;
            this.tag = tag;
            this.template = template;

            if (attributes == null)
            {
                attributes = new List<ItemAttribute>();
            }

            attributes.Add(new ItemAttribute("class", cssClass));
        }

        public String getId()
        {
            return id;
        }

        public void setId(String id)
        {
            this.id = id;
        }

        public String getTag()
        {
            return tag;
        }

        public void setTag(String tag)
        {
            this.tag = tag;
        }

        private String getLocaleText(string localeText)
        {
            try
            {
                //$resources: WindTrees.Navigation, AHomeT
                if (localeText.StartsWith("$resources:"))
                {
                    localeText = localeText.Replace("$resources:", "");

                    string[] textTokens = localeText.Split(new char[] { ',' });

                    if (textTokens.Length == 2)
                    {
                        //Qualified or full class name like WindTrees.Navigation
                        string classFullname = textTokens[0].Trim();

                        //Class member (field) name like AHomeT
                        string memberName = textTokens[1].Trim();

                        //WindTrees.Navigation
                        string[] classFullnameTokens = classFullname.Split(new char[] { '.' });

                        //WindTrees
                        string assemblyName = classFullnameTokens[0];

                        //Navigation
                        string className = classFullnameTokens[classFullnameTokens.Length - 1];

                        Type[] exportedTypes = System.Reflection.Assembly.Load(assemblyName).GetExportedTypes();

                        if (exportedTypes != null)
                        {
                            //find the required class in the exported types of the loaded assembly.
                            foreach (Type classType in exportedTypes)
                            {
                                if (classType.FullName.Equals(classFullname, StringComparison.OrdinalIgnoreCase))
                                {
                                    System.Reflection.MethodInfo methodInfo = classType.GetMethod(string.Format("get_{0}", memberName));

                                    if (methodInfo != null)
                                    {
                                        //considering static method that returns text value.
                                        return methodInfo.Invoke(null, null).ToString();
                                    }
                                }
                            }
                        }
                    }
                }

                return localeText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String getText()
        {
            try
            {
                if (htmlMode)
                {
                    //HTML mode

                    return text;

                }
                else
                {

                    //$resources: WindTrees.Navigation, AHomeT
                    return getLocaleText(text);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setText(String text)
        {
            this.text = text;
        }

        public String getTemplate()
        {
            return template;
        }

        public void setTemplate(String template)
        {
            this.template = template;
        }

        public Boolean getHtmlMode()
        {
            return htmlMode;
        }

        public void setHtmlMode(Boolean htmlMode)
        {
            this.htmlMode = htmlMode;
        }

        public Boolean getLargeViewPort()
        {
            return largeViewPort;
        }

        public void setLargeViewPort(Boolean largeViewPort)
        {
            this.largeViewPort = largeViewPort;
        }

        public Boolean getEditMode()
        {
            return editMode;
        }

        public void setEditMode(Boolean editMode)
        {
            this.editMode = editMode;
        }

        public String getVersion()
        {
            return this.version;
        }

        public void setVersion(String value)
        {
            this.version = value;
            initializeVersionAttributes();
        }

        public String getCssClass()
        {
            return this.cssClass;
        }

        public void setCssClass(String value)
        {
            this.cssClass = value;
        }

        public static int getDepthLevel()
        {
            return depthLevel;
        }

        public static void setDepthLevel(int depthLevel)
        {
            Element.depthLevel = depthLevel;
        }

        public String getBaseUri()
        {
            if (baseUri == null)
            {
                return "";
            }
            return baseUri;
        }

        public void setBaseUri(String baseUri)
        {
            this.baseUri = baseUri;
        }

        public Boolean getAuthenticationMode()
        {
            return authenticationMode;
        }

        public void setAuthenticationMode(Boolean authenticationMode)
        {
            this.authenticationMode = authenticationMode;
        }

        public Element getParentElement()
        {
            return parentElement;
        }

        public void setParentElement(Element parentElement)
        {
            this.parentElement = parentElement;
        }

        public ElementType getElementType()
        {
            return elementType;
        }

        public void setElementType(ElementType elementType)
        {
            this.elementType = elementType;
        }

        public void clearVersionAttributes()
        {
            this.versionAttributes.Clear();
        }

        public void addVersionAttribute(ItemAttribute value)
        {
            this.versionAttributes.Add(value);
        }

        public ItemAttribute getVersionAttribute(String name)
        {
            return this.versionAttributes.Find(l => l.getName() == name);
        }

        public void removeVersionAttribute(String name)
        {
            this.versionAttributes.Remove(this.versionAttributes.Find(l => l.getName() == name));
        }

        public void addElementAttribute(ItemAttribute itemAttribute)
        {
            if (this.attributes == null)
            {
                this.attributes = new List<ItemAttribute>();
            }

            attributes.Add(itemAttribute);
        }

        public void removeElementAttribute(String name)
        {
            this.attributes.Remove(this.attributes.Find(l => l.getName() == name));
        }

        public List<ItemAttribute> getAttributes()
        {
            return attributes;
        }

        public void setAttributes(List<ItemAttribute> attributes)
        {
            this.attributes = attributes;
        }

        public void addStyleAttribute(ItemAttribute itemAttribute)
        {
            if (this.styles == null)
            {
                this.styles = new List<ItemAttribute>();
            }

            styles.Add(itemAttribute);
        }

        public void removeStyleAttribute(String name)
        {
            this.styles.Remove(this.styles.Find(l => l.getName() == name));
        }

        public List<ItemAttribute> getStyles()
        {
            return styles;
        }

        public void setStyles(List<ItemAttribute> styles)
        {
            this.styles = styles;
        }

        public String getAuthenticatedUser()
        {
            return authenticatedUser;
        }

        public void setAuthenticatedUser(String authenticatedUser)
        {
            this.authenticatedUser = authenticatedUser;
        }

        public String[] getAuthenticatedRoles()
        {
            return authenticatedRoles;
        }

        public void setAuthenticatedRoles(String[] authenticatedRoles)
        {
            this.authenticatedRoles = authenticatedRoles;
        }

        public List<String> getUsers()
        {
            return users;
        }

        public void setUsers(List<String> users)
        {
            this.users = users;
        }

        public void setUsersViaString(String usersAsString)
        {
            if (usersAsString != null)
            {
                if (String.IsNullOrEmpty(usersAsString) || String.IsNullOrWhiteSpace(usersAsString))
                {
                    this.users = null;
                }
                else
                {
                    String[] usersArray = usersAsString.Split(new char[] { ',' });
                    foreach (String user in usersArray)
                    {
                        this.users.Add(user);
                    }
                }
            }
        }

        public List<String> getRoles()
        {
            return roles;
        }

        public void setRoles(List<String> roles)
        {
            this.roles = roles;
        }

        public String getRolesAsString()
        {
            var result = "";
            if (this.roles != null)
            {
                foreach (var role in this.roles)
                {
                    result += string.Format("{0}, {1}", result, role);
                }
            }
            return result;
        }

        public void setRolesViaString(String rolesAsString)
        {
            if (rolesAsString != null)
            {
                if (String.IsNullOrEmpty(rolesAsString) || String.IsNullOrWhiteSpace(rolesAsString))
                {
                    this.roles = null;
                }
                else
                {
                    String[] rolesArray = rolesAsString.Split(new char[] { ',' });
                    foreach (String role in rolesArray)
                    {
                        this.roles.Add(role);
                    }
                }
            }
        }

        public void setLocaleCode(String localeCode)
        {
            this.localeCode = localeCode;
        }

        public String getLocaleCode()
        {
            return this.localeCode;
        }

        public Boolean isAuthorized(String[] renderingRoles)
        {

            if (String.IsNullOrEmpty(authenticatedUser) || String.IsNullOrWhiteSpace(authenticatedUser))
            {
                notify("User is not authenticated.");
            }

            try
            {
                //if authenticated users are not specified for current node, then traverse throught to parent nodes to 
                //find the user.

                Element currentElement = this;
                //traverse through elements
                while (currentElement != null)
                {
                    //Users Auhtorization
                    if (currentElement.users != null)
                    {
                        if (currentElement.users.Count > 0)
                        {
                            foreach (String authorizedUser in currentElement.users)
                            {
                                if (authenticatedUser.Equals(authorizedUser))
                                {
                                    notify(String.Format("{0} is authorized for inherited user {1}", this.text, authenticatedUser));
                                    return true;
                                }
                            }

                            //users access control list was provided for the current node and user didn't get authorized
                            //then it should return
                            return false;
                        }
                    }

                    //Roles Authorization
                    if (currentElement.roles != null)
                    {
                        if(currentElement.roles.Count > 0)
                        {
                            //Traverse through roles for the current element node and authorize accordingly.
                            foreach (String role in currentElement.roles)
                            {
                                if (role.Equals("anonymous"))
                                {
                                    //Allow anonymous role.
                                    notify(String.Format("{0} is authorized for inherited role {1}", this.text, "anonymous"));

                                    if (renderingRoles == null)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        //applying rendering
                                        foreach (String renderingRole in renderingRoles)
                                        {
                                            if (renderingRole.Equals("anonymous"))
                                            {
                                                notify(String.Format("{0} rendered for inherited role {1}", this.text, renderingRole));
                                                return true;
                                            }
                                        }
                                    }
                                }
                                else if (role.Equals("signin"))
                                {
                                    if (String.IsNullOrEmpty(authenticatedUser) || String.IsNullOrWhiteSpace(authenticatedUser))
                                    {
                                        notify(String.Format("{0} is attempted true for role {1}", this.text, "signin"));
                                        return true;
                                    }
                                    else
                                    {
                                        notify(String.Format("{0} is attempted false for role {1}", this.text, "signin"));
                                        return false;
                                    }
                                }

                                //for current element if user is not authorized
                                if (authenticatedRoles == null)
                                {
                                    return false;
                                }
                                else
                                {
                                    foreach (String authenticatedRole in authenticatedRoles)
                                    {
                                        if (authenticatedRole.Equals(role))
                                        {
                                            notify(String.Format("{0} is authorized for role {1}", this.text, authenticatedRole));

                                            if (renderingRoles == null)
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                //applying rendering
                                                foreach (String renderingRole in renderingRoles)
                                                {
                                                    if (renderingRole.Equals(authenticatedRole))
                                                    {
                                                        notify(String.Format("{0} rendered for role {1}", this.text, authenticatedRole));
                                                        return true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }   
                            }

                            if (authenticatedRoles != null)
                            {
                                //if user is not authorized against a authorized role within authorized list
                                //in current node that has access control list then it should return from hierarhical evaluation
                                //immediately because in hierarhical evaluation immediate upper node with access control list is the
                                //right list for evaluation and it should not traverese to the top in the hierarchy.
                                return false;
                            }
                        }
                    }
                    currentElement = currentElement.parentElement;
                }
            }
            catch (Exception ex)
            {
                notify(ex.Message);
            }

            notify(String.Format("{0} authorization failed for user {1} and roles {2}", this.text, authenticatedUser, getRolesAsString()));
            return false;
        }

        public Boolean isNavigationType()
        {
            if (elementType == ElementType.Navigation
                    || elementType == ElementType.NavigationLeft
                    || elementType == ElementType.NavigationRight)
            {
                return true;
            }
            return false;
        }

        public void setBaseUriAndParentElement(String baseUri, Element parentElement)
        {
            this.baseUri = baseUri;
            this.parentElement = parentElement;
            if (parentElement != null)
            {

                this.editMode = parentElement.editMode;
                this.largeViewPort = parentElement.largeViewPort;

                this.authenticatedUser = parentElement.authenticatedUser;
                this.setAuthenticatedRoles(parentElement.getAuthenticatedRoles());

                if (!this.authenticationMode)
                {
                    this.authenticationMode = parentElement.authenticationMode;
                }
            }

            synchronizeChildElements(this);
        }

        public virtual void initialize()
        {
            initializeVersionAttributes();

            tag = tag == null ? "div" : tag;
            template = template == null ? "<{0} {1}>{2}</{3}>" : template;

            htmlMode = false;
            largeViewPort = true;
            editMode = false;
            depthLevel = 0;
            elementType = ElementType.HTML;
        }

        public virtual void initializeVersionAttributes(bool clearExitingAttributes = true)
        {

        }

        public virtual void synchronizeChildElements(Element parentElement)
        {

        }

        public virtual String generateHtml(String[] renderRoles)
        {
            return "";
        }

        public virtual String renderHtml(String[] renderRoles)
        {
            if (authenticationMode)
            {
                if (isAuthorized(renderRoles))
                {
                    return String.Format(template, tag, renderElementAttributes(), getText(), tag);
                }
                return "";
            }
            else
            {
                return String.Format(template, tag, renderElementAttributes(), getText(), tag);
            }
        }

        public String renderElementAttributes()
        {
            if (attributes == null)
            {
                attributes = new List<ItemAttribute>();
            }

            String attributesText = "";
            if (styles != null)
            {
                String stylesText = renderStyleAttributes();
                if (!(String.IsNullOrEmpty(stylesText) || String.IsNullOrWhiteSpace(stylesText)))
                {
                    attributes.Add(new ItemAttribute("style", stylesText));
                }
            }

            foreach (ItemAttribute attribute in attributes)
            {
                if (attribute.getName().Equals("title", StringComparison.OrdinalIgnoreCase))
                {
                    attributesText += String.Format("{0} = \"{1}\" ", attribute.getName(), getLocaleText(attribute.getValue()));
                }
                else
                {
                    attributesText += String.Format("{0} = \"{1}\" ", attribute.getName(), attribute.getValue());
                }
            }
            attributesText = attributesText.Trim();

            return attributesText;
        }

        public String renderStyleAttributes()
        {
            if (styles != null)
            {
                String attributesText = "";
                foreach (ItemAttribute attribute in styles)
                {
                    attributesText += String.Format("{0}: {1}; ", attribute.getName(), attribute.getValue());
                }
                attributesText = attributesText.Trim();

                return attributesText;
            }
            return "";
        }
    }
}
