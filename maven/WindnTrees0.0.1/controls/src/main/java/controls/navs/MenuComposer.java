/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template navigation, choose Tools | Templates
 * and open the template in the editor.
 */
package controls.navs;

import com.fasterxml.jackson.databind.DeserializationFeature;
import com.fasterxml.jackson.databind.ObjectMapper;
import controls.navs.content.NavigationMenu;
import controls.navs.content.NavigationMenuAdapter;
import java.util.Locale;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.context.support.ReloadableResourceBundleMessageSource;
import org.springframework.core.io.ClassPathResource;
import controls.navs.content.LocaleItemRepository;

/**
 *
 * @author shams
 */
public class MenuComposer {

    private static final Logger logger = LoggerFactory
            .getLogger(MenuComposer.class);
    
    public static void compose(String requestedAddress,
            ReloadableResourceBundleMessageSource messageSource,
            Locale locale, Boolean localeMode, Boolean dataStoreMode) {
        
        MenuBar menuBar = new MenuBar(messageSource, locale, localeMode, dataStoreMode);

        Menu leftNavMenu = new Menu(requestedAddress, menuBar);
        leftNavMenu.addComponent(new MenuItem(null, "menu.home.text", "menu.home.desc", "active", null, "index", null, null));
        leftNavMenu.addComponent(new MenuItem(null, "menu.products.text", "menu.products.desc", null, "products", null));
        leftNavMenu.addComponent(new MenuItem(null, "menu.news.text", "menu.news.desc", null, "news", null));
        leftNavMenu.addComponent(new MenuItem(null, "menu.contact.text", "menu.contact.desc", null, "contact", null));
         
        MenuItem subMenuApplication = new MenuItem(null, "menu.myApplication.text", "menu.myApplication.desc", "dropdown", null, "#", null, null, leftNavMenu);
        subMenuApplication.addComponent(new MenuItem(null, "menu.myNewSale.text", "menu.myNewSale.desc", null, "/client/store/sale", null));
        subMenuApplication.addComponent(new MenuItem(null, "menu.myNewPurchase.text", "menu.myNewPurchase.desc", null, "/client/store/purchase", null));
        subMenuApplication.addComponent(new MenuItem(null, null, null, "divider", null, null, null, null));
        subMenuApplication.addComponent(new MenuItem(null, "menu.myTransactions.text", "menu.myTransactions.desc", null, "/client/store/index", null));
        subMenuApplication.addComponent(new MenuItem(null, null, null, "divider", null, null, null, null));
        subMenuApplication.addComponent(new MenuItem(null, "menu.myProducts.text", "menu.myProducts.desc", null, "/client/product/index", null));
        subMenuApplication.addComponent(new MenuItem(null, null, null, "divider", null, null, null, null));
        subMenuApplication.addComponent(new MenuItem(null, "menu.myCustomers.text", "menu.myCustomers.desc", null, "/client/customer/index", null));
        leftNavMenu.addComponent(subMenuApplication);

        MenuItem subMenuLists = new MenuItem(null, "menu.myLists.text", "menu.myLists.desc", "dropdown", null, "#", null, null, leftNavMenu);
        subMenuLists.addComponent(new MenuItem(null, "menu.myManufacturers.text", "menu.myManufacturers.desc", null, "/client/manufacturer/index", null));
        subMenuLists.addComponent(new MenuItem(null, null, null, "divider", null, null, null, null));
        subMenuLists.addComponent(new MenuItem(null, "menu.myCategories.text", "menu.myCategories.desc", null, "/client/category/index", null));
        subMenuLists.addComponent(new MenuItem(null, null, null, "divider", null, null, null, null));
        subMenuLists.addComponent(new MenuItem(null, "menu.myColors.text", "menu.myColors.desc", null, "/client/color/index", null));
        subMenuLists.addComponent(new MenuItem(null, null, null, "divider", null, null, null, null));
        subMenuLists.addComponent(new MenuItem(null, "menu.myUnits.text", "menu.myUnits.desc", null, "/client/unit/index", null));
        subMenuLists.addComponent(new MenuItem(null, null, null, "divider", null, null, null, null));
        subMenuLists.addComponent(new MenuItem(null, "menu.myInstallments.text", "menu.myInstallments.desc", null, "/client/installmenttype/index", null));
        leftNavMenu.addComponent(subMenuLists);

        MenuItem subMenuReports = new MenuItem(null, "menu.myReports.text", "menu.myReports.desc", "dropdown", null, "#", null, null, leftNavMenu);
        subMenuReports.addComponent(new MenuItem(null, "menu.myReportTransactions.text", "menu.myReportTransactions.desc", null, "/client/report/index", null));
        subMenuReports.addComponent(new MenuItem(null, null, null, "divider", null, null, null, null));
        subMenuReports.addComponent(new MenuItem(null, "menu.myReportCash.text", "menu.myReportCash.desc", null, "/client/report/cash", null));
        subMenuReports.addComponent(new MenuItem(null, null, null, "divider", null, null, null, null));
        subMenuReports.addComponent(new MenuItem(null, "menu.myReportCredit.text", "menu.myReportCredit.desc", null, "/client/report/credit", null));
        subMenuReports.addComponent(new MenuItem(null, null, null, "divider", null, null, null, null));
        subMenuReports.addComponent(new MenuItem(null, "menu.myReportInventory.text", "menu.myReportInventory.desc", null, "/client/report/inventory", null));
        subMenuReports.addComponent(new MenuItem(null, null, null, "divider", null, null, null, null));
        subMenuReports.addComponent(new MenuItem(null, "menu.myReportPurchases.text", "menu.myReportPurchases.desc", null, "/client/report/purchases", null));
        subMenuReports.addComponent(new MenuItem(null, null, null, "divider", null, null, null, null));
        subMenuReports.addComponent(new MenuItem(null, "menu.myReportSales.text", "menu.myReportSales.desc", null, "/client/report/sales", null));
        subMenuReports.addComponent(new MenuItem(null, null, null, "divider", null, null, null, null));
        subMenuReports.addComponent(new MenuItem(null, "menu.myReportIncome.text", "menu.myReportIncome.desc", null, "/client/report/income", null));
        subMenuReports.addComponent(new MenuItem(null, null, null, "divider", null, null, null, null));
        subMenuReports.addComponent(new MenuItem(null, "menu.myReportCustomers.text", "menu.myReportCustomers.desc", null, "/client/report/customers", null));
        leftNavMenu.addComponent(subMenuReports);

        MenuItem subMenuLanguage = new MenuItem(null, "menu.language.text", "menu.language.desc", "dropdown", null, "#", null, null, leftNavMenu);
        subMenuLanguage.addComponent(new MenuItem(null, "menu.languageEnglish.text", "menu.languageEnglish.desc", null, "?locale=en", null));
        subMenuLanguage.addComponent(new MenuItem(null, null, null, "divider", null, null, null, null));
        subMenuLanguage.addComponent(new MenuItem(null, "menu.languageUrdu.text", "menu.languageUrdu.desc", null, "?locale=ur", null));
        leftNavMenu.addComponent(subMenuLanguage);

        MenuItem subMenuHelp = new MenuItem(null, "menu.help.text", "menu.help.desc", "dropdown", null, "#", null, null, leftNavMenu);
        subMenuHelp.addComponent(new MenuItem(null, "menu.helpManual.text", "menu.helpManual.desc", null, "/help/index", null));
        subMenuHelp.addComponent(new MenuItem(null, null, null, "divider", null, null, null, null));
        subMenuHelp.addComponent(new MenuItem(null, "menu.helpAbout.text", "menu.helpAbout.desc", null, "/help/about", null));
        leftNavMenu.addComponent(subMenuHelp);
        
        String formHtml = "<div class=\"form-group\">\n" +
                "<input type=\"text\" class=\"form-control\" placeholder=\"Search\">\n" +
                "</div>\n" +
                "<button type=\"submit\" class=\"btn btn-default\">Submit</button>";
        
        Element form = new Element("form", formHtml, "navbar-form navbar-left");
        form.setHtmlMode(true);
        
        Menu rightNavMenu = new Menu(requestedAddress, menuBar, "nav navbar-nav navbar-right");
        MenuItem subMenuAccount = new MenuItem(null, "menu.myAccount.text", "menu.myAccount.desc", "dropdown", null, "#", null, null, rightNavMenu);
        subMenuAccount.addComponent(new MenuItem(null, "menu.myAccountHistory.text", "menu.myAccountHistory.desc", null, "/client/account/index", null));
        subMenuAccount.addComponent(new MenuItem(null, null, null, "divider", null, null, null, null));
        subMenuAccount.addComponent(new MenuItem(null, "menu.myAccountPronavigation.text", "menu.myAccountPronavigation.desc", null, "/client/account/pronavigation", null));
        subMenuAccount.addComponent(new MenuItem(null, null, null, "divider", null, null, null, null));
        subMenuAccount.addComponent(new MenuItem(null, "menu.signOut.text", "menu.signOut.desc", null, "/signout", null));
        rightNavMenu.addComponent(subMenuAccount);

        rightNavMenu.addComponent(new MenuItem(null, "menu.signIn.text", "menu.signIn.desc", null, null, "/signin", null, null));

        menuBar.addComponent(leftNavMenu);
        menuBar.addComponent(form);
        menuBar.addComponent(rightNavMenu);
    }

