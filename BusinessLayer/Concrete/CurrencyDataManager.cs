using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CurrencyDataManager:ICurrencyDataService
    {
        ICurrencyRepository _CurrencyRepository;

        public CurrencyDataManager(ICurrencyRepository currencyRepository)
        {
            _CurrencyRepository = currencyRepository;
        }


        public void CurrencyAdd(TcmbCurrency p)
        {
            _CurrencyRepository.Add(p);
        }

        public bool CurrencyControl(DateTime p)
        {
            var a =_CurrencyRepository.ListFiltr(x => x.date == p);
            if (a != null)
            {
                return true;
            }
            return false;
        }

        public TcmbCurrency CurrencyGet(DateTime p)
        {
            return _CurrencyRepository.Get(x=>x.date==p);
        }
        public List<TcmbCurrency> CurrencyList()
        {
            return CurrencyList().ToList();
        }
    }
}
