using BusinessLayer.Concrete;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DovizPro.Controllers
{
    public class HomeController : AsyncController //async controller async metodlar için özel tasarlanmış controller
    {
        // GET: Home
        CurrencyApiManager cm=new CurrencyApiManager();
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var a =await cm.GetRatesAsync();
            decimal b = cm.trytoeuro(a);
            return View();
        }
    }
}