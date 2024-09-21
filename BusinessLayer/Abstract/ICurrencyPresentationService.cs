using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICurrencyPresentationService
    {
        TcmbCurrency CurrencyProcessGet(DateTime p);
        List<TcmbCurrency> CurrencyMounthGet(DateTime p);
        List<TcmbCurrency> CurrencyYearGet(DateTime p);
    }
}
