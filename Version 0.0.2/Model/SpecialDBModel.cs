using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriSecDBClientPanel.Model
{
    class SpecialDBModel
    {
        public SealedDBCredentialModel MyDBCredentialModel { get; set; }

        public String UniquePaymentID { get; set; }

        public String Base64QueryString { get; set; }

        public String[] Base64ParameterName { get; set; }

        public String[] Base64ParameterValue { get; set; }

        public String[] IDValue { get; set; }

        public String[] NewIDValue { get; set; }

        public Boolean IsXSalsa20Poly1305 { get; set; }
    }
}
