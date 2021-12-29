using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriSecDBClientPanel.Model
{
    class LockDBAccountModel
    {
        public String SealedSessionID { get; set; }

        public String SealedDBUserName { get; set; }

        public String UniquePaymentID { get; set; }

        public String SignedRandomChallenge { get; set; }
    }
}
