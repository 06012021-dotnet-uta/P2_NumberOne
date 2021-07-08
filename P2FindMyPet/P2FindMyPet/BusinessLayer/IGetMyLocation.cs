using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer
{
    public interface IGetMyLocation
    {
        string GetMyCoordinate(string ip);
    }
}
