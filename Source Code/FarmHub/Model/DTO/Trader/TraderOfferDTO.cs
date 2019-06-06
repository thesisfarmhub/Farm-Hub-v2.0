using Model.EF;

using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.Trader
{
    public class TraderOfferDTO
    {
        public PURCHASE_OFFER purchaseOffer { get; set; }

        public IEnumerable<ProductDTO> products { get; set; }
        public IEnumerable<UnitMassDTO> units { get; set; }
        public IEnumerable<SeedDTO> seeds { get; set; }
        public IEnumerable<PurchaseOfferDTO> purchaseDetail{get;set;}
        
    }
}
