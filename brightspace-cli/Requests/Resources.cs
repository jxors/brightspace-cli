namespace BrightspaceCli.Requests
{
    public class Resources
    {
        public const string WhoAmIRoute = "/d2l/api/lp/" + LpVersion + "/users/whoami";

        public const string LpVersion = "1.20";
        public const string LeVersion = "1.28";
        public const string EpVersion = "2.5";

        public const string LpPlatform = "lp";
        public const string LePlatform = "le";
        public const string EpPlatform = "ep";

        public static string Lp(string resource) => GetRoute(LpPlatform, LpVersion, resource);

        public static string Le(string resource) => GetRoute(LePlatform, LeVersion, resource);

        public static string GetRoute(string platform, string version, string resource)
        {
            return $"/d2l/api/{platform}/{version}/{resource}";
        }
    }
}
