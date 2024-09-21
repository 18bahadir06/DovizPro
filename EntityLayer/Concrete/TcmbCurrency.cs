using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TcmbCurrency
    {
        [Key]
        public int TcmbCurrencyId { get; set; }
        public DateTime date { get; set; }
        public decimal DolarBuying { get; set; }
        public decimal EuroBuying { get; set; }
        public decimal DolarSelling { get; set; }
        public decimal EuroSelling { get; set; }
    }
}
