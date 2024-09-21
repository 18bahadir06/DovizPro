using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BusinessLayer.Concrete
{
    public class CurrencyInternetManager : ICurrencyInternetService
    {
        public TcmbCurrency GetData(DateTime p)
        {
            TcmbCurrency currency = new TcmbCurrency();
            string date1 = p.ToString("yyyyMM");
            string date2 = p.ToString("ddMMyyyy");
            string url = $@"http://www.tcmb.gov.tr/kurlar/{date1}/{date2}.xml";
            try
            {
                XmlDocument xmlData = new XmlDocument();
                xmlData.Load(url);
                XmlNode nodeDolar = xmlData.SelectSingleNode("//Currency[@Kod='USD']");
                if (nodeDolar != null)
                {
                    currency.DolarBuying = decimal.Parse(nodeDolar.SelectSingleNode("ForexBuying").InnerText.Replace(",", "."));
                    currency.DolarSelling = decimal.Parse(nodeDolar.SelectSingleNode("ForexSelling").InnerText.Replace(",", "."));
                }
                else
                {
                    return null;
                }
                XmlNode nodeEuro = xmlData.SelectSingleNode("//Currency[@Kod='EUR']");
                if (nodeEuro != null)
                {
                    currency.EuroBuying = decimal.Parse(nodeEuro.SelectSingleNode("ForexBuying").InnerText.Replace(",", "."));
                    currency.EuroSelling = decimal.Parse(nodeEuro.SelectSingleNode("ForexSelling").InnerText.Replace(",", "."));
                }
                else
                {
                    return null;
                }
                currency.date = p;
                return currency;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
