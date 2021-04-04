using System.Web;
using System.Web.Optimization;

namespace POS
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/js/plugins.bundle.js",
                        "~/Scripts/js/prismjs.bundle.js",
                        "~/Scripts/js/scripts.bundle.js",
                        "~/Scripts/js/widgets.js",
                        "~/Scripts/js/fullcalendar.bundle.js",
                        "~/Scripts/js/datatables.bundle.js",
                        "~/Scripts/js/paginations.js",
                        "~/Scripts/js/toastr.js",
                        "~/Scripts/js/login-general.js"

                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/css/fullcalendar.bundle.css",
                        "~/Content/css/plugins.bundle.css",
                        "~/Content/css/prismjs.bundle.css",
                        "~/Content/css/style.bundle.css",
                        "~/Content/css/light.css",
                        "~/Content/css/light.menu.css",
                        "~/Content/css/dark.css",
                        "~/Content/css/dark.aside.css",
                        "~/Content/css/datatables.bundle.css",
                        "~/Content/css/fullcalendar.bundle.css",
                         "~/Content/css/login.css",
                         "~/Content/custom.css"

                      ));
        }
    }
}
