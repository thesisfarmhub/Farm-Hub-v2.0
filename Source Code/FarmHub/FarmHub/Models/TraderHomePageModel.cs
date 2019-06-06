using Model.DTO.Trader;
using Model.EF;
using System.Collections.Generic;

namespace FarmHub.Models
{
    public class TraderHomePageModel
    {
        public List<PURCHASE_OFFER> ListPurchaseOffer { get; set; }

        public List<List<SALE_OFFER>> SuitalbeSaleOffers { get; set; }

        public List<TopProductDetailsDTO> ListTopProducts { get; set; }
    }
}