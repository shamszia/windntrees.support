using System;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using Abstraction.Core.Notifiers;
using Microsoft.AspNetCore.Html;

namespace Controls.Core.Navs
{
    public class NavigationComposer
    {
        public static event Notifications notifications;

        public static void notify(String message)
        {
            if (notifications != null)
            {
                notifications(message, null);
            }
        }

        public static void compose(String requestedAddress, String localeCode)
        {

            NavigationContent navContainer = new NavigationContent(localeCode);

            Navigation leftNav = new Navigation(requestedAddress, navContainer);

            leftNav.addComponent(new NavigationItem(null, "HOME", "home", "active", null, "index", null, null));
            leftNav.addComponent(new NavigationItem(null, "PRODUCTS", "products", null, "products", null));
            leftNav.addComponent(new NavigationItem(null, "NEWS", "news", null, "news", null));
            leftNav.addComponent(new NavigationItem(null, "CONTACT", "contact", null, "contact", null));

            NavigationItem subNavigationApplication = new NavigationItem(null, "APPLICATION", "application", "dropdown", null, "#", null, null, leftNav);
            subNavigationApplication.addComponent(new NavigationItem(null, "NEW SALE", "new sale", null, "/client/store/sale", null));
            subNavigationApplication.addComponent(new NavigationItem(null, "NEW PURCHASE", "new purchase", null, "/client/store/purchase", null));
            subNavigationApplication.addComponent(new NavigationItem(null, null, null, "divider", null, null, null, null));
            subNavigationApplication.addComponent(new NavigationItem(null, "TRANSACTIONS", "transactions", null, "/client/store/index", null));
            subNavigationApplication.addComponent(new NavigationItem(null, null, null, "divider", null, null, null, null));
            subNavigationApplication.addComponent(new NavigationItem(null, "PRODUCTS", "products", null, "/client/product/index", null));
            subNavigationApplication.addComponent(new NavigationItem(null, null, null, "divider", null, null, null, null));
            subNavigationApplication.addComponent(new NavigationItem(null, "CUSTOMERS", "customers", null, "/client/customer/index", null));
            leftNav.addComponent(subNavigationApplication);

            NavigationItem subNavigationLists = new NavigationItem(null, "LISTS", "lists", "dropdown", null, "#", null, null, leftNav);
            subNavigationLists.addComponent(new NavigationItem(null, "MANUFACTURERS", "manufacturers", null, "/client/manufacturer/index", null));
            subNavigationLists.addComponent(new NavigationItem(null, null, null, "divider", null, null, null, null));
            subNavigationLists.addComponent(new NavigationItem(null, "CATEGORIES", "categories", null, "/client/category/index", null));
            subNavigationLists.addComponent(new NavigationItem(null, null, null, "divider", null, null, null, null));
            subNavigationLists.addComponent(new NavigationItem(null, "COLORS", "colors", null, "/client/color/index", null));
            subNavigationLists.addComponent(new NavigationItem(null, null, null, "divider", null, null, null, null));
            subNavigationLists.addComponent(new NavigationItem(null, "UNITS", "units", null, "/client/unit/index", null));
            subNavigationLists.addComponent(new NavigationItem(null, null, null, "divider", null, null, null, null));
            subNavigationLists.addComponent(new NavigationItem(null, "INSTALLMENTS", "installments", null, "/client/installmenttype/index", null));
            leftNav.addComponent(subNavigationLists);

            NavigationItem subNavigationReports = new NavigationItem(null, "REPORTS", "reports", "dropdown", null, "#", null, null, leftNav);
            subNavigationReports.addComponent(new NavigationItem(null, "TRANSACTIONS", "transactions", null, "/client/report/index", null));
            subNavigationReports.addComponent(new NavigationItem(null, null, null, "divider", null, null, null, null));
            subNavigationReports.addComponent(new NavigationItem(null, "CASH", "CASH", null, "/client/report/cash", null));
            subNavigationReports.addComponent(new NavigationItem(null, null, null, "divider", null, null, null, null));
            subNavigationReports.addComponent(new NavigationItem(null, "CREDIT", "credit", null, "/client/report/credit", null));
            subNavigationReports.addComponent(new NavigationItem(null, null, null, "divider", null, null, null, null));
            subNavigationReports.addComponent(new NavigationItem(null, "INVENTORY", "inventory", null, "/client/report/inventory", null));
            subNavigationReports.addComponent(new NavigationItem(null, null, null, "divider", null, null, null, null));
            subNavigationReports.addComponent(new NavigationItem(null, "PURCHASES", "purchases", null, "/client/report/purchases", null));
            subNavigationReports.addComponent(new NavigationItem(null, null, null, "divider", null, null, null, null));
            subNavigationReports.addComponent(new NavigationItem(null, "SALES", "sales", null, "/client/report/sales", null));
            subNavigationReports.addComponent(new NavigationItem(null, null, null, "divider", null, null, null, null));
            subNavigationReports.addComponent(new NavigationItem(null, "INCOME", "income", null, "/client/report/income", null));
            subNavigationReports.addComponent(new NavigationItem(null, null, null, "divider", null, null, null, null));
            subNavigationReports.addComponent(new NavigationItem(null, "CUSTOMERS", "customers", null, "/client/report/customers", null));
            leftNav.addComponent(subNavigationReports);

            NavigationItem subNavigationLanguage = new NavigationItem(null, "LANGUAGE", "language", "dropdown", null, "#", null, null, leftNav);
            subNavigationLanguage.addComponent(new NavigationItem(null, "ENGLISH", "english", null, "?locale=en", null));
            subNavigationLanguage.addComponent(new NavigationItem(null, null, null, "divider", null, null, null, null));
            subNavigationLanguage.addComponent(new NavigationItem(null, "URDU", "udru", null, "?locale=ur", null));
            leftNav.addComponent(subNavigationLanguage);

            NavigationItem subNavigationHelp = new NavigationItem(null, "HELP", "help", "dropdown", null, "#", null, null, leftNav);
            subNavigationHelp.addComponent(new NavigationItem(null, "MANUAL", "manual", null, "/help/index", null));
            subNavigationHelp.addComponent(new NavigationItem(null, null, null, "divider", null, null, null, null));
            subNavigationHelp.addComponent(new NavigationItem(null, "ABOUT", "about", null, "/help/about", null));
            leftNav.addComponent(subNavigationHelp);

            String formHtml = "<div class=\"form-group\">\n" +
                    "<input type=\"text\" class=\"form-control\" placeholder=\"Search\">\n" +
                    "</div>\n" +
                    "<button type=\"submit\" class=\"btn btn-default\">Submit</button>";

            Element form = new Element("form", formHtml, "navbar-form navbar-left");
            form.setHtmlMode(true);

            Navigation rightNavNavigation = new Navigation(requestedAddress, navContainer, "nav navbar-nav navbar-right");
            NavigationItem subNavigationAccount = new NavigationItem(null, "MY ACCOUNT", "my account", "dropdown", null, "#", null, null, rightNavNavigation);
            subNavigationAccount.addComponent(new NavigationItem(null, "HISTORY", "history", null, "/client/account/index", null));
            subNavigationAccount.addComponent(new NavigationItem(null, null, null, "divider", null, null, null, null));
            subNavigationAccount.addComponent(new NavigationItem(null, "SETTINGS", "settnigs", null, "/client/account/pronavigation", null));
            subNavigationAccount.addComponent(new NavigationItem(null, null, null, "divider", null, null, null, null));
            subNavigationAccount.addComponent(new NavigationItem(null, "SIGN OUT", "sign out", null, "/signout", null));
            rightNavNavigation.addComponent(subNavigationAccount);

            rightNavNavigation.addComponent(new NavigationItem(null, "SIGN IN", "sign in", null, null, "/signin", null, null));

            navContainer.addComponent(leftNav);
            navContainer.addComponent(form);
            navContainer.addComponent(rightNavNavigation);
        }

