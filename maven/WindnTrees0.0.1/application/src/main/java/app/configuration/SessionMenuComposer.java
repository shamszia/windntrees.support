/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package app.configuration;

import windntrees.data.UserInfo;
import windntrees.data.WebAppProperties;
import controls.navs.MenuBar;
import controls.navs.MenuComposer;
import controls.navs.content.NavigationMenu;
import java.util.Locale;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.context.i18n.LocaleContextHolder;
import org.springframework.context.support.ReloadableResourceBundleMessageSource;
import controls.navs.content.LocaleItemRepository;

/**
 *
 * @author shams
 */
public class SessionMenuComposer {
    
    protected static final Logger logger = LoggerFactory
                    .getLogger(SessionMenuComposer.class);

    public SessionMenuComposer() {
    }

    public static String composeFromJson(String navigations[], HttpServletRequest request,
            HttpSession session, Locale locale, ReloadableResourceBundleMessageSource messageSource, 
            WebAppProperties webAppProperties, Boolean largeViewPort, Boolean editMode, String[] renderRoles) {

        MenuBar menuToolBar = null;
        String navData = null;
        try {
            UserInfo userInfo = (UserInfo) session.getAttribute("userInfo");
            UserInfo recentUser = (UserInfo) session.getAttribute("recentUser");
            String languageCode = (String) session.getAttribute("languageCode");

            if (languageCode == null) {
                languageCode = locale.getLanguage();
            }

            if (userInfo == null) {
                if (recentUser == null) {

                    if (locale.getLanguage().equals(new Locale(languageCode).getLanguage())) {
                        //navData = (String) session.getAttribute("navData");
                        
                        //following should be removed/remarked in final build.
                        menuToolBar = MenuComposer.composeFromJson(navigations, userInfo == null ? null : userInfo.getAuthenticatedUser(), userInfo == null ? null : userInfo.getAuthenticatedRolesArray(),
                                request.getContextPath(), messageSource, LocaleContextHolder.getLocale(), webAppProperties.getMenuComposerLocaleMode(), webAppProperties.getMenuDataStoreMode(), largeViewPort, editMode);
                        navData = menuToolBar.renderHtml(renderRoles);
                        session.setAttribute("navData", navData);
                    } else {

                        menuToolBar = MenuComposer.composeFromJson(navigations, userInfo == null ? null : userInfo.getAuthenticatedUser(), userInfo == null ? null : userInfo.getAuthenticatedRolesArray(),
                                request.getContextPath(), messageSource, LocaleContextHolder.getLocale(), webAppProperties.getMenuComposerLocaleMode(), webAppProperties.getMenuDataStoreMode(), largeViewPort, editMode);
                        navData = menuToolBar.renderHtml(renderRoles);
                        session.setAttribute("navData", navData);
                    }

                    if (menuToolBar == null) {

                        menuToolBar = MenuComposer.composeFromJson(navigations, userInfo == null ? null : userInfo.getAuthenticatedUser(), userInfo == null ? null : userInfo.getAuthenticatedRolesArray(),
                                request.getContextPath(), messageSource, LocaleContextHolder.getLocale(), webAppProperties.getMenuComposerLocaleMode(), webAppProperties.getMenuDataStoreMode(), largeViewPort, editMode);
                        navData = menuToolBar.renderHtml(renderRoles);
                        session.setAttribute("navData", navData);
                    }
                }
            } else {

                if (recentUser == null) {
                    menuToolBar = MenuComposer.composeFromJson(navigations, userInfo == null ? null : userInfo.getAuthenticatedUser(), userInfo == null ? null : userInfo.getAuthenticatedRolesArray(),
                            request.getContextPath(), messageSource, LocaleContextHolder.getLocale(), webAppProperties.getMenuComposerLocaleMode(), webAppProperties.getMenuDataStoreMode(), largeViewPort, editMode);
                    navData = menuToolBar.renderHtml(renderRoles);
                    session.setAttribute("navData", navData);
                } else {
                    if (userInfo.equals(recentUser)) {
                        if (locale.getLanguage().equals(new Locale(languageCode).getLanguage())) {
                            navData = (String) session.getAttribute("navData");
                        } else {
                            menuToolBar = MenuComposer.composeFromJson(navigations, userInfo == null ? null : userInfo.getAuthenticatedUser(), userInfo == null ? null : userInfo.getAuthenticatedRolesArray(),
                                    request.getContextPath(), messageSource, LocaleContextHolder.getLocale(), webAppProperties.getMenuComposerLocaleMode(), webAppProperties.getMenuDataStoreMode(), largeViewPort, editMode);
                            navData = menuToolBar.renderHtml(renderRoles);
                            session.setAttribute("navData", navData);
                        }
                    } else {
                        menuToolBar = MenuComposer.composeFromJson(navigations, userInfo == null ? null : userInfo.getAuthenticatedUser(), userInfo == null ? null : userInfo.getAuthenticatedRolesArray(),
                                request.getContextPath(), messageSource, LocaleContextHolder.getLocale(), webAppProperties.getMenuComposerLocaleMode(), webAppProperties.getMenuDataStoreMode(), largeViewPort, editMode);
                        navData = menuToolBar.renderHtml(renderRoles);
                        session.setAttribute("navData", navData);
                    }
                }
            }
        } catch (Exception ex) {
            logger.error(ex.getMessage());
        }
        session.setAttribute("languageCode", locale.getLanguage());
        session.setAttribute("recentUser", session.getAttribute("userInfo"));
        return navData;
    }
    
