/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controls.navs;

import java.util.ArrayList;
import java.util.Locale;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import org.springframework.context.support.ReloadableResourceBundleMessageSource;

/**
 *
 * @author shams
 */
@JsonIgnoreProperties
public class Menu extends Element {
    
    //Version 4.0 Attributes
    private String navigationContainerTemplate = "<div class=\"%1$s\">%2$s</div>";
    private String navigationContainerCssClass = "container-fluid";
    //Version 4.0 Attributes - End

    private final String newItemTemplateLevel1 = "<li title=\"\">&nbsp;&nbsp;</li>\n"
            + "<li class=\"input-group text-center menu-item-level-0\" title=\"manage navigations\">\n"
            + "<span class=\"input-group-btn\">\n"
            + "<a class=\"btn btn-sm btn-default\" href=\"#\" title=\"new\" style=\"\">NEW</a>\n"
            + "</span>\n"
            + "</li>";

    private ArrayList<MenuItem> items = new ArrayList<>();

    public Menu() {
        this.tag = "ul";
        attributes.add(new ItemAttribute("class", "nav navbar-nav"));

        elementType = ElementType.Menu;
    }

    public Menu(String baseUri) {
        this.tag = "ul";
        attributes.add(new ItemAttribute("class", "nav navbar-nav"));
        this.baseUri = baseUri;

        elementType = ElementType.Menu;
    }

    public Menu(String baseUri, Element parentElement) {
        this.tag = "ul";
        attributes.add(new ItemAttribute("class", "nav navbar-nav"));

        this.parentElement = parentElement;
        this.localeMode = parentElement.localeMode;
        this.locale = parentElement.locale;
        this.messageSource = parentElement.messageSource;
        this.baseUri = baseUri;

        elementType = ElementType.Menu;
    }

    public Menu(String baseUri, Element parentElement, String cssClass) {
        this.tag = "ul";
        attributes.add(new ItemAttribute("class", cssClass));

        this.parentElement = parentElement;
        this.localeMode = parentElement.localeMode;
        this.locale = parentElement.locale;
        this.messageSource = parentElement.messageSource;
        this.baseUri = baseUri;

        if (cssClass.equalsIgnoreCase("nav navbar-nav")) {
            elementType = ElementType.Menu;
        } else if (cssClass.equalsIgnoreCase("nav navbar-nav navbar-left")) {
            elementType = ElementType.MenuLeft;
        } else if (cssClass.equalsIgnoreCase("nav navbar-nav navbar-right")) {
            elementType = ElementType.MenuRight;
        } else {
            elementType = ElementType.Menu;
        }
    }

    public Menu(ReloadableResourceBundleMessageSource messageSource,
            Locale locale, Boolean localeMode) {
        this.tag = "ul";
        attributes.add(new ItemAttribute("class", "nav navbar-nav"));

        this.messageSource = messageSource;
        this.locale = locale;
        this.localeMode = localeMode;

        elementType = ElementType.Menu;
    }

    public Menu(String cssClass, ReloadableResourceBundleMessageSource messageSource,
            Locale locale, Boolean localeMode) {
        this.tag = "ul";
        attributes.add(new ItemAttribute("class", cssClass));

        this.messageSource = messageSource;
        this.locale = locale;
        this.localeMode = localeMode;

        if (cssClass.equalsIgnoreCase("nav navbar-nav")) {
            elementType = ElementType.Menu;
        } else if (cssClass.equalsIgnoreCase("nav navbar-nav navbar-left")) {
            elementType = ElementType.MenuLeft;
        } else if (cssClass.equalsIgnoreCase("nav navbar-nav navbar-right")) {
            elementType = ElementType.MenuRight;
        } else {
            elementType = ElementType.Menu;
        }
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

        items.add(e);
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

    @Override
    public String generateHtml(String[] renderRoles) {
        String html = "";

        for (Element e : items) {
            html += e.renderHtml(renderRoles);
        }

        if (editMode) {
            html += newItemTemplateLevel1;
        }

        return html;
    }

    @Override
    public String renderHtml(String[] renderRoles) {

        if (getVersion().equals("4.0")) {

            String navigation = String.format(template, tag, renderElementAttributes(), generateHtml(renderRoles), tag);
            //String navigationContentContainer = String.format(navigationContainerTemplate, navigationContainerCssClass, navigation);

            return navigation;

        } else {

            return String.format(template, tag, renderElementAttributes(), generateHtml(renderRoles), tag);
        }
    }
}