        public static HtmlString composePathNavigation(String path, String cssClass = "breadcrumb", string listItemCssClass = "breadcrumb-item", String version = "4.0")
        {
            // /pathpart1/pathpart2/pathpart3

            string pathList = "<ol class='{0}'>{1}</ol>";
            string items = string.Empty;

            string listItemFormat = "<li class='{0}'>{1}</li>";
            string listItemLinkFormat = "<li class='{0}'><a href='{1}' title='{2}'>{3}</a></li>";
            if (!String.IsNullOrEmpty(path))
            {
                if (path.StartsWith("/"))
                {
                    path = path.Remove(0, 1);
                }

                string[] pathTokens = path.Split(new char[] { '/' });

                string currentPath = string.Empty;
                for (int i = 0; i < pathTokens.Length; i++)
                {
                    currentPath += "/" + pathTokens[i];

                    if (i == (pathTokens.Length - 1))
                    {
                        items += string.Format(listItemFormat, listItemCssClass, pathTokens[i]);
                    }
                    else
                    {
                        items += string.Format(listItemLinkFormat, listItemCssClass, currentPath, pathTokens[i], pathTokens[i]);
                    }
                }
            }

            pathList = string.Format(pathList, cssClass, items);

            return new HtmlString(pathList);
        }

        public static HtmlString composeFromJson(String[] navigations, String authorizedUser, String[] authorizedRoles, String[] renderingRoles, String requestedAddress,
                String localeCode, Boolean largeViewPort, Boolean editMode, String version = "4.0")
        {
            string nav = NavigationComposer.composeFromJson(navigations, authorizedUser, authorizedRoles, requestedAddress,
                localeCode, largeViewPort, editMode, version).renderHtml(renderingRoles);

            return new HtmlString(nav);
        }

