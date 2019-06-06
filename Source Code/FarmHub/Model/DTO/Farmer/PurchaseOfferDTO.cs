using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.Farmer
{
    public class PurchaseOfferDTO
    {
        public int id { get; set; }
        public bool? canBargain { get; set; }
        public string traderName { get; set; }
        public string createdDate { get; set; }
        public string productName { get; set; }
        public string seedName { get; set; }
        public int? quantity { get; set; }
        public string massName { get; set; }
        public int? trueMass { get; set; }
        public int? price { get; set; }
        public byte? payingTime { get; set; }
        public byte? deliveringTime { get; set; }
        public byte? numberOfOrder { get; set; }
        public int? totalMoney { get; set; }
        
    }
}
