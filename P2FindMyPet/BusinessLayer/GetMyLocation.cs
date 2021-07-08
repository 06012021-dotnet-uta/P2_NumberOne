using DataLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.Extensions.Logging;
using RepostoryLayer;
using System.Globalization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace BusinessLayer
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
