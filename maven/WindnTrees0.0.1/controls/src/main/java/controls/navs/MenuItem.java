/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controls.navs;

import java.util.ArrayList;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

/**
 *
 * @author shams
 */
@JsonIgnoreProperties
public class MenuItem extends Element {

    private String linkUrl;
    private String menuIcon = "caret";
    private Boolean separator = false;
    private int sepratorCount = 0;

    private String itemTemplate = "<li %1$s>%2$s</li>\n";
    
    private String newItemTemplateLevel1 = "<li title=\"\">&nbsp;&nbsp;</li>\n"
            + "<li class=\"input-group text-center menu-item-level-0\" title=\"manage navigations\">\n"
            + "<span class=\"input-group-btn\">\n"
            + "<a class=\"btn btn-sm btn-default\" href=\"#\" title=\"new\" style=\"\">NEW</a>\n"
            + "</span>\n"
            + "</li>";

    private String editItemTemplateLevel1 = "<li %1$s>%2$s</li>\n"
            + "<li class=\"input-group text-center menu-item-level-0\" title=\"\">\n"
            + "<span class=\"input-group-btn\">\n"
            + "<a class=\"btn btn-sm btn-default\" href=\"#\" title=\"edit\" style=\"\">e</a>\n"
            + "<a class=\"btn btn-sm btn-default\" href=\"#\" title=\"remove\">r</a>\n"
            + "<a class=\"btn btn-sm btn-default\" href=\"#\" title=\"new\">n</a>\n"
            + "</span>\n"
            + "</li>";

    private String newItemTemplateLevel2 = "<li class=\"input-group text-center\" title=\"\">\n"
            + "<span class=\"input-group-btn\">\n"
            + "<a class=\"btn btn-sm btn-default\" href=\"#\" title=\"new\">NEW</a>\n"
            + "</span>\n"
            + "</li>";
    
    private String editItemTemplateLevel2 = "<li %1$s>%2$s"
            + "<span class=\"input-group-btn\">\n"
            + "<a class=\"btn btn-sm btn-default\" href=\"#\" title=\"edit\" style=\"\">e</a>\n"
            + "<a class=\"btn btn-sm btn-default\" href=\"#\" title=\"remove\">r</a>\n"
            + "</span>"
            + "</li>\n";
            

    private String itemSepratorTemplate = "<li role=\"separator\" class=\"divider\"></li>";

    private String linkTemplate = "<a %1$s href=\"%2$s\">%3$s</a>";
    private String linkMenuTemplate = "<a %1$s href=\"#\" class=\"dropdown-toggle\" "
            + "data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" "
            + "aria-expanded=\"false\">%2$s "
            + "<span class=\"%3$s\"></span>"
            + "</a>";
    
    private String editLinkMenuTemplate = "<li class=\"input-group text-center menu-item-level-0\" title=\"\">\n"
            + "<span class=\"input-group-btn\">\n"
            + "<a class=\"btn btn-sm btn-default\" href=\"#\" title=\"edit\" style=\"\">e</a>\n"
            + "<a class=\"btn btn-sm btn-default\" href=\"#\" title=\"remove\">r</a>\n"
            + "</span>\n"
            + "</li>";

    private String subMenuTemplate = "<ul class=\"dropdown-menu\">%1$s</ul>\n";

    private ArrayList<ItemAttribute> linkAttributes = new ArrayList<>();
    private ArrayList<ItemAttribute> linkStyles = new ArrayList<>();

    private ArrayList<MenuItem> items = new ArrayList<>();

    public MenuItem() {
        elementType = ElementType.MenuItem;
    }

    public MenuItem(Element parentElement) {
        this();
        this.parentElement = parentElement;

        elementType = ElementType.MenuItem;
    }

    public MenuItem(String id, String text, String title,
            String linkId, String linkUrl, String linkTitle) {
        this();
        this.text = text;

        if (id != null) {
            attributes.add(new ItemAttribute("id", id));
        }
        if (title != null) {
            attributes.add(new ItemAttribute("title", title));
        }

        this.linkUrl = linkUrl;

        if (linkId != null) {
            linkAttributes.add(new ItemAttribute("id", linkId));
        }
        if (linkTitle != null) {
            linkAttributes.add(new ItemAttribute("title", linkTitle));
        }

        elementType = ElementType.MenuItem;
    }

