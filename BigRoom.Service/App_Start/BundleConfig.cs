using System.Web.Optimization;

namespace BigRoom.Service
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Libraries/jQuery/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Libraries/knockoutjs/knockout-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
        }
    }
}