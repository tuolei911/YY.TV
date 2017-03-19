using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Data
{
    public class ConnectionString
    {
        public static readonly string WTVDns = ConfigurationManager.ConnectionStrings["WTVDns"] != null ? ConfigurationManager.ConnectionStrings["WTVDns"].ConnectionString : string.Empty;
    }
}
