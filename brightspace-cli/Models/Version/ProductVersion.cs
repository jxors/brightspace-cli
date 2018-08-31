using System;
using System.Collections.Generic;
using System.Text;

namespace BrightspaceCli.Models.Version
{
    public class ProductVersion
    {
        public string ProductCode { get; set; }

        public string LatestVersion { get; set; }

        public List<string> SupportedVersions { get; set; }

        public override string ToString()
        {
            return $"{ProductCode} {LatestVersion} ({string.Join(", ", SupportedVersions)})";
        }
    }
}
