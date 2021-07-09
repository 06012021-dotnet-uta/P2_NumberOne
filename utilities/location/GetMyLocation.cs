using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Globalization;
using Newtonsoft.Json;
using data_models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace utilities
{
    public class GetMyLocation :IGetMyLocation
    {
        //=====================to get the cliet IP Address==================================
        public  string  GetMyCoordinate(string ip)
        { 
        IpInfo ipInfo = new IpInfo();
        string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
        ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
        string myaddress = ipInfo.Loc;
            
            return myaddress;
        }
        //=====================End of  cliet IP Address==================================
    }
}