    public static String composeFromDataStore(Iterable<NavigationMenu> navEntityMenus, HttpServletRequest request,
            HttpSession session, Locale locale, ReloadableResourceBundleMessageSource messageSource, 
            LocaleItemRepository localeItemRepository, WebAppProperties webAppProperties, 
            Boolean largeViewPort, Boolean editMode, String[] renderRoles) {

        MenuBar menuToolBar = null;
        String navData = null;
        try {
            UserInfo userInfo = (UserInfo) session.getAttribute("userInfo");
            UserInfo recentUser = (UserInfo) session.getAttribute("recentUser");
            String languageCode = (String) session.getAttribute("languageCode");

            if (languageCode == null) {
                languageCode = locale.getLanguage();
            }

            if (userInfo == null) {
                if (recentUser == null) {

                    if (locale.getLanguage().equals(new Locale(languageCode).getLanguage())) {
                        //remarked for testing should be restored in final build.
                        //navData = (String) session.getAttribute("navData");
                        
                        //following should be removed/remarked in final build.
                        menuToolBar = MenuComposer.composeFromDatastore(navEntityMenus, userInfo == null ? null : userInfo.getAuthenticatedUser(), userInfo == null ? null : userInfo.getAuthenticatedRolesArray(),
                                request.getContextPath(), messageSource, localeItemRepository, LocaleContextHolder.getLocale(), webAppProperties.getMenuComposerLocaleMode(), webAppProperties.getMenuDataStoreMode(), largeViewPort, editMode);
                        navData = menuToolBar.renderHtml(renderRoles);
                        
                    } else {

                        menuToolBar = MenuComposer.composeFromDatastore(navEntityMenus, userInfo == null ? null : userInfo.getAuthenticatedUser(), userInfo == null ? null : userInfo.getAuthenticatedRolesArray(),
                                request.getContextPath(), messageSource, localeItemRepository, LocaleContextHolder.getLocale(), webAppProperties.getMenuComposerLocaleMode(), webAppProperties.getMenuDataStoreMode(), largeViewPort, editMode);
                        navData = menuToolBar.renderHtml(renderRoles);
                        session.setAttribute("navData", navData);
                    }

                    if (menuToolBar == null) {

                        menuToolBar = MenuComposer.composeFromDatastore(navEntityMenus, userInfo == null ? null : userInfo.getAuthenticatedUser(), userInfo == null ? null : userInfo.getAuthenticatedRolesArray(),
                                request.getContextPath(), messageSource, localeItemRepository, LocaleContextHolder.getLocale(), webAppProperties.getMenuComposerLocaleMode(), webAppProperties.getMenuDataStoreMode(), largeViewPort, editMode);
                        navData = menuToolBar.renderHtml(renderRoles);
                        session.setAttribute("navData", navData);
                    }
                }
            } else {

                if (recentUser == null) {
                    menuToolBar = MenuComposer.composeFromDatastore(navEntityMenus, userInfo == null ? null : userInfo.getAuthenticatedUser(), userInfo == null ? null : userInfo.getAuthenticatedRolesArray(),
                            request.getContextPath(), messageSource, localeItemRepository, LocaleContextHolder.getLocale(), webAppProperties.getMenuComposerLocaleMode(), webAppProperties.getMenuDataStoreMode(), largeViewPort, editMode);
                    navData = menuToolBar.renderHtml(renderRoles);
                    session.setAttribute("navData", navData);
                } else {
                    if (userInfo.equals(recentUser)) {
                        if (locale.getLanguage().equals(new Locale(languageCode).getLanguage())) {
                            //remarked for testing should be restored in final build.
                            //navData = (String) session.getAttribute("navData");

                            //following should be removed/remarked in final build.
                            menuToolBar = MenuComposer.composeFromDatastore(navEntityMenus, userInfo == null ? null : userInfo.getAuthenticatedUser(), userInfo == null ? null : userInfo.getAuthenticatedRolesArray(),
                                request.getContextPath(), messageSource, localeItemRepository, LocaleContextHolder.getLocale(), webAppProperties.getMenuComposerLocaleMode(), webAppProperties.getMenuDataStoreMode(), largeViewPort, editMode);
                            navData = menuToolBar.renderHtml(renderRoles);
                            
                        } else {
                            menuToolBar = MenuComposer.composeFromDatastore(navEntityMenus, userInfo == null ? null : userInfo.getAuthenticatedUser(), userInfo == null ? null : userInfo.getAuthenticatedRolesArray(),
                                    request.getContextPath(), messageSource, localeItemRepository, LocaleContextHolder.getLocale(), webAppProperties.getMenuComposerLocaleMode(), webAppProperties.getMenuDataStoreMode(), largeViewPort, editMode);
                            navData = menuToolBar.renderHtml(renderRoles);
                            session.setAttribute("navData", navData);
                        }
                    } else {
                        menuToolBar = MenuComposer.composeFromDatastore(navEntityMenus, userInfo == null ? null : userInfo.getAuthenticatedUser(), userInfo == null ? null : userInfo.getAuthenticatedRolesArray(),
                                request.getContextPath(), messageSource, localeItemRepository, LocaleContextHolder.getLocale(), webAppProperties.getMenuComposerLocaleMode(), webAppProperties.getMenuDataStoreMode(), largeViewPort, editMode);
                        navData = menuToolBar.renderHtml(renderRoles);
                        session.setAttribute("navData", navData);
                    }
                }
            }
        } catch (Exception ex) {
            logger.error(ex.getMessage());
        }

        session.setAttribute("languageCode", locale.getLanguage());
        session.setAttribute("recentUser", session.getAttribute("userInfo"));
        return navData;
    }
}