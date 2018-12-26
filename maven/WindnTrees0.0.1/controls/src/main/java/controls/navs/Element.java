/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controls.navs;

import java.util.ArrayList;
import java.util.Locale;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.context.support.ReloadableResourceBundleMessageSource;
import controls.navs.content.LocaleItemRepository;

/**
 *
 * @author shams
 */
@JsonIgnoreProperties
public class Element {

    protected static final Logger logger = LoggerFactory
            .getLogger(Element.class);

    protected String id;
    protected String text;
    protected String tag = "div";
    protected String template = "<%1$s %2$s>%3$s</%4$s>";
    protected Boolean htmlMode = false;
    protected Boolean largeViewPort = true;
    protected Boolean editMode = false;
    protected String version = "4.0";
    protected String cssClass = "";
    
    /*
    depthLevel keeps track of the menu items level during 
    rendering process.
    */
    protected static Integer depthLevel = 0;

    protected String baseUri;
    protected Element parentElement = null;
    protected Boolean parentLocaleEnabled = false;
    protected ElementType elementType = ElementType.HTML;

    protected ArrayList<ItemAttribute> attributes = new ArrayList<>();
    protected ArrayList<ItemAttribute> styles = new ArrayList<>();

    protected Boolean authenticationMode = false;

    protected String authenticatedUser = null;
    protected String authenticatedRoles[] = null;
    protected ArrayList<String> roles = new ArrayList<>();
    protected ArrayList<String> users = new ArrayList<>();

    protected Boolean localeMode = false;
    protected Boolean dataStoreMode = false;
    protected ReloadableResourceBundleMessageSource messageSource;
    protected LocaleItemRepository localeItemRepository;

    protected Locale locale;

    public Element() {
        
    }

    public Element(String tag, String text, String cssClass) {
        this.text = text;
        this.tag = tag;
        attributes.add(new ItemAttribute("class", cssClass));
    }

    public Element(String tag, String text, String cssClass, Boolean localeMode, Boolean dataStoreMode) {
        this.text = text;
        this.tag = tag;
        attributes.add(new ItemAttribute("class", cssClass));
        this.localeMode = localeMode;
        this.dataStoreMode = dataStoreMode;
    }

    public Element(String tag, String text, String cssClass, String template, Boolean localeMode, Boolean dataStoreMode) {
        this.text = text;
        this.tag = tag;
        this.template = template;
        attributes.add(new ItemAttribute("class", cssClass));
        this.localeMode = localeMode;
        this.dataStoreMode = dataStoreMode;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }
    
    public String getTag() {
        return tag;
    }

    public void setTag(String tag) {
        this.tag = tag;
    }

    public String getText() {

        try {
            if (htmlMode) {
                return text;
            } else if (dataStoreMode) {

                if (localeMode) {
                    if (parentLocaleEnabled) {
                        if (parentElement != null) {
                            if (parentElement.getLocale() != null) {
                                return Utility.getDataStoreLocaleMessage(text, parentElement.getLocale().getLanguage(), localeItemRepository);
                            } else {
                                return Utility.getDataStoreLocaleDefaultMessage(text, localeItemRepository);
                            }
                        }
                    } else {

                        if (this.getLocale() != null) {
                            return Utility.getDataStoreLocaleMessage(text, this.getLocale().getLanguage(), localeItemRepository);
                        } else {
                            return Utility.getDataStoreLocaleDefaultMessage(text, localeItemRepository);
                        }
                    }
                }

            } else if (localeMode) {

                if (parentLocaleEnabled) {
                    if (parentElement != null) {
                        if (parentElement.getMessageSource() != null && parentElement.getLocale() != null) {
                            String localeText = parentElement.getMessageSource().getMessage(text, null, parentElement.getLocale());
                            return localeText;
                        }
                    }
                } else if (messageSource != null && locale != null) {
                    String localeText = messageSource.getMessage(text, null, locale);
                    return localeText;
                }
            }
        } catch (Exception ex) {
            logger.error(ex.getMessage());
        }
        return text;
    }

