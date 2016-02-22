using System.Web;
using System.Web.Optimization;

namespace FYPTest
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/jszip.js",
                      "~/Scripts/pdfmake/pdfmake.min.js",
                      "~/Scripts/pdfmake/vfs_fonts.js",
                      "~/Scripts/David.js"));
            bundles.Add(new ScriptBundle("~/bundles/dataTablesJS").IncludeDirectory(
                     "~/Scripts/DataTables","*.js", true));
            bundles.Add(new ScriptBundle("~/bundles/dataTablesCSS").IncludeDirectory(
                     "~/Content/DataTables", "*.css", true));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/DataTables/css/*.css",
                      "~/Content/DataTables/images/*.png"
                      ));
        }
    }
}
