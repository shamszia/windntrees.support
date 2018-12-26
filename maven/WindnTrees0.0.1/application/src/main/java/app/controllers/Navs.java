/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package app.controllers;

import windntrees.BasicController;
import javax.validation.Valid;
import windntrees.data.WebAppProperties;
import app.configuration.SessionMenuComposer;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.i18n.LocaleContextHolder;
import org.springframework.http.HttpEntity;
import org.springframework.validation.Errors;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import windntrees.data.MenuFilter;
import controls.navs.content.LocaleItemRepository;
import controls.navs.content.NavigationMenuRepository;


/**
 *
 * @author shams
 */
@RestController
@RequestMapping(value = {"/navs"})
public class Navs extends BasicController {

    @Autowired
    NavigationMenuRepository navigationMenuRepository;

    @Autowired
    LocaleItemRepository localeItemRepository;

    @RequestMapping(value = "/load/{roles}/{editMode}/{largeViewPort}", method = RequestMethod.POST)
    public HttpEntity<String> loadMenu(@PathVariable String roles, @PathVariable Boolean editMode, @PathVariable Boolean largeViewPort) {
        try {
            WebAppProperties webAppProperties = getWebAppProperties();
            String navData = null;

            String[] renderRoles = null;
            if (roles != null) {
                if (!roles.isEmpty()) {
                    if (!roles.equals("null")) {
                        renderRoles = roles.split(",");
                    }
                }
            }

            if (webAppProperties.getMenuDataStoreMode()) {

                navData = SessionMenuComposer.composeFromDataStore(navigationMenuRepository.readByNullAppKey(), request,
                        session, LocaleContextHolder.getLocale(), messageSource, localeItemRepository, webAppProperties, largeViewPort, editMode, renderRoles);

            } else {

                navData = SessionMenuComposer.composeFromJson(new String[]{"/navigation.json", "/navigation-right.json"}, request,
                        session, LocaleContextHolder.getLocale(), messageSource, webAppProperties, largeViewPort, editMode, renderRoles);

            }
            return new HttpEntity(navData, getHtmlResponseHeaders());
        } catch (Exception ex) {
            logger.error(ex.getMessage());
        }
        return new HttpEntity("", getHtmlResponseHeaders());
    }

    @RequestMapping(value = "/load", method = RequestMethod.POST)
    public HttpEntity<String> loadMenuByFilter(
            @Valid @RequestBody MenuFilter menuFilter,
            Errors errors) {

        try {
            WebAppProperties webAppProperties = getWebAppProperties();
            String navData = null;

            String[] renderRoles = null;
            if (menuFilter.getRoles() != null) {
                if (!menuFilter.getRoles().isEmpty()) {
                    if (!menuFilter.getRoles().equals("null")) {
                        renderRoles = menuFilter.getRoles().split(",");
                    }
                }
            }

            if (webAppProperties.getMenuDataStoreMode()) {

                navData = SessionMenuComposer.composeFromDataStore(navigationMenuRepository.readByNullAppKey(), request,
                        session, LocaleContextHolder.getLocale(), messageSource, localeItemRepository, webAppProperties, menuFilter.getLargeViewPort(), menuFilter.getEditMode(), renderRoles);

            } else {

                navData = SessionMenuComposer.composeFromJson(new String[]{"/navigation.json", "/navigation-right.json"}, request,
                        session, LocaleContextHolder.getLocale(), messageSource, webAppProperties, menuFilter.getLargeViewPort(), menuFilter.getEditMode(), renderRoles);
            }
            
            return new HttpEntity(navData, getHtmlResponseHeaders());
        } catch (Exception ex) {
            logger.error(ex.getMessage());
        }
        return new HttpEntity("", getHtmlResponseHeaders());
    }

}