    public String getLocaleMessage(String message) {

        if (localeMode) {
            if (dataStoreMode) {
                if (parentLocaleEnabled) {
                    if (parentElement != null) {
                        return Utility.getDataStoreLocaleMessage(message, parentElement.getLocale().getLanguage(), localeItemRepository);
                    }
                } else {
                    try {

                        if (this.getLocale() != null) {
                            return Utility.getDataStoreLocaleMessage(message, this.getLocale().getLanguage(), localeItemRepository);
                        } else {
                            return Utility.getDataStoreLocaleDefaultMessage(message, localeItemRepository);
                        }
                    } catch (Exception ex) {
                        logger.error(ex.getMessage());
                    }
                }
            } else {
                if (parentLocaleEnabled) {
                    if (parentElement != null) {
                        String localeText = parentElement.getMessageSource().getMessage(message, null, parentElement.getLocale());
                        return localeText;
                    }
                } else if (messageSource != null && locale != null) {
                    try {
                        String localeText = messageSource.getMessage(message, null, locale);
                        return localeText;
                    } catch (Exception ex) {
                        logger.error(ex.getMessage());
                    }
                }
            }
        }
        return message;
    }

    public void setText(String text) {
        this.text = text;
    }

    public Boolean getLocaleMode() {
        return localeMode;
    }

    public void setLocaleMode(Boolean localeMode) {
        this.localeMode = localeMode;
    }

    public Boolean getDataStoreMode() {
        return dataStoreMode;
    }

    public void setDataStoreMode(Boolean dataStoreMode) {
        this.dataStoreMode = dataStoreMode;
    }

    public String getTemplate() {
        return template;
    }

    public void setTemplate(String template) {
        this.template = template;
    }

    public Boolean getHtmlMode() {
        return htmlMode;
    }

    public void setHtmlMode(Boolean htmlMode) {
        this.htmlMode = htmlMode;
    }

    public Boolean getLargeViewPort() {
        return largeViewPort;
    }

    public void setLargeViewPort(Boolean largeViewPort) {
        this.largeViewPort = largeViewPort;
    }

    public Boolean getEditMode() {
        return editMode;
    }

    public void setEditMode(Boolean editMode) {
        this.editMode = editMode;
    }
    
    public String getVersion() {
        return version;
    }

    public void setVersion(String version) {
        this.version = version;
    }

    public String getCssClass() {
        return cssClass;
    }

    public void setCssClass(String cssClass) {
        this.cssClass = cssClass;
    }

    public static Integer getDepthLevel() {
        return depthLevel;
    }

    public static void setDepthLevel(Integer depthLevel) {
        Element.depthLevel = depthLevel;
    }
    
    public String getBaseUri() {
        if (baseUri == null) {
            return "";
        }
        return baseUri;
    }

    public void setBaseUri(String baseUri) {
        this.baseUri = baseUri;
    }

    public Boolean getAuthenticationMode() {
        return authenticationMode;
    }

    public void setAuthenticationMode(Boolean authenticationMode) {
        this.authenticationMode = authenticationMode;
    }

    public Element getParentElement() {
        return parentElement;
    }

    public void setParentElement(Element parentElement) {
        this.parentElement = parentElement;

        if (this.messageSource == null) {
            this.messageSource = parentElement.messageSource;
        }

        if (this.locale == null) {
            this.locale = parentElement.locale;
        }

        if (this.localeMode == null) {
            this.localeMode = parentElement.localeMode;
        }

        try {
            if (this.parentElement.getClass().equals(Class.forName("controls.navs.Menu"))
                    || this.parentElement.getClass().equals(Class.forName("controls.navs.MenuBar"))) {
            }
        } catch (Exception ex) {
            logger.error(ex.getMessage());
        }
    }

    public Boolean getParentLocaleEnabled() {
        return parentLocaleEnabled;
    }

    public void setParentLocaleEnabled(Boolean parentLocaleEnabled) {
        this.parentLocaleEnabled = parentLocaleEnabled;
    }

    public ElementType getElementType() {
        return elementType;
    }

    public void setElementType(ElementType elementType) {
        this.elementType = elementType;
    }

    public void addElementAttribute(ItemAttribute itemAttribute) {
        attributes.add(itemAttribute);
    }

    public ArrayList<ItemAttribute> getAttributes() {
        return attributes;
    }

    public void setAttributes(ArrayList<ItemAttribute> attributes) {
        this.attributes = attributes;
    }

    public ArrayList<ItemAttribute> getStyles() {
        return styles;
    }

    public void setStyles(ArrayList<ItemAttribute> styles) {
        this.styles = styles;
    }

    public String getAuthenticatedUser() {
        return authenticatedUser;
    }

