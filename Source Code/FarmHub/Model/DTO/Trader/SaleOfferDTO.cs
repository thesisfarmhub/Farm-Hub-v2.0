using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.Trader
{
    public class SaleOfferDTO
    {
        public int id { get; set; }
        public bool? canBargain { get; set; }
        public string createdDate { get; set; }
        public string productName { get; set; }
        public string seedName { get; set; }
        public string farmName { get; set; }
        public string farmerName { get; set; }
        public int? quantity { get; set; }
        public string massName { get; set; }
        public int? trueMass { get; set; }
        public int? totalMoney { get; set; }
        public int? price { get; set; }

    }
}
