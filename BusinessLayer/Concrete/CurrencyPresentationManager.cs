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

        public List<TcmbCurrency> CurrencyMounthGet(DateTime p)
        {
            throw new NotImplementedException();
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