    public void setAuthenticatedUser(String authenticatedUser) {
        this.authenticatedUser = authenticatedUser;
    }

    public String[] getAuthenticatedRoles() {
        return authenticatedRoles;
    }

    public void setAuthenticatedRoles(String[] authenticatedRoles) {
        this.authenticatedRoles = authenticatedRoles;
    }

    public ArrayList<String> getUsers() {
        return users;
    }

    public void setUsers(ArrayList<String> users) {
        this.users = users;
    }

    public void setUsersViaString(String usersAsString) {
        if (usersAsString != null) {
            if (usersAsString.trim().isEmpty()) {
                this.users = null;
            } else {
                String[] usersArray = usersAsString.split(",");
                for (String user : usersArray) {
                    this.users.add(user);
                }
            }
        }
    }

    public ArrayList<String> getRoles() {
        return roles;
    }

    public void setRoles(ArrayList<String> roles) {
        this.roles = roles;
    }

    public void setRolesViaString(String rolesAsString) {
        if (rolesAsString != null) {
            if (rolesAsString.trim().isEmpty()) {
                this.roles = null;
            } else {
                String[] rolesArray = rolesAsString.split(",");
                for (String role : rolesArray) {
                    this.roles.add(role);
                }
            }
        }
    }

    public Boolean isAuthorized(String[] renderingRoles) {

        try {
            //if authenticated users are not specified for current node, then traverse throught to parent nodes to 
            //find the user.
            Element currentElement = this;
            //traverse through elements
            while (currentElement != null) {
                //Users Auhtorization
                if (!currentElement.users.isEmpty()) {

                    for (String authorizedUser : currentElement.users) {

                        if (authenticatedUser.equals(authorizedUser)) {

                            logger.trace(String.format("%1$s is authorized for inherited user %2$s", this.text, authenticatedUser));
                            return true;
                        }
                    }
                    //users access control list was provided for the current node and user didn't get authorized
                    //then it should return
                    return false;
                }

                //Roles Authorization
                if (!currentElement.roles.isEmpty()) {
                    //Traverse through roles for the current element node and authorize accordingly.
                    for (String role : currentElement.roles) {
                        if (role.equals("anonymous")) {
                            //Allow anonymous role.
                            logger.trace(String.format("%1$s is authorized for inherited role %2$s", this.text, "anonymous"));

                            if (renderingRoles == null) {
                                return true;
                            } else {
                                //applying rendering
                                for (String renderingRole : renderingRoles) {
                                    if (renderingRole.equals("anonymous")) {
                                        logger.trace(String.format("%1$s rendered for inherited role %2$s", this.text, renderingRole));
                                        return true;
                                    }
                                }
                            }
                        } else if (role.equals("signin")) {

                            if (authenticatedUser == null) {

                                logger.trace(String.format("%1$s is attempted true for role %2$s", this.text, "signin"));
                                return true;
                            } else if (authenticatedUser.isEmpty()) {

                                logger.trace(String.format("%1$s is attempted true for role %2$s", this.text, "signin"));
                                return true;
                            } else {

                                logger.trace(String.format("%1$s is attempted false for role %2$s", this.text, "signin"));
                                return false;
                            }
                        }

                        //for current element if user is not authorized
                        if (authenticatedRoles == null) {
                            return false;
                        } else {
                            for (String authenticatedRole : authenticatedRoles) {
                                if (authenticatedRole.equals(role)) {
                                    logger.trace(String.format("%1$s is authorized for role %2$s", this.text, authenticatedRole));

                                    if (renderingRoles == null) {
                                        return true;
                                    } else {
                                        //applying rendering
                                        for (String renderingRole : renderingRoles) {
                                            if (renderingRole.equals(authenticatedRole)) {
                                                logger.trace(String.format("%1$s rendered for role %2$s", this.text, authenticatedRole));
                                                return true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (authenticatedRoles != null) {
                        //if user is not authorized against a authorized role within authorized list
                        //in current node that has access control list then it should return from hierarhical evaluation
                        //immediately because in hierarhical evaluation immediate upper node with access control list is the
                        //right list for evaluation and it should not traverese to the top in the hierarchy.
                        return false;
                    }
                }
                currentElement = currentElement.parentElement;
            }
        } catch (Exception ex) {
            logger.trace(ex.getMessage());
        }

        logger.trace(String.format("%1$s authorization failed for user %2$s and roles %3$s", this.text, authenticatedUser, roles.toString()));
        return false;
    }
    
    public Boolean isAuthorized_(String[] renderingRoles) {

        Boolean signInRoleAttempted = false;
        Boolean signInRoleAttemptResult = false;
        
        if (authenticatedUser == null) {
            logger.info("User is not authenticated.");
        } else {

            if (authenticatedUser.trim().isEmpty()) {
                logger.info("User is not authenticated.");
            } else {
                if (this.users.isEmpty()) {

                    try {
                        Element currentElement = this.parentElement;
                        while (currentElement != null) {
                            for (String authorizedUser : currentElement.users) {
                                if (authenticatedUser.equals(authorizedUser)) {
                                    logger.info(String.format("%1$s authorized for user %2$s.", this.text, authenticatedUser));
                                    return true;
                                }
                            }
                            currentElement = currentElement.parentElement;
                        }
                    } catch (Exception ex) {
                        logger.error(ex.getMessage());
                    }

                } else {
                    for (String authorizedUser : users) {
                        if (authenticatedUser.equals(authorizedUser)) {
                            logger.info(String.format("%1$s authorized for user %2$s.", this.text, authenticatedUser));
                            return true;
                        }
                    }
                }
            }
        }

        if (this.roles.isEmpty()) {
            try {

                Element currentElement = this;
                while (currentElement != null) {

                    /*Allow anonymous role.*/
                    for (String role : currentElement.getRoles()) {
                        if (role.equals("anonymous")) {
                            logger.info(String.format("%1$s authorized for inherited role %2$s.", this.text, "anonymous"));

                            if (renderingRoles == null) {
                                return true;
                            } else {
                                //applying rendering
                                for (String renderingRole : renderingRoles) {
                                    if (renderingRole.equals("anonymous")) {
                                        logger.info(String.format("%1$s rendered for inherited role %2$s.", this.text, renderingRole));
                                        return true;
                                    }
                                }
                            }
                        } else if (role.equals("signin")) {
                            signInRoleAttempted = true;
                            if (authenticatedUser == null) {
                                logger.info(String.format("%1$s authorized for role %2$s.", this.text, "signin"));
                                signInRoleAttemptResult = true;
                                //return true;
                            } else {

                                if (authenticatedUser.trim().isEmpty()) {
                                    logger.info(String.format("%1$s authorized for role %2$s.", this.text, "signin"));
                                    signInRoleAttemptResult = true;
                                    //return true;
                                }

                                logger.info(String.format("%1$s denied for role %2$s.", this.text, "signin"));
                                signInRoleAttemptResult = false;
                                //return false;
                            }
                        }
                    }

                    if (authenticatedRoles != null) {
                        for (String authenticatedRole : authenticatedRoles) {
                            if (!authenticatedRole.isEmpty()) {
                                for (String authorizedRole : currentElement.getRoles()) {
                                    if (authenticatedRole.equals(authorizedRole)) {
                                        logger.info(String.format("%1$s authorized for inherited role %2$s.", this.text, authenticatedRole));

                                        if (renderingRoles == null) {
                                            return true;
                                        } else {
                                            //applying rendering
                                            for (String renderingRole : renderingRoles) {
                                                if (renderingRole.equals(authenticatedRole)) {
                                                    logger.info(String.format("%1$s rendered for inherited role %2$s.", this.text, authenticatedRole));
                                                    return true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    currentElement = currentElement.parentElement;
                }
            } catch (Exception ex) {
                logger.error(ex.getMessage());
            }
        } else {

            /*Allow anonymous role.*/
            for (String role : roles) {
                if (role.equals("anonymous")) {
                    logger.info(String.format("%1$s authorized for role %2$s.", this.text, "anonymous"));

                    if (renderingRoles == null) {
                        return true;
                    } else {

                        //applying rendering
                        for (String renderingRole : renderingRoles) {
                            if (renderingRole.equals("anonymous")) {
                                logger.info(String.format("%1$s rendered for inherited role %2$s.", this.text, renderingRole));
                                return true;
                            }
                        }
                    }
                } else if (role.equals("signin")) {
                    signInRoleAttempted = true;
                    if (authenticatedUser == null) {
                        logger.info(String.format("%1$s authorized for role %2$s.", this.text, "signin"));
                        signInRoleAttemptResult = true;
                        //return true;
                    } else {

                        if (authenticatedUser.trim().isEmpty()) {
                            logger.info(String.format("%1$s authorized for role %2$s.", this.text, "signin"));
                            signInRoleAttemptResult = true;
                            //return true;
                        }

                        logger.info(String.format("%1$s denied for role %2$s.", this.text, "signin"));
                        signInRoleAttemptResult = false;
                        //return false;
                    }
                }
            }

            /*Otherwise check for authenticated roles. */
            if (authenticatedRoles != null) {
                for (String authenticatedRole : authenticatedRoles) {
                    if (!authenticatedRole.isEmpty()) {
                        for (String authorizedRole : roles) {
                            if (authenticatedRole.equals(authorizedRole)) {
                                logger.info(String.format("%1$s authorized for role %2$s.", this.text, authenticatedRole));

                                if (renderingRoles == null) {
                                    return true;
                                } else {
                                    //applying rendering
                                    for (String renderingRole : renderingRoles) {
                                        if (renderingRole.equals(authenticatedRole)) {
                                            logger.info(String.format("%1$s rendered for inherited role %2$s.", this.text, authenticatedRole));
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        
        if (signInRoleAttempted) {
            return signInRoleAttemptResult;
        }

        logger.info(String.format("%1$s authorization failed for user %2$s and roles %3$s.", this.text, authenticatedUser, roles.toString()));
        return false;
    }

    public Boolean isMenuType() {
        if (elementType == ElementType.Menu
                || elementType == ElementType.MenuLeft
                || elementType == ElementType.MenuRight) {
            return true;
        }
        return false;
    }

    public ReloadableResourceBundleMessageSource getMessageSource() {
        return messageSource;
    }

    public void setMessageSource(ReloadableResourceBundleMessageSource messageSource) {
        this.messageSource = messageSource;
    }

    public LocaleItemRepository getLocaleItemRepository() {
        return localeItemRepository;
    }

    public void setLocaleItemRepository(LocaleItemRepository localeItemRepository) {
        this.localeItemRepository = localeItemRepository;
    }

    public Locale getLocale() {
        return locale;
    }

    public void setLocale(Locale locale) {
        this.locale = locale;
    }

    public void setBaseUriAndParentElement(String baseUri, Element parentElement) {
        this.baseUri = baseUri;
        this.parentElement = parentElement;
        if (parentElement != null) {
            
            this.editMode = parentElement.editMode;
            this.messageSource = parentElement.messageSource;
            this.localeItemRepository = parentElement.localeItemRepository;

            this.locale = parentElement.locale;
            this.localeMode = parentElement.localeMode;
            this.dataStoreMode = parentElement.dataStoreMode;
            this.largeViewPort = parentElement.largeViewPort;

            this.authenticatedUser = parentElement.authenticatedUser;
            this.setAuthenticatedRoles(parentElement.getAuthenticatedRoles());

            if (!this.authenticationMode) {
                this.authenticationMode = parentElement.authenticationMode;
            }
        }
        synchronizeChildElements(this);
    }

    public void synchronizeChildElements(Element parentElement) {
    }

    public String generateHtml(String[] renderRoles) {
        return "";
    }

    public String renderHtml(String[] renderRoles) {

        if (authenticationMode) {
            if (isAuthorized(renderRoles)) {
                return String.format(template, tag, renderElementAttributes(), getText(), tag);
            }
            return "";
        } else {
            return String.format(template, tag, renderElementAttributes(), getText(), tag);
        }
    }

    public String renderElementAttributes() {
        if (attributes != null) {
            String attributesText = "";
            if (styles != null) {
                String stylesText = renderStyleAttributes();
                if (stylesText.trim().length() > 0) {
                    attributes.add(new ItemAttribute("style", stylesText));
                }
            }

            for (ItemAttribute attribute : attributes) {

                String localeValue = attribute.getValue();
                if (attribute.getName().equalsIgnoreCase("title")) {
                    localeValue = getLocaleMessage(localeValue);
                }

                attributesText += String.format("%1$s = \"%2$s\" ", attribute.getName(), localeValue);
            }
            attributesText = attributesText.trim();
            return attributesText;
        }
        return "";
    }

    public String renderStyleAttributes() {
        if (styles != null) {
            String attributesText = "";
            for (ItemAttribute attribute : styles) {

                attributesText += String.format("%1$s: %2$s; ", attribute.getName(), attribute.getValue());
            }
            attributesText = attributesText.trim();
            return attributesText;
        }
        return "";
    }
}
