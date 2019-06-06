using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.Farmer
{
    class FarmerTransDTO
    {
        public IEnumerable<SALE_OFFER> saleOffers { get; set; }
        public IEnumerable<PURCHASE_OFFER> purchaseOffers { get; set; }
        public IEnumerable<SALE_OFFER_DETAIL> saleOfferDetails { get; set; }

        public PagedList<SALE_OFFER> saleOfferPagedList { get; set; }
        public PagedList<PURCHASE_OFFER> purchaseOfferPagedList { get; set; }
    }
}
