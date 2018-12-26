/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controls.navs.content;

import controls.navs.Element;
import controls.navs.ElementType;
import controls.navs.ItemAttribute;
import controls.navs.LanguageDirection;
import controls.navs.Menu;
import controls.navs.MenuBar;
import controls.navs.MenuItem;
import controls.navs.Utility;
import java.util.Locale;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.context.support.ReloadableResourceBundleMessageSource;

/**
 *
 * @author shams
 */
public class NavigationMenuAdapter {

    private static final Logger logger = LoggerFactory
            .getLogger(NavigationMenuAdapter.class);
    
    public static MenuBar createEntityMenuBar(Iterable<NavigationMenu> navEntityMenus, String authorizedUser, String authorizedRoles[],
            String requestedAddress, ReloadableResourceBundleMessageSource messageSource,
            LocaleItemRepository localeItemRepository,
            Locale locale, Boolean localeMode, Boolean dataStoreMode, Boolean largeViewPort, Boolean editMode) {

        MenuBar menuBar = new MenuBar(messageSource, locale, localeMode, dataStoreMode);
        menuBar.setBaseUriAndParentElement(requestedAddress, null);
        menuBar.setLocaleItemRepository(localeItemRepository);
        menuBar.setLargeViewPort(largeViewPort);
        menuBar.setEditMode(editMode);
        
        try {
            for (NavigationMenu navEntityMenu : navEntityMenus) {

                Menu navMenu = new Menu(messageSource, locale, localeMode);
                //navMenu.setDataStoreLocaleMode(dataStoreMode);
                navMenu.setEditMode(editMode);
                navMenu.getAttributes().clear();
                navMenu.setBaseUriAndParentElement(requestedAddress, menuBar);
                
                if (navEntityMenu.getNavigationType() == 0
                        || navEntityMenu.getNavigationType() == 0) {
                    
                    if (Utility.getLanguageDirection(locale) == LanguageDirection.Default
                            || Utility.getLanguageDirection(locale) == LanguageDirection.LeftToRight) {
                        navMenu.addElementAttribute(new ItemAttribute("class", "nav navbar-nav navbar-left"));
                        navMenu.setElementType(ElementType.MenuLeft);
                    } else if (Utility.getLanguageDirection(locale) == LanguageDirection.RightToLeft) {
                        navMenu.addElementAttribute(new ItemAttribute("class", "nav navbar-nav navbar-right"));
                        navMenu.setElementType(ElementType.MenuRight);
                    }
                    
                } else if (navEntityMenu.getNavigationType() == 1) {
                    
                    if (Utility.getLanguageDirection(locale) == LanguageDirection.Default
                            || Utility.getLanguageDirection(locale) == LanguageDirection.LeftToRight) {
                        navMenu.addElementAttribute(new ItemAttribute("class", "nav navbar-nav navbar-right"));
                        navMenu.setElementType(ElementType.MenuRight);
                    } else if (Utility.getLanguageDirection(locale) == LanguageDirection.RightToLeft) {
                        navMenu.addElementAttribute(new ItemAttribute("class", "nav navbar-nav navbar-left"));
                        navMenu.setElementType(ElementType.MenuRight);
                    }
                }
                
                navMenu.setAuthenticatedUser(authorizedUser);
                navMenu.setAuthenticatedRoles(authorizedRoles);
                navMenu.setUsersViaString(navEntityMenu.getUsers());
                navMenu.setRolesViaString(navEntityMenu.getRoles());
                navMenu.setAuthenticationMode(navEntityMenu.isAuthMode());
                
                navMenu.setText(navEntityMenu.getName());
                navMenu.addElementAttribute(new ItemAttribute("title", navEntityMenu.getName()));
                
                for (Navigation navEntityItem : navEntityMenu.getItems()) {

                    MenuItem menuItem = null;
                    if (navEntityItem.isSeparator()) {
                        menuItem = new MenuItem(null, null, null, "divider", null, null, null, null);
                        menuItem.setAuthenticationMode(navEntityItem.isAuthMode());
                        navMenu.addComponent(menuItem);
                    } else {

                        
                        if (navMenu.getLocaleMode()) {
                            menuItem = new MenuItem(null, navEntityItem.getLocaleText(), navEntityItem.getLocaleTitle(), null, navEntityItem.getLinkUrl(), navEntityItem.getLinkLocaleTitle());
                        } else {
                            menuItem = new MenuItem(null, navEntityItem.getText(), navEntityItem.getTitle(), null, navEntityItem.getLinkUrl(), navEntityItem.getLinkTitle());
                        }

                        menuItem.setAuthenticatedUser(authorizedUser);
                        menuItem.setAuthenticatedRoles(authorizedRoles);

                        menuItem.setUsersViaString(navEntityItem.getUsers());
                        menuItem.setRolesViaString(navEntityItem.getRoles());
                        menuItem.setAuthenticationMode(navEntityItem.isAuthMode());
                        
                        if (navEntityItem.getItems().isEmpty()) {
                            navMenu.addComponent(menuItem);
                        } else {
                            navMenu.addComponent(getEntityMenuItems(navEntityItem, authorizedUser, authorizedRoles, localeMode, navMenu));
                        }
                    }
                }
                menuBar.addComponent(navMenu);
            }
        } catch (Exception ex) {
            logger.error(ex.getMessage());
        }
        return menuBar;
    }

