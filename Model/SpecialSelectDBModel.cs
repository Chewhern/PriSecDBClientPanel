using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriSecDBClientPanel.Model
{
    class SpecialSelectDBModel
    {
        public SealedDBCredentialModel MyDBCredentialModel { get; set; }

        public String UniquePaymentID { get; set; }

        public String Base64QueryString { get; set; }

        public String[] Base64ParameterName { get; set; }

        public String[] Base64ParameterValue { get; set; }
    }
}
