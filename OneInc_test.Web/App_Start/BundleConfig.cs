
using System.Web.Optimization;

namespace OneInc_test.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Assests/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Assests/Scripts/jquery.validate*"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Assests/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Assests/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/bundles/custom").Include(
                      "~/Assests/Scripts/custom.js"));
        }
    }
}
