using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.Trader
{
    public class TraderOrderDTO
    {
        public SALE_OFFER saleOfferDetail { get; set; }
        public PURCHASE_OFFER purchaseOffer { get; set; }
        public int TotalMoney { get; set; }
    }
}
