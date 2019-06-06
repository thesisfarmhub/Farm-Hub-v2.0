using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.Farmer
{
    public class SaleOfferDTO
    {
        public int saleOfferid { get; set; }
        public bool? canBargain { get; set; }
        public string createdDate { get; set; }
        public int productDetailId { get; set; }
        public int? productId { get; set; }
        public string productName { get; set; }
        public string seedName { get; set; }
        public int farmId { get; set; }
        public string farmName { get; set; }
        public int? quantity { get; set; }
        public string massName { get; set; }
        public byte? idUnit { get; set; }
        public int? price { get; set; }
        public byte? payingTime { get; set; }
        public byte? deliveringTime { get; set; }
        public byte? numberOfOrder { get; set; }
        public int? remain { get; set; }
        public string image { get; set; }
    }
}
