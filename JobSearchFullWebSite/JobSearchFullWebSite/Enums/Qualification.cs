using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Enums
{
    public enum Qualification
    {
        [Description("Certificate")]
        Certificate,
        [Description("Associate")]
        Associate,
        [Description("Bachelor Degree")]
        BachelorDegree,
        [Description("Master Degree")]
        MasterDegree,
        [Description("Doctorate Degree")]
        DoctorateDegree
    }
}
