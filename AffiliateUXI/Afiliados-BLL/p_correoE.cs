using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AffiliateUXI.Afiliados_BLL
{
    public class p_correoE
    {
        public string sFrom { get; set; }
        public string sToCC { get; set; }
        public string sTo { get; set; }
        public string sSubject { get; set; }
        public string sBody { get; set; }
        public string sPathFile { get; set; }
        public string result { get; set; }
        public p_correoE()
        {
            this.sFrom = "noreply@uxisolutions.com";
        }
    }
}
