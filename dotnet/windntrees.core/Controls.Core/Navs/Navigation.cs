using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Controls.Core.Navs
{
    [DataContract]
    public class Navigation : Element
    {
        //Version 4.0 Attributes
        private String navigationContainerTemplate = "<div class=\"{0}\">{1}</div>";
        private String navigationContainerCssClass = "container-fluid";
        //Version 4.0 Attributes - End

        private String newItemTemplateLevel1;

        [DataMember]
        private List<NavigationItem> items = new List<NavigationItem>();

        public Navigation()
        {
            if (attributes == null)
            {
                attributes = new List<ItemAttribute>();
            }

            if (styles == null)
            {
                styles = new List<ItemAttribute>();
            }

            this.tag = "ul";
            this.elementType = ElementType.Navigation;
            
            initialize();
        }

        public Navigation(String baseUri) : this()
        {
            this.baseUri = baseUri;
        }

        public Navigation(String baseUri, Element parentElement) : this(baseUri)
        {
            this.parentElement = parentElement;
        }

        public Navigation(String baseUri, Element parentElement, String cssClass) : this(baseUri, parentElement)
        {
            this.cssClass = cssClass;
            this.elementType = ElementType.Navigation;
            this.version = parentElement.getVersion();
        }

        public List<NavigationItem> getItems()
        {
            return items;
        }

        public void setItems(List<NavigationItem> items)
        {
            this.items = items;
        }

        public void addComponent(NavigationItem e)
        {
            e.setParentElement(this);

            e.setEditMode(this.editMode);
            e.setLargeViewPort(this.largeViewPort);

            if (this.authenticatedUser == null)
            {
                this.authenticatedUser = parentElement.getAuthenticatedUser();
            }

            if (this.authenticatedRoles == null)
            {
                this.setAuthenticatedRoles(parentElement.getAuthenticatedRoles());
            }

            if (!e.getAuthenticationMode())
            {
                e.setAuthenticationMode(this.authenticationMode);
            }

            if (e.getBaseUri() == null)
            {
                e.setBaseUri(this.getBaseUri());
            }
            else
            {
                if (String.IsNullOrEmpty(e.getBaseUri()) || String.IsNullOrWhiteSpace(e.getBaseUri()))
                {
                    e.setBaseUri(this.getBaseUri());
                }
            }

            items.Add(e);
        }

        public override void initializeVersionAttributes(bool clearExitingAttributes = true)
        {
            if (getVersion().Equals("4.0"))
            {
                List<String> cssClasses = new List<string>(getCssClass().Split(new char[] { ' ' }));

                if (cssClasses.Contains("ml-auto")
                        || cssClasses.Contains("justify-content-start")
                        || cssClasses.Contains("justify-content-sm-start")
                        || cssClasses.Contains("justify-content-md-start")
                        || cssClasses.Contains("justify-content-lg-start")
                        || cssClasses.Contains("justify-content-xl-start"))
                {
                    elementType = ElementType.NavigationLeft;
                }

                if (cssClasses.Contains("mr-auto")
                    || cssClasses.Contains("justify-content-end")
                    || cssClasses.Contains("justify-content-sm-end")
                    || cssClasses.Contains("justify-content-md-end")
                    || cssClasses.Contains("justify-content-lg-end")
                    || cssClasses.Contains("justify-content-xl-end"))
                {
                    elementType = ElementType.NavigationRight;
                }


                navigationContainerCssClass = string.Format("{0} {1}", navigationContainerCssClass, getCssClass());
            }
            else
            {
                List<String> cssClasses = new List<string>(cssClass.Split(new char[] { ' ' }));

                this.cssClass = "nav navbar-nav";
                if (cssClasses.Contains("navbar-left"))
                {
                    this.cssClass = "nav navbar-nav navbar-left";
                    elementType = ElementType.NavigationLeft;
                }

                if (cssClasses.Contains("navbar-right"))
                {
                    this.cssClass = "nav navbar-nav navbar-right";
                    elementType = ElementType.NavigationRight;
                }

                if (!string.IsNullOrEmpty(this.cssClass))
                {
                    this.removeElementAttribute("class");
                    this.addElementAttribute(new ItemAttribute("class", this.cssClass));
                }
            }
        }

        public override void initialize()
        {
            base.initialize();

            navigationContainerTemplate = "<div class=\"{0}\">{1}</div>";
            navigationContainerCssClass = "container-fluid";

            //this.tag = "ul";
            //addElementAttribute(new ItemAttribute("", ""));

            newItemTemplateLevel1 = "<li title=\"\">&nbsp;&nbsp;</li>\n"
                + "<li class=\"input-group text-center menu-item-level-0\" title=\"manage navigations\">\n"
                + "<span class=\"input-group-btn\">\n"
                + "<a class=\"btn btn-sm btn-default\" href=\"#\" title=\"new\" style=\"\">NEW</a>\n"
                + "</span>\n"
                + "</li>";

            elementType = ElementType.Navigation;

            if (items != null)
            {
                foreach (NavigationItem menuItem in items)
                {
                    menuItem.initialize();
                }
            }
        }

        public override void synchronizeChildElements(Element parentElement)
        {
            this.setParentElement(parentElement);
            if (parentElement != null)
            {

                this.setEditMode(parentElement.getEditMode());
                this.setLargeViewPort(parentElement.getLargeViewPort());

                if (this.authenticatedUser == null)
                {
                    this.authenticatedUser = parentElement.getAuthenticatedUser();
                }

                if (this.authenticatedRoles == null)
                {
                    this.setAuthenticatedRoles(parentElement.getAuthenticatedRoles());
                }

                if (!this.authenticationMode)
                {
                    this.authenticationMode = parentElement.getAuthenticationMode();
                }

                this.setBaseUri(parentElement.getBaseUri());
            }

            if (this.items.Count == 0)
            {
                return;
            }
            else
            {
                foreach (NavigationItem item in items)
                {
                    item.synchronizeChildElements(this);
                }
            }
        }

        public override String generateHtml(String[] renderRoles)
        {
            String html = "";

            if (Utility.getLanguageDirection(localeCode) == LanguageDirection.Default
                    || Utility.getLanguageDirection(localeCode) == LanguageDirection.LeftToRight)
            {

                foreach (Element e in items)
                {
                    html += e.renderHtml(renderRoles);
                }
            }
            else if (Utility.getLanguageDirection(localeCode) == LanguageDirection.RightToLeft)
            {

                if (this.largeViewPort)
                {
                    for (int i = items.Count - 1; i >= 0; i--)
                    {
                        html += items[i].renderHtml(renderRoles);
                    }
                }
                else
                {
                    foreach (Element e in items)
                    {
                        html += e.renderHtml(renderRoles);
                    }
                }
            }
            else
            {
                foreach (Element e in items)
                {
                    html += e.renderHtml(renderRoles);
                }
            }

            if (editMode)
            {
                html += newItemTemplateLevel1;
            }

            return html;
        }

        public override String renderHtml(String[] renderRoles)
        {
            if (getVersion().Equals("4.0"))
            {
                var navigation = String.Format(template, tag, renderElementAttributes(), generateHtml(renderRoles), tag);
                var navigationContentContainer = string.Format(navigationContainerTemplate, navigationContainerCssClass, navigation);

                return navigationContentContainer;
            }
            else
            {
                return String.Format(template, tag, renderElementAttributes(), generateHtml(renderRoles), tag);
            }
        }
    }
}

