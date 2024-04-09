using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class AzureSettings
        
    {
       
        public string Instance { get; set; }
        public string ClientId { get; set; }
        public string TenantId { get; set; }
        public string? BatchSecretKey { get; set; }
        public string? ClientScope { get; set; }
    }
}
