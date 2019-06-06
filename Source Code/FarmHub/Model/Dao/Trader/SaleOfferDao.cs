using Model.EF;
using System.Collections.Generic;
using System.Linq;

namespace Model.Dao.Trader
{
    public class SaleOfferDao
    {
        FarmHubDbContext db = null;
        public SaleOfferDao()
        {
            db = new FarmHubDbContext();
        }

        public IEnumerable<SALE_OFFER> SaleListAllPaging()
        {
            IQueryable<SALE_OFFER> model = db.SALE_OFFER;

            var modelList = model.Where(x => x.Is_Deleted == false && x.Remain_SaleQuantity > 0);
            return model.OrderByDescending(x => x.Date_SaleOffer);
        }

        public IEnumerable<SALE_OFFER> SuitableSaleOfferByProduct(int purchaseOfferId)
        {
            var purchModel = db.PURCHASE_OFFER.Find(purchaseOfferId);

            var idProduct = purchModel.Id_Product;
            var idSeed = purchModel.Id_Seed;

            IQueryable<SALE_OFFER> model = db.SALE_OFFER;

            var modelList = model.Where(x => x.Is_Deleted == false && x.Remain_SaleQuantity > 0 && x.PRODUCT_DETAIL.Id_Product == idProduct && x.PRODUCT_DETAIL.Id_Seed == idSeed);
            return model.OrderByDescending(x => x.Date_SaleOffer);
        }
    }
}
