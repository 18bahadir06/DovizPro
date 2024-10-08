using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
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
        CurrencyPresentationManager _currencyPresentationManager;
        public HomeController(CurrencyPresentationManager currencyPresentationManager)
        {
            _currencyPresentationManager = currencyPresentationManager;
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            var a =await cm.GetRatesAsync();
            var Euro = cm.trytoeuro(a);
            var Dolar = cm.trytousd(a);
            decimal Dolars= Math.Round(Dolar,2);
            decimal Euros= Math.Round(Euro,2);
            TempData["Dolar"] = Dolars;
            TempData["Euro"] = Euros;
            DateTime now=DateTime.Now;
            var currency= _currencyPresentationManager.CurrencyPastMounth(now);
            TempData["dolars"]= currency.DolarBuying;
            return View(currency);
        }
    }
}