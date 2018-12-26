using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Controls.Navs
{
    [DataContract]
    public class NavigationItem : Element
    {
        [DataMember]
        private String linkUrl;

        [DataMember]
        private Boolean noBaseUri;

        [DataMember]
        private String navigationIcon;

        [DataMember]
        private Boolean separator = false;

        private int sepratorCount = 0;

        [DataMember]
        private List<ItemAttribute> linkAttributes = new List<ItemAttribute>();

        [DataMember]
        private List<ItemAttribute> linkStyles = new List<ItemAttribute>();

        [DataMember]
        private List<NavigationItem> items = new List<NavigationItem>();

        /*
            Navigation Display Templates
         */

        [DataMember]
        private String itemTemplate;

        [DataMember]
        private String newItemTemplateLevel1;

        [DataMember]
        private String editItemTemplateLevel1;

        [DataMember]
        private String newItemTemplateLevel2;

        [DataMember]
        private String editItemTemplateLevel2;

        [DataMember]
        private String itemSepratorTemplate;

        [DataMember]
        private String linkTemplate;

        [DataMember]
        private String linkNavigationTemplate;

        [DataMember]
        private String editLinkNavigationTemplate;

        [DataMember]
        private String subNavigationTemplate;

        [DataMember]
        private String subNavigationTemplateLtr;

        [DataMember]
        private String subNavigationTemplateRtl;

        public override void initialize()
        {
            base.initialize();
            elementType = ElementType.NavigationItem;

            sepratorCount = 0;

            if (navigationIcon == null)
            {
                navigationIcon = "caret";
            }

            if (itemTemplate == null)
            {
                itemTemplate = "<li {0}>{1}</li>\n";
            }

            if (newItemTemplateLevel1 == null)
            {
                newItemTemplateLevel1 = "<li title=\"\">&nbsp;&nbsp;</li>\n"
                + "<li class=\"input-group text-center menu-item-level-0\" title=\"manage navigations\">\n"
                + "<span class=\"input-group-btn\">\n"
                + "<a class=\"btn btn-sm btn-default\" href=\"#\" title=\"new\" style=\"\">NEW</a>\n"
                + "</span>\n"
                + "</li>";
            }

            if (editItemTemplateLevel1 == null)
            {
                editItemTemplateLevel1 = "<li {0}>{1}</li>\n"
                + "<li class=\"input-group text-center menu-item-level-0\" title=\"\">\n"
                + "<span class=\"input-group-btn\">\n"
                + "<a class=\"btn btn-sm btn-default\" href=\"#\" title=\"edit\" style=\"\">e</a>\n"
                + "<a class=\"btn btn-sm btn-default\" href=\"#\" title=\"remove\">r</a>\n"
                + "<a class=\"btn btn-sm btn-default\" href=\"#\" title=\"new\">n</a>\n"
                + "</span>\n"
                + "</li>";
            }

            if (newItemTemplateLevel2 == null)
            {
                newItemTemplateLevel2 = "<li {0} class=\"input-group text-center\" title=\"\">\n"
                + "<span class=\"input-group-btn\">\n"
                + "<a class=\"btn btn-sm btn-default\" href=\"#\" title=\"new\">NEW</a>\n"
                + "</span>\n"
                + "</li>";
            }

            if (editItemTemplateLevel2 == null)
            {
                editItemTemplateLevel2 = "<li {0}>{1}"
                + "<span class=\"input-group-btn\">\n"
                + "<a class=\"btn btn-sm btn-default\" href=\"#\" title=\"edit\" style=\"\">e</a>\n"
                + "<a class=\"btn btn-sm btn-default\" href=\"#\" title=\"remove\">r</a>\n"
                + "</span>"
                + "</li>\n";
            }

            if (itemSepratorTemplate == null)
            {
                itemSepratorTemplate = "<li {0} role=\"separator\"></li>";
            }

            if (linkTemplate == null)
            {
                linkTemplate = "<a {0} href=\"{1}\">{2}</a>";
            }

            if (linkNavigationTemplate == null)
            {
                linkNavigationTemplate = "<a {0} href=\"#\" class=\"dropdown-toggle\" "
                + "data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" "
                + "aria-expanded=\"false\">{1} "
                + "<span class=\"{2}\"></span>"
                + "</a>";

                //linkNavigationTemplate = "<a {0} href=\"#\" class=\"collapse-toggle\" data-toggle=\"collapse\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">{1} <span class=\"{2}\"></span></a>";
            }

            if (editLinkNavigationTemplate == null)
            {
                editLinkNavigationTemplate = "<li class=\"input-group text-center menu-item-level-0\" title=\"\">\n"
                + "<span class=\"input-group-btn\">\n"
                + "<a class=\"btn btn-sm btn-default\" href=\"#\" title=\"edit\" style=\"\">e</a>\n"
                + "<a class=\"btn btn-sm btn-default\" href=\"#\" title=\"remove\">r</a>\n"
                + "</span>\n"
                + "</li>";
            }

            if (subNavigationTemplate == null)
            {
                subNavigationTemplate = "<ul class=\"dropdown-menu\">{0}</ul>\n";
            }

            if (subNavigationTemplateLtr == null)
            {
                subNavigationTemplateLtr = "<ul class=\"dropdown-menu _ltr\">{0}</ul>\n";
            }

            if (subNavigationTemplateRtl == null)
            {
                subNavigationTemplateRtl = "<ul class=\"dropdown-menu text-right rtl_\">{0}</ul>\n";
            }

            if (items != null)
            {
                foreach (NavigationItem menuItem in items)
                {
                    menuItem.initialize();
                }
            }
        }

        public NavigationItem(String version = "4.0")
        {
            this.version = version;
            elementType = ElementType.NavigationItem;

            initialize();
        }

        public NavigationItem(Element parentElement, String version = "4.0") : this(version)
        {
            this.parentElement = parentElement;
        }

        public NavigationItem(String id, String text, String title,
                String linkId, String linkUrl, String linkTitle, String version = "4.0") : this(version)
        {
            this.text = text;

            if (id != null)
            {
                attributes.Add(new ItemAttribute("id", id));
            }

            if (title != null)
            {
                attributes.Add(new ItemAttribute("title", title));
            }

            this.linkUrl = linkUrl;

            if (linkId != null)
            {
                linkAttributes.Add(new ItemAttribute("id", linkId));
            }

            if (linkTitle != null)
            {
                linkAttributes.Add(new ItemAttribute("title", linkTitle));
            }
        }

        public NavigationItem(String id, String text, String title, String linkId, String linkUrl, String linkTitle, Element parentElement, String version = "4.0") 
            : this(id, text, title, linkId, linkUrl, linkTitle, version)
        {
            this.parentElement = parentElement;
            elementType = ElementType.NavigationItem;
        }

        public NavigationItem(String id, String text, String title, String cssClass,
                String linkId, String linkUrl, String linkTitle,
                String linkCssClass, String version = "4.0") 
            : this(version)
        {
            this.text = text;

            if (id != null)
            {
                attributes.Add(new ItemAttribute("id", id));
            }

            if (title != null)
            {
                attributes.Add(new ItemAttribute("title", title));
            }

            if (cssClass != null)
            {
                attributes.Add(new ItemAttribute("class", cssClass));
            }

            if (linkUrl == null && "divider".Equals(cssClass))
            {
                separator = true;
            }

            this.linkUrl = linkUrl;

            if (linkId != null)
            {
                linkAttributes.Add(new ItemAttribute("id", linkId));
            }

            if (linkTitle != null)
            {
                linkAttributes.Add(new ItemAttribute("title", linkTitle));
            }

            if (linkCssClass != null)
            {
                linkAttributes.Add(new ItemAttribute("class", linkCssClass));
            }
        }

        public NavigationItem(String id, String text, String title, String cssClass, String linkId, String linkUrl, String linkTitle, String linkCssClass, Element parentElement, String version = "4.0") 
            : this(id,text,title,cssClass,linkId, linkUrl, linkTitle, linkCssClass, version)
        {   
            this.parentElement = parentElement;
            this.baseUri = parentElement.getBaseUri();
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

            e.editMode = this.editMode;

            e.largeViewPort = this.largeViewPort;

            if (this.authenticatedUser == null)
            {
                this.authenticatedUser = parentElement.getAuthenticatedUser();
            }

            if (this.authenticatedRoles == null)
            {
                this.setAuthenticatedRoles(parentElement.getAuthenticatedRoles());
            }

            if (!e.authenticationMode)
            {
                e.authenticationMode = this.authenticationMode;
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

            if (e.separator)
            {
                sepratorCount++;
                if (sepratorCount >= 2)
                {
                    //skip
                }
                else
                {
                    if (items.Count > 0)
                    {
                        items.Add(e);
                    }
                }
            }
            else
            {
                sepratorCount = 0;
                items.Add(e);
            }
        }

        public String getNavigationIcon()
        {
            return navigationIcon;
        }

        public void setNavigationIcon(String navigationIcon)
        {
            this.navigationIcon = navigationIcon;
        }

        public String getLinkUrl()
        {
            return linkUrl;
        }

        public void setLinkUrl(String linkUrl)
        {
            this.linkUrl = linkUrl;
        }

        public Boolean getNoBaseUri()
        {
            return noBaseUri;
        }

        public void setNoBaseUri(Boolean apply)
        {
            this.noBaseUri = apply;
        }

        public Boolean getSeparator()
        {
            return separator;
        }

        public void setSeparator(Boolean separator)
        {
            this.separator = separator;
        }

        public List<ItemAttribute> getLinkAttributes()
        {
            return linkAttributes;
        }

        public void setLinkAttributes(List<ItemAttribute> linkAttributes)
        {
            this.linkAttributes = linkAttributes;
        }

        public List<ItemAttribute> getLinkStyles()
        {
            return linkStyles;
        }

        public void setLinkStyles(List<ItemAttribute> linkStyles)
        {
            this.linkStyles = linkStyles;
        }

        public override void synchronizeChildElements(Element parentElement)
        {
            this.setParentElement(parentElement);

            if (parentElement != null)
            {
                this.editMode = parentElement.getEditMode();
                this.largeViewPort = parentElement.getLargeViewPort();

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

            if (this.items == null)
            {
                return;

            }
            else
            {
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
        }

        public String renderLinkElementAttributes()
        {
            if (linkAttributes != null)
            {
                String attributesText = "";
                if (linkStyles != null)
                {
                    String stylesText = renderStyleAttributes();
                    if (!(String.IsNullOrEmpty(stylesText) || String.IsNullOrWhiteSpace(stylesText)))
                    {
                        linkAttributes.Add(new ItemAttribute("style", stylesText));
                    }
                }

                foreach (ItemAttribute attribute in linkAttributes)
                {

                    String localeValue = attribute.getValue();

                    attributesText += String.Format("{0} = \"{1}\" ", attribute.getName(), attribute.getValue());
                }

                attributesText = attributesText.Trim();
                return attributesText;
            }
            return "";
        }

        public String renderLinkStyleAttributes()
        {
            if (linkStyles != null)
            {
                String attributesText = "";
                foreach (ItemAttribute attribute in linkStyles)
                {

                    attributesText += String.Format("{0}: {1}; ", attribute.getName(), attribute.getValue());
                }
                attributesText = attributesText.Trim();
                return attributesText;
            }
            return "";
        }

        public override String generateHtml(String[] renderRoles)
        {

            if (string.IsNullOrEmpty(linkUrl))
            {
                if (separator)
                {
                    return String.Format(itemSepratorTemplate, renderElementAttributes());
                }

                String item = "";
                if (editMode)
                {

                    if (depthLevel == 1)
                    {
                        item = String.Format(editItemTemplateLevel1, renderElementAttributes(), getText());
                    }
                    else if (depthLevel == 2)
                    {
                        attributes.Add(new ItemAttribute("class", "input-group"));
                        item = String.Format(editItemTemplateLevel2, renderElementAttributes(), getText());
                    }
                    return item;
                }

                item = String.Format(itemTemplate, renderElementAttributes(), getText());
                return item;
            }
            else
            {
                if (items == null)
                {
                    items = new List<NavigationItem>();
                }

                if (items.Count == 0)
                {
                    String link = "";
                    if (noBaseUri)
                    {
                        link = String.Format(linkTemplate, renderLinkElementAttributes(), linkUrl, getText());

                    }
                    else
                    {
                        link = String.Format(linkTemplate, renderLinkElementAttributes(), this.getBaseUri() + linkUrl, getText());

                    }

                    String item = "";
                    if (editMode)
                    {
                        if (depthLevel == 1)
                        {
                            item = String.Format(editItemTemplateLevel1, renderElementAttributes(), link);
                        }
                        else if (depthLevel == 2)
                        {
                            attributes.Add(new ItemAttribute("class", "input-group"));
                            item = String.Format(editItemTemplateLevel2, renderElementAttributes(), link);
                        }
                        return item;
                    }

                    item = String.Format(itemTemplate, renderElementAttributes(), link);
                    return item;
                }
                else if (items.Count > 0)
                {
                    String link = String.Format(linkNavigationTemplate, renderLinkElementAttributes(), getText(), navigationIcon);

                    String itemsHtml = "";
                    int itemCount = 0;
                    foreach (NavigationItem menuItem in items)
                    {

                        if (menuItem.separator)
                        {
                            sepratorCount++;
                            if (sepratorCount >= 2)
                            {
                                //skip
                            }
                            else
                            {
                                if (itemCount > 0)
                                {
                                    itemsHtml += String.Format(itemSepratorTemplate, menuItem.renderElementAttributes());
                                    itemCount = 0;
                                }
                            }
                        }
                        else
                        {
                            sepratorCount = 0;
                            depthLevel++;
                            String renderedHtml = menuItem.renderHtml(renderRoles);
                            depthLevel--;
                            if (renderedHtml != null)
                            {
                                if (!(String.IsNullOrEmpty(renderedHtml) || String.IsNullOrWhiteSpace(renderedHtml)))
                                {
                                    itemsHtml += renderedHtml;
                                    itemCount++;
                                }
                            }
                        }
                    }

                    Element parentItem = this.parentElement;

                    try
                    {
                        while (!parentItem.isNavigationType())
                        {

                            if (parentItem.getParentElement() == null)
                            {
                                break;
                            }
                            else
                            {
                                parentItem = parentItem.getParentElement();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        notify(ex.Message);
                    }

                    if (editMode)
                    {
                        itemsHtml += newItemTemplateLevel1;
                    }

                    String subNavigation;
                    if (parentItem == null)
                    {
                        subNavigation = String.Format(subNavigationTemplate, itemsHtml);
                    }
                    else
                    {
                        // need to set language direction settings

                        if (Utility.getLanguageDirection(parentItem.getLocaleCode()) == LanguageDirection.Default)
                        {
                            subNavigation = String.Format(subNavigationTemplate, itemsHtml);
                        }
                        else if (Utility.getLanguageDirection(parentItem.getLocaleCode()) == LanguageDirection.LeftToRight)
                        {
                            subNavigation = String.Format(subNavigationTemplateLtr, itemsHtml);
                        }
                        else if (Utility.getLanguageDirection(parentItem.getLocaleCode()) == LanguageDirection.RightToLeft)
                        {
                            subNavigation = String.Format(subNavigationTemplateRtl, itemsHtml);
                        }
                        else
                        {
                            subNavigation = String.Format(subNavigationTemplate, itemsHtml);
                        }
                    }

                    String item = String.Format(itemTemplate, renderElementAttributes(), String.Format("{0} {1}", link, subNavigation));

                    if (editMode)
                    {
                        //submenu is at level 1
                        item += editLinkNavigationTemplate;
                        return item;
                    }
                    return item;
                }
            }
            return "";
        }

        public override String renderHtml(String[] renderRoles)
        {
            if (authenticationMode)
            {
                if (isAuthorized(renderRoles))
                {
                    return generateHtml(renderRoles);
                }
                return "";
            }
            else
            {
                return generateHtml(renderRoles);
            }
        }
    }
}
