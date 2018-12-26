using System.Web;
using System.Web.Optimization;

namespace Application
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryform").Include(
                        "~/scripts/jquery.form.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/knockoutjs").Include(
                "~/scripts/knockout-{version}.js",
                "~/scripts/knockout.validation.js"));

            /*
             * Application javascript library.
             * 
             * */
            //#region Application
            //bundles.Add(new ScriptBundle("~/bundles/windntrees").Include(
            //    "~/scripts/windntrees/ArrayProcessor.js",
            //    "~/scripts/windntrees/CRUDController.js",
            //    "~/scripts/windntrees/CRUDProcessor.js",
            //    "~/scripts/windntrees/DateParser.js",
            //    "~/scripts/windntrees/FlexObject.js",
            //    "~/scripts/windntrees/InstanceExtender.js",
            //    "~/scripts/windntrees/LocaleMessage.js",
            //    "~/scripts/windntrees/Repository.js",
            //    "~/scripts/windntrees/Util.js",
            //    "~/scripts/windntrees/observers/ActivityObserver.js",
            //    "~/scripts/windntrees/observers/CRUDObserver.js",
            //    "~/scripts/windntrees/observers/DetailObserver.js",
            //    "~/scripts/windntrees/observers/ListObserver.js",
            //    "~/scripts/windntrees/observers/ObjectObserver.js",
            //    "~/scripts/windntrees/observers/SearchObserver.js",
            //    "~/scripts/windntrees/observers/kn/ActivityKNObserver.js",
            //    "~/scripts/windntrees/observers/kn/CRUDKNObserver.js",
            //    "~/scripts/windntrees/observers/kn/DetailKNObserver.js",
            //    "~/scripts/windntrees/observers/kn/ListKNObserver.js",
            //    "~/scripts/windntrees/observers/kn/ObjectKNObserver.js",
            //    "~/scripts/windntrees/observers/kn/SearchKNObserver.js",
            //    "~/scripts/windntrees/views/Alternator.js",
            //    "~/scripts/windntrees/views/Common.js",
            //    "~/scripts/windntrees/views/CRUDSList.js",
            //    "~/scripts/windntrees/views/ListNavigator.js",
            //    "~/scripts/windntrees/views/ObjectView.js",
            //    "~/scripts/windntrees/views/object/CRUDRelatedView.js",
            //    "~/scripts/windntrees/views/object/CRUDView.js",
            //    "~/scripts/windntrees/views/object/EditView.js",
            //    "~/scripts/windntrees/views/object/NewView.js",
            //    "~/scripts/windntrees/views/object/SearchList.js",
            //    "~/scripts/windntrees/views/object/SearchView.js",
            //    "~/scripts/windntrees/views/html/AVView.js",
            //    "~/scripts/windntrees/views/html/ContentList.js",
            //    "~/scripts/windntrees/views/html/FlexHTML.js",
            //    "~/scripts/windntrees/views/html/FlexView.js",
            //    "~/scripts/windntrees/views/html/ImageView.js",
            //    "~/scripts/windntrees/views/html/TextView.js"));
            //#endregion

            /*
             * Default native bundles and styles refers to
             * ~/Scripts, ~/Fonts and ~/Content folder root items.
             * Dependent items include ~/Shared/DisplayTemplates for
             * Navigation and Menus
             * */
            #region NativeBundlesAndStyles
            bundles.Add(new ScriptBundle("~/bundles/native/header").Include(
                        "~/scripts/respond.min.js"));

            bundles.Add(new StyleBundle("~/content/native/bootstrap").Include(
                "~/content/jquery-ui.css",
                "~/content/jquery-ui.structure.css",
                "~/content/jquery-ui.theme.css",
                "~/content/bootstrap.min.css",
                "~/content/bootstrap-theme.css",
                "~/content/bootstrap-grid.min.css",
                "~/content/bootstrap-grid-fix.min.css",
                "~/content/bootstrap.min.css",
                "~/content/extensions/font-awesome.min.css",
                "~/content/extensions/datepicker3.css"));

            bundles.Add(new StyleBundle("~/content/native/fonts").Include(
                "~/content/fonts/fontawesome-webfont.eot",
                "~/content/fonts/fontawesome-webfont.svg",
                "~/content/fonts/fontawesome-webfont.ttf",
                "~/content/fonts/fontawesome-webfont.woff",
                "~/content/fonts/fontawesome-webfont.woff2",
                "~/content/fonts/glyphicons-halflings-regular.eot",
                "~/content/fonts/glyphicons-halflings-regular.svg",
                "~/content/fonts/glyphicons-halflings-regular.ttf",
                "~/content/fonts/glyphicons-halflings-regular.woff",
                "~/content/fonts/glyphicons-halflings-regular.woff2"));

            bundles.Add(new ScriptBundle("~/bundles/native/bootstrap").Include(
                "~/scripts/jquery-{version}.js",
                "~/scripts/jquery.form.js",
                "~/scripts/jquery-ui-{version}.js",
                "~/scripts/datejs.js",
                "~/scripts/popper.min.js",
                "~/scripts/popper-utils.min.js",
                "~/scripts/bootstrap.min.js",
                "~/scripts/underscore.min.js",
                "~/scripts/moment.min.js",
                "~/scripts/bootstrap-datepicker.js",
                "~/scripts/bootstrap-timepicker.js",
                "~/scripts/knockout-{version}.js",
                "~/scripts/knockout.validation.js"));


            bundles.Add(new StyleBundle("~/content/native/styles").Include("~/content/bootstrap-grid-fix.css", "~/content/extensions/native-styles.css"));
            bundles.Add(new StyleBundle("~/content/native/carousel").Include("~/content/extensions/native-carousel.css"));
            #endregion
        }
    }
}