        /// <summary>
        /// Composes Menubar based on json files.
        /// </summary>
        /// <param name="navigations">Strings array defining physical path to .json files.</param>
        /// <param name="authorizedUser">Authorized username.</param>
        /// <param name="authorizedRoles">Authorized roles.</param>
        /// <param name="requestedAddress">Host address context path.</param>
        /// <param name="localeCode">Locale code.</param>
        /// <param name="largeViewPort">View port identification boolean value.</param>
        /// <param name="editMode">True value tells that the nav is to be rendered in edit mode.</param>
        /// <returns></returns>
        public static NavigationContent composeFromJson(String[] navigations, String authorizedUser, String[] authorizedRoles, String requestedAddress,
                String localeCode, Boolean largeViewPort, Boolean editMode, String version = "4.0")
        {
            NavigationContent navContainer = new NavigationContent(localeCode, version);
            navContainer.setBaseUriAndParentElement(requestedAddress, null);
            navContainer.setAuthenticatedUser(authorizedUser);
            navContainer.setAuthenticatedRoles(authorizedRoles);
            navContainer.setEditMode(editMode);
            
            try
            {   
                foreach (String navigation in navigations)
                {
                    Navigation nav = null;
                    try
                    {
                        string result = string.Empty;
                        using (System.IO.StreamReader streamReader = new System.IO.StreamReader(navigation))
                        {
                            result = streamReader.ReadToEnd();
                            streamReader.Close();
                            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Navigation));
                            nav = (Navigation)jsonSerializer.ReadObject(new MemoryStream(UTF8Encoding.UTF8.GetBytes(result)));
                        }

                        //nav.setAuthorizedUsersViaString(nav.getUsers());
                        //nav.setAuthorizedRolesViaString(nav.getRoles());

                        //initializes deserialized object
                        nav.initialize();
                        //ensure composer version of navigation.
                        nav.setVersion(version);

                        nav.setAuthenticatedUser(authorizedUser);
                        nav.setAuthenticatedRoles(authorizedRoles);
                        nav.setEditMode(editMode);

                        nav.setBaseUriAndParentElement(requestedAddress, navContainer);
                        navContainer.addComponent(nav);
                    }
                    catch (Exception ex)
                    {
                        notify(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                notify(ex.Message);
            }
            return navContainer;
        }

        /*
        public static MenuBar composeFromDatastore(Iterable<NavigationMenu> navEntityMenus, String authorizedUser, String[] authorizedRoles, String requestedAddress, 
            String localeCode, Boolean largeViewPort, Boolean editMode)
        {

            //return NavigationMenuAdapter.createEntityMenuBar(navEntityMenus, authorizedUser, authorizedRoles, requestedAddress, messageSource, localeItemRepository, locale, localeMode, dataStoreMode, largeViewPort, editMode);
            return null;
        }*/
    }
}
