using BrightspaceCli.Models.OrgUnit;

namespace BrightspaceCli.Models.Enrollment
{
    public class OrgUnitInfo
    {
        public long Id { get; set; }

        public OrgUnitTypeInfo Type { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string HomeUrl { get; set; }

        public string ImageUrl { get; set; }
    }
}