    public MenuItem(String id, String text, String title,
            String linkId, String linkUrl, String linkTitle,
            Element parentElement) {
        this();
        this.text = text;

        if (id != null) {
            attributes.add(new ItemAttribute("id", id));
        }
        if (title != null) {
            attributes.add(new ItemAttribute("title", title));
        }

        this.linkUrl = linkUrl;

        if (linkId != null) {
            linkAttributes.add(new ItemAttribute("id", linkId));
        }
        if (linkTitle != null) {
            linkAttributes.add(new ItemAttribute("title", linkTitle));
        }

        this.parentElement = parentElement;
        this.localeMode = parentElement.localeMode;
        this.locale = parentElement.locale;
        this.messageSource = parentElement.messageSource;
        this.dataStoreMode = parentElement.dataStoreMode;

        elementType = ElementType.MenuItem;
    }

    public MenuItem(String id, String text, String title, String cssClass,
            String linkId, String linkUrl, String linkTitle,
            String linkCssClass) {
        this();
        this.text = text;

        if (id != null) {
            attributes.add(new ItemAttribute("id", id));
        }
        if (title != null) {
            attributes.add(new ItemAttribute("title", title));
        }
        if (cssClass != null) {
            attributes.add(new ItemAttribute("class", cssClass));
        }

        if (linkUrl == null && "divider".equals(cssClass)) {
            separator = true;
        }

        this.linkUrl = linkUrl;

        if (linkId != null) {
            linkAttributes.add(new ItemAttribute("id", linkId));
        }
        if (linkTitle != null) {
            linkAttributes.add(new ItemAttribute("title", linkTitle));
        }
        if (linkCssClass != null) {
            linkAttributes.add(new ItemAttribute("class", linkCssClass));
        }

        elementType = ElementType.MenuItem;
    }

    public MenuItem(String id, String text, String title, String cssClass,
            String linkId, String linkUrl, String linkTitle,
            String linkCssClass, Element parentElement) {
        this();
        this.text = text;

        if (id != null) {
            attributes.add(new ItemAttribute("id", id));
        }
        if (title != null) {
            attributes.add(new ItemAttribute("title", title));
        }
        if (cssClass != null) {
            attributes.add(new ItemAttribute("class", cssClass));
        }

        if (linkUrl == null && "divider".equals(cssClass)) {
            separator = true;
        }

        this.linkUrl = linkUrl;

        if (linkId != null) {
            linkAttributes.add(new ItemAttribute("id", linkId));
        }
        if (linkTitle != null) {
            linkAttributes.add(new ItemAttribute("title", linkTitle));
        }
        if (linkCssClass != null) {
            linkAttributes.add(new ItemAttribute("class", linkCssClass));
        }

        this.parentElement = parentElement;

        this.localeMode = parentElement.localeMode;
        this.locale = parentElement.locale;
        this.messageSource = parentElement.messageSource;
        this.dataStoreMode = parentElement.dataStoreMode;
        this.baseUri = parentElement.getBaseUri();

        elementType = ElementType.MenuItem;
    }

    public int getSepratorCount() {
        return sepratorCount;
    }

    public void setSepratorCount(int sepratorCount) {
        this.sepratorCount = sepratorCount;
    }

    public String getItemTemplate() {
        return itemTemplate;
    }

    public void setItemTemplate(String itemTemplate) {
        this.itemTemplate = itemTemplate;
    }

    public String getNewItemTemplateLevel1() {
        return newItemTemplateLevel1;
    }

    public void setNewItemTemplateLevel1(String newItemTemplateLevel1) {
        this.newItemTemplateLevel1 = newItemTemplateLevel1;
    }

    public String getEditItemTemplateLevel1() {
        return editItemTemplateLevel1;
    }

    public void setEditItemTemplateLevel1(String editItemTemplateLevel1) {
        this.editItemTemplateLevel1 = editItemTemplateLevel1;
    }

    public String getNewItemTemplateLevel2() {
        return newItemTemplateLevel2;
    }

    public void setNewItemTemplateLevel2(String newItemTemplateLevel2) {
        this.newItemTemplateLevel2 = newItemTemplateLevel2;
    }

    public String getEditItemTemplateLevel2() {
        return editItemTemplateLevel2;
    }

