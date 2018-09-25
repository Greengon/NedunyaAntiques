using System.Web;
using System.Web.Optimization;

namespace NedunyaAntiquesWebApp
{
    public class BundleConfig
    {

        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        // And also here is a great guide https://www.dotnettricks.com/learn/mvc/layouts-renderbody-rendersection-and-renderpage-in-aspnet-mvc
        public static void RegisterBundles(BundleCollection bundles)
        {
            /*
             * Styles.Render and Scripts.Render generate multiple style and script tags for each 
             * item in the CSS bundle and Script bundle when optimizations are disabled.
             * When optimizations are enabled, Styles.Render and Scripts.Render generate 
             * a single style and script tag to a version-stamped URL which represents the 
             * entire bundle for CSS and Scripts.
             * 
             * 
             * You can enable and disable optimizations by setting EnableOptimizations
             * property of BundleTable class to true or false with in Global.asax.cs file*/

            // Our bundels:
            // our scripts - BE careful order matter here , we still have problem here
            // TODO: find the right order of scripts loading
            bundles.Add(new ScriptBundle("~/bundles/Our-jqueryval").Include(
                     "~/Scripts/jquery-2.2.4.min.js",
                     "~/Scripts/jquery-3.3.1.min.js",
                     "~/Scripts/bootstrap.min.js",
                     "~/Scripts/bootstrap.js",
                     "~/Scripts/classy-nav.min.js",
                     "~/Scripts/popper.min.js",
                     "~/Scripts/plugins.js",
                     "~/Scripts/active.js",
                     "~/Scripts/global.js"
                ));

            // our css
            bundles.Add(new StyleBundle("~/bundles/our-css").Include(
          "~/Content/ourstyle.css",
          "~/Content/bootstrap.min.css",
          "~/Content/animate.css",
          "~/Content/bootstrap-rtl.css",
          "~/Content/classy-nav.min.css",
          "~/Content/core-style.css",
          "~/Content/core-style.css.map",
          "~/Content/font-awesome.min.css",
          "~/Content/jquery-ui.min.css",
          "~/Content/magnific-popup.css",
          "~/Content/nice-select.css",
          "~/Content/owl.carousel.css"
          ));

            // Bundle Optimization - minifize all scripts
            BundleTable.EnableOptimizations = false;

            // From here on there are pre made bundels by VS
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
