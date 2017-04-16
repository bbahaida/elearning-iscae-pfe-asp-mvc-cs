using System.Web;
using System.Web.Optimization;

namespace ISCAE.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.2.3.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/user").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/fastclick.js",
                      "~/Scripts/app.min.js",
                      "~/Scripts/jquery.sparkline.min.js",
                      "~/Content/datatables/jquery.dataTables.min.js",
                      "~/Content/datatables/dataTables.bootstrap.min.js",
                      "~/Scripts/jquery.slimscroll.min.js",
                      "~/Scripts/pages/dashboard.js",
                      "~/Scripts/demo.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/home").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //var fontAwesome = "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css";
            //var ionIcons = "https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css";

            bundles.Add(new StyleBundle("~/Content/user").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/datatables/dataTables.bootstrap.css",
                      "~/Content/css/font-awesome.min.css",
                      //ionIcons,
                      "~/Content/AdminLTE.min.css",
                      "~/Content/skins/_all-skins.min.css"
                      ));
        }
    }
}