    public void setEditItemTemplateLevel2(String editItemTemplateLevel2) {
        this.editItemTemplateLevel2 = editItemTemplateLevel2;
    }

    public String getItemSepratorTemplate() {
        return itemSepratorTemplate;
    }

    public void setItemSepratorTemplate(String itemSepratorTemplate) {
        this.itemSepratorTemplate = itemSepratorTemplate;
    }

    public String getLinkTemplate() {
        return linkTemplate;
    }

    public void setLinkTemplate(String linkTemplate) {
        this.linkTemplate = linkTemplate;
    }

    public String getLinkMenuTemplate() {
        return linkMenuTemplate;
    }

    public void setLinkMenuTemplate(String linkMenuTemplate) {
        this.linkMenuTemplate = linkMenuTemplate;
    }

    public String getEditLinkMenuTemplate() {
        return editLinkMenuTemplate;
    }

    public void setEditLinkMenuTemplate(String editLinkMenuTemplate) {
        this.editLinkMenuTemplate = editLinkMenuTemplate;
    }

    public String getSubMenuTemplate() {
        return subMenuTemplate;
    }

    public void setSubMenuTemplate(String subMenuTemplate) {
        this.subMenuTemplate = subMenuTemplate;
    }

    public ArrayList<MenuItem> getItems() {
        return items;
    }

    public void setItems(ArrayList<MenuItem> items) {
        this.items = items;
    }

    public void addComponent(MenuItem e) {

        e.setParentElement(this);

        e.editMode = this.editMode;
        e.locale = this.locale;
        e.localeMode = this.localeMode;
        e.dataStoreMode = this.dataStoreMode;
        e.largeViewPort = this.largeViewPort;

        e.messageSource = this.messageSource;
        e.localeItemRepository = this.localeItemRepository;

        if (this.authenticatedUser == null) {
            this.authenticatedUser = parentElement.authenticatedUser;
        }

        if (this.authenticatedRoles == null) {
            this.setAuthenticatedRoles(parentElement.getAuthenticatedRoles());
        }

        if (e.authenticationMode == null) {
            e.authenticationMode = this.authenticationMode;
        } else if (!e.authenticationMode) {
            e.authenticationMode = this.authenticationMode;
        }

        if (e.getBaseUri() == null) {
            e.setBaseUri(this.getBaseUri());
        } else {
            if (e.getBaseUri().isEmpty()) {
                e.setBaseUri(this.getBaseUri());
            }
        }

        if (e.separator) {
            sepratorCount++;
            if (sepratorCount >= 2) {
                //skip
            } else {
                if (items.size() > 0) {
                    items.add(e);
                }
            }
        } else {
            sepratorCount = 0;
            items.add(e);
        }
    }

    public String getMenuIcon() {
        return menuIcon;
    }

    public void setMenuIcon(String menuIcon) {
        this.menuIcon = menuIcon;
    }

    public String getLinkUrl() {
        return linkUrl;
    }

    public void setLinkUrl(String linkUrl) {
        this.linkUrl = linkUrl;
    }

    public Boolean getSeparator() {
        return separator;
    }

    public void setSeparator(Boolean separator) {
        this.separator = separator;
    }

    public ArrayList<ItemAttribute> getLinkAttributes() {
        return linkAttributes;
    }

    public void setLinkAttributes(ArrayList<ItemAttribute> linkAttributes) {
        this.linkAttributes = linkAttributes;
    }

    public ArrayList<ItemAttribute> getLinkStyles() {
        return linkStyles;
    }

    public void setLinkStyles(ArrayList<ItemAttribute> linkStyles) {
        this.linkStyles = linkStyles;
    }

    @Override
    public void synchronizeChildElements(Element parentElement) {
        this.setParentElement(parentElement);
        if (parentElement != null) {
            this.editMode = parentElement.editMode;
            this.localeMode = parentElement.localeMode;
            this.locale = parentElement.locale;
            this.messageSource = parentElement.messageSource;
            this.largeViewPort = parentElement.largeViewPort;

            if (this.authenticatedUser == null) {
                this.authenticatedUser = parentElement.authenticatedUser;
            }

            if (this.authenticatedRoles == null) {
                this.setAuthenticatedRoles(parentElement.getAuthenticatedRoles());
            }

            if (!this.authenticationMode) {
                this.authenticationMode = parentElement.authenticationMode;
            }

            this.setBaseUri(parentElement.getBaseUri());
        }

        if (this.items.isEmpty()) {
            return;
        } else {
            for (MenuItem item : items) {
                item.synchronizeChildElements(this);
            }
        }
    }

