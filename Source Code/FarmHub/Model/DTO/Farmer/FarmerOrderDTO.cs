using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.Farmer
{
    public class FarmerOrderDTO
    {
        public PURCHASE_OFFER purchaseOfferDetail { get; set; }
        public SALE_OFFER saleOffer { get; set; }
        public IEnumerable<FarmDTO> farms { get; set; }
      
        public int productDetailId { get; set; }
    }
}