    public static MenuBar composeFromJson(String navigations[], String authorizedUser, String authorizedRoles[], String requestedAddress,
            ReloadableResourceBundleMessageSource messageSource,
            Locale locale, Boolean localeMode, Boolean dataStoreMode, Boolean largeViewPort, Boolean editMode) {
        
        ObjectMapper objectParser = new ObjectMapper();
        objectParser.enable(DeserializationFeature.ACCEPT_EMPTY_ARRAY_AS_NULL_OBJECT);
        objectParser.enable(DeserializationFeature.ACCEPT_EMPTY_STRING_AS_NULL_OBJECT);
        objectParser.enable(DeserializationFeature.ACCEPT_SINGLE_VALUE_AS_ARRAY);

        MenuBar menuBar = new MenuBar(messageSource, locale, localeMode, dataStoreMode);
        menuBar.setBaseUriAndParentElement(requestedAddress, null);
        menuBar.setAuthenticatedUser(authorizedUser);
        menuBar.setAuthenticatedRoles(authorizedRoles);
        menuBar.setEditMode(editMode);

        Menu menu = null;
        try {

            for (String navigation : navigations) {
                menu = objectParser.readValue(new ClassPathResource(navigation).getInputStream(), Menu.class);
                menu.setAuthenticatedUser(authorizedUser);
                menu.setAuthenticatedRoles(authorizedRoles);
                menu.setEditMode(editMode);
                
                if (menu != null) {
                    menu.setBaseUriAndParentElement(requestedAddress, menuBar);

                    if (menu.getCssClass() != null) {

                        if (!menu.getCssClass().isEmpty()) {

                            menu.getAttributes().clear();
                            menu.addElementAttribute(new ItemAttribute("class", menu.getCssClass()));
                        }
                    } else {

                        if (navigation.endsWith(".json")) {
                            String navigationName = navigation.replace(".json", "");
                            if (navigationName.endsWith("left")) {

                                menu.setElementType(ElementType.MenuLeft);
                                menu.getAttributes().clear();

                                if (menu.getVersion().equals("4.0")) {

                                    menu.addElementAttribute(new ItemAttribute("class", "navbar-nav container-fluid d-flex justify-content-start p-0"));
                                } else {

                                    menu.addElementAttribute(new ItemAttribute("class", "nav navbar-nav navbar-left"));
                                }
                            } else if (navigationName.endsWith("right")) {

                                menu.setElementType(ElementType.MenuRight);
                                menu.getAttributes().clear();

                                if (menu.getVersion().equals("4.0")) {

                                    menu.addElementAttribute(new ItemAttribute("class", "navbar-nav container-fluid d-flex justify-content-end p-0"));
                                } else {

                                    menu.addElementAttribute(new ItemAttribute("class", "nav navbar-nav navbar-right"));
                                }

                            } else {

                                menu.setElementType(ElementType.MenuLeft);
                                menu.getAttributes().clear();

                                if (menu.getVersion().equals("4.0")) {

                                    menu.addElementAttribute(new ItemAttribute("class", "navbar-nav container-fluid d-flex justify-content-start p-0"));
                                } else {

                                    menu.addElementAttribute(new ItemAttribute("class", "nav navbar-nav navbar-left"));
                                }
                            }
                        }
                    }
                }
                menuBar.addComponent(menu);
            }

        } catch (Exception ex) {
            logger.error(ex.getMessage());
        }
        return menuBar;
    }
    
    public static MenuBar composeFromDatastore(Iterable<NavigationMenu> navEntityMenus, String authorizedUser, String authorizedRoles[], String requestedAddress, ReloadableResourceBundleMessageSource messageSource, 
            LocaleItemRepository localeItemRepository,
            Locale locale, Boolean localeMode, Boolean dataStoreMode, Boolean largeViewPort, Boolean editMode) {
        
        return NavigationMenuAdapter.createEntityMenuBar(navEntityMenus, authorizedUser, authorizedRoles, requestedAddress, messageSource, localeItemRepository, locale, localeMode, dataStoreMode, largeViewPort, editMode);
    }
}
