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
                      "~/Scripts/respond.js",
                      "~/Scripts/app.min.js",
                      "~/Scripts/jquery.sparkline.min.js",
                      "~/Resources/Plugins/bootstrap3-wysihtml5.all.min.js",
                      "~/Scripts/jquery.slimscroll.min.js",
                      "~/Scripts/pages/dashboard.js",
                      "~/Scripts/demo.js"));

            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                      "~/Scripts/home/js/jquery.min.js",
                      "~/Scripts/home/js/jquery.easing.1.3.js",
                      "~/Scripts/home/js/jquery.waypoints.min.js",
                      "~/Scripts/home/js/jquery.stellar.min.js",
                      "~/Scripts/home/js/owl.carousel.min.js",
                      "~/Scripts/home/js/jquery.flexslider-min.js",
                      "~/Scripts/home/js/jquery.countTo.js",
                      "~/Scripts/home/js/jquery.magnific-popup.min.js",
                      "~/Scripts/home/js/magnific-popup-options.js",
                      "~/Scripts/home/js/simplyCountdown.js",
                      "~/Scripts/home/js/main.js",
                      "~/Scripts/home/js/bootstrap.min.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/home").Include(
                      "~/Content/home/css/animate.css",
                      "~/Content/home/css/icomoon.css",
                      "~/Content/home/css/bootstrap.css",
                      "~/Content/home/css/magnific-popup.css",
                      "~/Content/home/css/owl.carousel.min.css",
                      "~/Content/home/css/owl.theme.default.min.css",
                      "~/Content/home/css/flexslider.css",
                      "~/Content/home/css/pricing.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/home/css/style.css"
                      ));
            

            bundles.Add(new StyleBundle("~/Content/user").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Resources/Plugins/bootstrap3-wysihtml5.min.css",
                      //ionIcons,
                      "~/Content/AdminLTE.css",
                      "~/Content/skins/_all-skins.min.css"));
        }
    }
}
