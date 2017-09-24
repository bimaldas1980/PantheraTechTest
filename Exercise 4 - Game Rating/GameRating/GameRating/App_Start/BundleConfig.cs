using System.Web;
using System.Web.Optimization;

namespace GameRating
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            ScriptBundle knockoutBundle = new ScriptBundle("~/bundles/knockout");
            knockoutBundle.Include(
                                "~/Scripts/knockout-3.4.2.js",
                                "~/Scripts/bootstrap-rating/bootstrap-rating.js",
                                "~/Scripts/ViewModels/GameRatingViewModel.js",
                              //   "~/Scripts/ViewModels/GameItemViewModel.js",
                                "~/Scripts/star-rating.js"
                              );
            bundles.Add(knockoutBundle);

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Styles/site.css",
                      "~/Content/site.css"));
        }
    }
}
