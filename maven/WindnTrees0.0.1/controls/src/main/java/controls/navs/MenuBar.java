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
public class MenuBar extends Element {
    
    private ArrayList<Element> items = new ArrayList<>();
    
    public MenuBar() {
        this.tag = "div";
        attributes.add(new ItemAttribute("id", "main-nav"));
        attributes.add(new ItemAttribute("class", "collapse navbar-collapse"));
        elementType = ElementType.MenuBar;
    }
    
    public MenuBar(ReloadableResourceBundleMessageSource messageSource, 
            Locale locale, Boolean localeMode, Boolean dataStoreMode) {
        
        this.tag = "div";
        attributes.add(new ItemAttribute("id", "main-nav"));
        attributes.add(new ItemAttribute("class", "collapse navbar-collapse"));
        
        this.messageSource = messageSource;
        this.locale = locale;
        this.localeMode = localeMode;
        this.dataStoreMode = dataStoreMode;
        
        elementType = ElementType.MenuBar;
    }
    
    public MenuBar(String tag, String id, String cssClass, ReloadableResourceBundleMessageSource messageSource, 
            Locale locale, Boolean localeMode, Boolean dataStoreMode) {
        
        this.tag = tag;
        attributes.add(new ItemAttribute("id", id));
        attributes.add(new ItemAttribute("class", cssClass));
        
        this.messageSource = messageSource;
        this.locale = locale;
        this.localeMode = localeMode;
        
        this.dataStoreMode = dataStoreMode;
        
        elementType = ElementType.MenuBar;
    }
    
    public ArrayList<Element> getItems() {
        return items;
    }

    public void setItems(ArrayList<Element> items) {
        this.items = items;
    }
    
    public void clearBar() {
        items.clear();
    }
    
    public void addComponent(Element e) {

        e.setParentElement(this);

        e.editMode = this.editMode;
        e.dataStoreMode = this.dataStoreMode;
        e.localeMode = this.localeMode;
        e.locale = this.locale;
        e.messageSource = this.messageSource;
        e.setLargeViewPort(this.largeViewPort);
        e.setVersion(this.version);

        if (e.authenticationMode == null) {
            e.authenticationMode = this.authenticationMode;
        } else if (!e.authenticationMode) {
            e.authenticationMode = this.authenticationMode;
        }

        items.add(e);
    }
    
    @Override
    public String generateHtml(String[] renderRoles) {
        String html = "";
        for (Element e : items) {
            depthLevel++;
            html += e.renderHtml(renderRoles);
            depthLevel--;
        }
        return html;
    }
    
    @Override
    public String renderHtml(String[] renderRoles) {
        depthLevel = 0;
        return String.format(template, tag, renderElementAttributes(), generateHtml(renderRoles), tag);
    }
}