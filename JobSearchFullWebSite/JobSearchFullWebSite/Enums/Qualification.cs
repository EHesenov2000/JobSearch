using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
        Bachelor_Degree,
        [Description("Master Degree")]
        Master_Degree,
        [Description("Doctorate Degree")]
        Doctorate_Degree
    }

}
