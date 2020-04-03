using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeedService.Extensions
{
    public class AzureAdB2COptions
    {
        public string ClientId { get; set; }
        public string Instance { get; set; }
        public string Domain { get; set; }
        public string SignUpSignInPolicyId { get; set; }
    }
}
