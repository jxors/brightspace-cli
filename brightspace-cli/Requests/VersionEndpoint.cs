using BrightspaceCli.Models.Version;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BrightspaceCli.Requests
{
    public class VersionEndpoint
    {
        public static Task<ProductVersion> GetSupportedVersions(Context context, string product)
            => context.Request<ProductVersion>(Resources.GetRoute(product, "versions", ""));
    }
}
