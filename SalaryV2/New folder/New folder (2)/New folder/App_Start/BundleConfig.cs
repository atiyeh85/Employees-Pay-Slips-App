using System.Web;
using System.Web.Optimization;

namespace SalaryV2
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/modalform").Include(
                  "~/Scripts/modalform.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/jquery.dataTables.min.js",
                      "~/Scripts/dataTables.bootstrap.min.js",
                      "~/Scripts/dataTables.bootstrap4.min.js",
                      "~/Scripts/dataTables.buttons.min.js",
                      "~/Scripts/dataTables.responsive.min.js",
                      "~/Scripts/responsive.bootstrap.min.js",
                      "~/Scripts/buttons.print.min.js",
                        "~/Scripts/buttons.html5.min.js",
                      "~/Scripts/buttons.colVis.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                       "~/Content/buttons.dataTables.min.css",
                      "~/Content/dataTables.bootstrap.min.css",
                      "~/Content/responsive.dataTables.min.css",
                      "~/Content/responsive.bootstrap.min.css",
                        "~/Content/buttons.dataTables.min.css",
                      "~/Content/bootstrap-rtl.css",
                      "~/Content/site.css"));
        }
    }
}