    public String renderLinkElementAttributes() {
        if (linkAttributes != null) {
            String attributesText = "";
            if (linkStyles != null) {
                String stylesText = renderStyleAttributes();
                if (stylesText.trim().length() > 0) {
                    linkAttributes.add(new ItemAttribute("style", stylesText));
                }
            }

            for (ItemAttribute attribute : linkAttributes) {

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

    public String renderLinkStyleAttributes() {
        if (linkStyles != null) {
            String attributesText = "";
            for (ItemAttribute attribute : linkStyles) {

                attributesText += String.format("%1$s: %2$s; ", attribute.getName(), attribute.getValue());
            }
            attributesText = attributesText.trim();
            return attributesText;
        }
        return "";
    }

    @Override
    public String generateHtml(String[] renderRoles) {

        if (linkUrl == null) {
            if (separator) {
                return itemSepratorTemplate;
            }

            if (editMode) {
                String item="";
                if (depthLevel == 1) {
                    item = String.format(editItemTemplateLevel1, renderElementAttributes(),getText());
                } else if (depthLevel == 2) {
                    attributes.add(new ItemAttribute("class", "input-group"));
                    item = String.format(editItemTemplateLevel2, renderElementAttributes(),getText());
                }
                return item;
            }

            String item = String.format(itemTemplate,
                    renderElementAttributes(),
                    getText());
            return item;

        } else {
            if (items.isEmpty()) {

                String link = String.format(linkTemplate,
                        renderLinkElementAttributes(),
                        this.getBaseUri() + linkUrl, getText());

                if (editMode) {
                    String item = "";
                    if (depthLevel == 1) {
                        item = String.format(editItemTemplateLevel1, renderElementAttributes(), link);
                    } else if (depthLevel == 2) {
                        attributes.add(new ItemAttribute("class", "input-group"));
                        item = String.format(editItemTemplateLevel2, renderElementAttributes(), link);
                    }
                    return item;
                }

                String item = String.format(itemTemplate,
                        renderElementAttributes(),
                        link);
                return item;
                
            } else if (items.size() > 0) {
                String link = String.format(linkMenuTemplate,
                        renderLinkElementAttributes(),
                        getText(), menuIcon);

                String itemsHtml = "";
                int itemCount = 0;
                for (MenuItem menuItem : items) {

                    if (menuItem.separator) {
                        sepratorCount++;
                        if (sepratorCount >= 2) {
                            //skip
                        } else {
                            if (itemCount > 0) {
                                itemsHtml += itemSepratorTemplate;
                                itemCount = 0;
                            }
                        }
                    } else {
                        sepratorCount = 0;
                        depthLevel++;
                        String renderedHtml = menuItem.renderHtml(renderRoles);
                        depthLevel--;
                        if (renderedHtml != null) {
                            if (!renderedHtml.isEmpty()) {
                                itemsHtml += renderedHtml;
                                itemCount++;
                            }
                        }
                    }
                }

                Element parentItem = this.parentElement;

                try {
                    while (!parentItem.isMenuType()) {

                        if (parentItem.parentElement == null) {
                            break;
                        } else {
                            parentItem = parentItem.parentElement;
                        }
                    }
                } catch (Exception ex) {
                    logger.error(ex.getMessage());
                }

                if (editMode) {
                    itemsHtml += newItemTemplateLevel1;
                }
                
                String subMenu;
                if (parentItem == null) {
                    subMenu = String.format(subMenuTemplate, itemsHtml);
                } else {
                    
                    subMenu = String.format(subMenuTemplate, itemsHtml);
                }

                String item = String.format(itemTemplate,
                        renderElementAttributes(),
                        String.format("%1$s %2$s", link, subMenu));
                
                if (editMode) {
                    //submenu is at level 1
                    item += editLinkMenuTemplate;
                    return item;
                }
                return item;
            }
        }
        return "";
    }

    @Override
    public String renderHtml(String[] renderRoles) {
        if (authenticationMode) {
            if (isAuthorized(renderRoles)) {
                return generateHtml(renderRoles);
            }
            return "";
        } else {
            return generateHtml(renderRoles);
        }
    }
}
