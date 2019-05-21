using System.Web;
using System.Web.Optimization;

namespace MvcApplication1
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
          /*  bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/assets//jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
                      */
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/assets/et-line-font-plugin/style.css",
                      "~/assets/tether/tether.min.css",
                      "~/assets/web/assets/mobirise-icons/mobirise-icons.css",
                      "~/assets/bootstrap-material-design-font/css/material.css",
                      "~/assets/theme/css/style.css",
                      "~/assets/bootstrap-material-design-font/css/material.css"));
        }
    }
}
