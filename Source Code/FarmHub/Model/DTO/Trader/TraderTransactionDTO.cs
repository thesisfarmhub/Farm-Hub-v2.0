using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.Trader
{
    public class TraderTransactionDTO
    {
        public int transId { get; set; }
        public string endTransDay { get; set; }
        public bool? canBargain {get;set;}
        public string productName { get; set; }
        public string seedName { get; set; }
        public string traderName { get; set; }
        public string farmName { get; set; }
        public string farmerName { get; set; }
        public int? price { get; set; }
        public int? quantity { get; set; }
        public string unitName { get; set; }
        public double? totalMoney { get; set; }
        public int? payingDay { get; set; }
        public int? deliveringDay { get; set; }
        public string StatusName { get; set; }
    }
}
