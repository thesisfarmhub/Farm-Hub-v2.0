using Model.DTO.Farmer;
using Model.EF;
using System.Collections.Generic;

namespace FarmHub.Areas.Farmer.Models
{
    public class FarmerHomePageModel
    {
        public List<SALE_OFFER> ListSaleOffer { get; set; }

        public List<List<PURCHASE_OFFER>> SuitablePurchaseOffer { get; set; }

        public List<FarmerTopProductDTO> FarmerListTopProduct { get; set; }

        public List<PURCHASE_OFFER> PurchaseOfferYouMayLike { get; set; }
    }
}