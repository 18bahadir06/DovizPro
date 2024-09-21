using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICurrencyDataService
    {
        TcmbCurrency CurrencyGet(DateTime p);
        void CurrencyAdd(TcmbCurrency p);
        List<TcmbCurrency> CurrencyList();
        bool CurrencyControl(DateTime p);
    }
}
