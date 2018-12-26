using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Controls.Navs
{
    [DataContract]
    public class NavigationContent : Element
    {
        [DataMember]
        private List<Element> items = new List<Element>();

        public NavigationContent()
        {
            this.tag = "div";
            this.id = "main-nav";
            this.cssClass = "navbar-collapse collapse";

            attributes.Add(new ItemAttribute("id", id));
            attributes.Add(new ItemAttribute("class", cssClass));

            elementType = ElementType.NavigationContent;
        }

        public NavigationContent(String localeCode, String version = "4.0") : this()
        {
            this.localeCode = localeCode;
            this.version = version;
        }

        public NavigationContent(String tag, String id, String cssClass, String localeCode, String version = "4.0") : this(localeCode)
        {
            this.tag = tag;
            this.id = id;
            this.cssClass = cssClass;
            this.version = version;
        }

        public List<Element> getItems()
        {
            return items;
        }

        public void setItems(List<Element> items)
        {
            this.items = items;
        }

        public void clearBar()
        {
            items.Clear();
        }

        public void addComponent(Element e)
        {
            e.setParentElement(this);
            e.setEditMode(this.editMode);
            e.setLocaleCode(this.localeCode);
            e.setLargeViewPort(this.largeViewPort);
            e.setVersion(this.getVersion());

            items.Add(e);
        }

        public override void initialize()
        {
            base.initialize();
            if (items != null)
            {
                foreach (Element element in items)
                {
                    element.initialize();
                }
            }
        }

        public override void initializeVersionAttributes(bool clearExitingAttributes = true)
        {   
        }

        public override String generateHtml(String[] renderRoles)
        {
            String html = "";
            foreach (Element e in items)
            {
                depthLevel++;
                html += e.renderHtml(renderRoles);
                depthLevel--;
            }
            return html;
        }

        public override String renderHtml(String[] renderRoles)
        {
            depthLevel = 0;
            return String.Format(template, tag, renderElementAttributes(), generateHtml(renderRoles), tag);
        }
    }
}
