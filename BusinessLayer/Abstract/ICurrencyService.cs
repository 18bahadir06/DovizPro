using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace BusinessLayer.Abstract
{
    public interface ICurrencyService
    {
        Task<JObject> GetRatesAsync();
        decimal trytousd(JObject data);
        decimal trytoeuro(JObject data);
    }
}