    public static MenuItem getEntityMenuItems(Navigation navEntityItem, String authorizedUser, String authorizedRoles[], Boolean localeMode, Element parentElement) {

        if (navEntityItem == null) {
            return null;
        } else {
            MenuItem menuItem = null;
            if (localeMode) {
                menuItem = new MenuItem(null, navEntityItem.getLocaleText(), navEntityItem.getLocaleTitle(), null, navEntityItem.getLinkUrl(), navEntityItem.getLinkLocaleTitle(), parentElement);
            } else {
                menuItem = new MenuItem(null, navEntityItem.getText(), navEntityItem.getTitle(), null, navEntityItem.getLinkUrl(), navEntityItem.getLinkTitle(), parentElement);
            }
            
            menuItem.setAuthenticatedUser(authorizedUser);
            menuItem.setAuthenticatedRoles(authorizedRoles);

            menuItem.setUsersViaString(navEntityItem.getUsers());
            menuItem.setRolesViaString(navEntityItem.getRoles());
            menuItem.setAuthenticationMode(navEntityItem.isAuthMode());
            
            menuItem.setDataStoreMode(parentElement.getDataStoreMode());
            menuItem.setLocaleItemRepository(parentElement.getLocaleItemRepository());
            menuItem.setBaseUri(parentElement.getBaseUri());
            menuItem.setLargeViewPort(parentElement.getLargeViewPort());
            menuItem.setEditMode(parentElement.getEditMode());
            
            if (navEntityItem.getItems().isEmpty()) {
                return menuItem;
            } else {
                for (Navigation navItem : navEntityItem.getItems()) {
                    
                    MenuItem subMenuItem = null;
                    if (navItem.isSeparator()) {
                        subMenuItem = new MenuItem(null, null, null, "divider", null, null, null, null);
                        subMenuItem.setAuthenticationMode(navItem.isAuthMode());
                        menuItem.addComponent(subMenuItem);
                    } else {
                        
                        if (localeMode) {
                            subMenuItem = new MenuItem(null, navItem.getLocaleText(), navItem.getLocaleTitle(), null, navItem.getLinkUrl(), navItem.getLinkLocaleTitle(), menuItem);
                        } else {
                            subMenuItem = new MenuItem(null, navItem.getText(), navItem.getTitle(), null, navItem.getLinkUrl(), navItem.getLinkTitle(), menuItem);
                        }

                        subMenuItem.setAuthenticatedUser(authorizedUser);
                        subMenuItem.setAuthenticatedRoles(authorizedRoles);

                        subMenuItem.setUsersViaString(navItem.getUsers());
                        subMenuItem.setRolesViaString(navItem.getRoles());
                        subMenuItem.setAuthenticationMode(navItem.isAuthMode());
                        
                        
                        if (navItem.getItems().isEmpty()) {
                            menuItem.addComponent(subMenuItem);
                        } else {
                            menuItem.addComponent(getEntityMenuItems(navItem, authorizedUser, authorizedRoles, localeMode, menuItem));
                        }
                    }
                }
            }
            return menuItem;
        }
    }
}
