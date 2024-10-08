using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CurrencyPresentationManager:ICurrencyPresentationService
    {
        ICurrencyDataService _CurrencyDS;
        ICurrencyInternetService _CurrencyIS;

        public CurrencyPresentationManager(ICurrencyDataService currencyDS, ICurrencyInternetService currencyIS)
        {
            _CurrencyDS = currencyDS;
            _CurrencyIS = currencyIS;
        }
        //aylık veri çekimi
        public List<TcmbCurrency> CurrencyMounthGet(DateTime p)
        {
            TcmbCurrency currency=new TcmbCurrency();
            List<TcmbCurrency> listcurrency =new List<TcmbCurrency>();

            DateTime date=p;
            for(int i = 0; i < 30; i++)
            {
                
                bool control=_CurrencyDS.CurrencyControl(date);
                if (control == false)
                {
                    currency=_CurrencyIS.GetData(date);
                    _CurrencyDS.CurrencyAdd(currency);
                    listcurrency.Add(currency);
                }
                else
                {
                    currency = _CurrencyDS.CurrencyGet(date);
                    listcurrency.Add(currency);
                }
                date = date.AddDays(-1);
            }
            return listcurrency;
        }

        public TcmbCurrency CurrencyPastMounth(DateTime p)
        {
            TcmbCurrency currency=new TcmbCurrency();
            DateTime time=p.AddDays(-30);
            bool control=_CurrencyDS.CurrencyControl(time);
            if (control)
            {
                return _CurrencyDS.CurrencyGet(time);
            }
            else
            {
                currency =_CurrencyIS.GetData(time);
                _CurrencyDS.CurrencyAdd(currency);
                return currency;
            }
        }

        public TcmbCurrency CurrencyProcessGet(DateTime p)
        {
            if (_CurrencyDS.CurrencyControl(p) == null)
            {
                _CurrencyDS.CurrencyAdd(_CurrencyIS.GetData(p));
            }
            return _CurrencyDS.CurrencyGet(p); ;
        }

        public List<TcmbCurrency> CurrencyYearGet(DateTime p)
        {
            throw new NotImplementedException();
        }
    }
}
