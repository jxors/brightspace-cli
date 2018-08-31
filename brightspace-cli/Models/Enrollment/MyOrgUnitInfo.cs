using System;
using System.Collections.Generic;

namespace BrightspaceCli.Models.Enrollment
{
    public class MyOrgUnitInfo
    {
        public List<OrgUnitInfo> OrgUnit { get; set; }

        public MyOrgUnitInfoAccess Access { get; set; }
    }

    public class MyOrgUnitInfoAccess
    {
        public bool IsActive { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool CanAccess { get; set; }

        public string ClasslistRoleName { get; set; }

        public List<string> LISRoles { get; set; }
    }
}
