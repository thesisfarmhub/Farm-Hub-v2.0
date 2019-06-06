using Model.DTO.Trader;
using Model.EF;
using PagedList;
using System.Collections.Generic;
using System.Linq;

namespace Model.Dao.Farmer
{
    public class PurchaseOfferDao
    {
        FarmHubDbContext db = null;

        public PurchaseOfferDao()
        {
            db = new FarmHubDbContext();
        }
        //
        public IEnumerable<PURCHASE_OFFER> getPurchaseOffer()
        {
            IQueryable<PURCHASE_OFFER> model = db.PURCHASE_OFFER;

            var modelList = model.Where(x => x.Is_Deleted == false);
            return modelList.OrderByDescending(x => x.Date_PurchaseOffer);
        }

        public IEnumerable<PURCHASE_OFFER> SuitPurchaseOfferBySaleOfferId(int saleOfferId)
        {
            var saleModel = db.SALE_OFFER.Find(saleOfferId);

            var idProduct = saleModel.PRODUCT_DETAIL.Id_Product;
            var idSeed = saleModel.PRODUCT_DETAIL.Id_Seed;

            IQueryable<PURCHASE_OFFER> model = db.PURCHASE_OFFER;

            var modelList = model.Where(x => x.Is_Deleted == false && x.Remain_PurchaseQuantity > 0 && x.Id_Product == idProduct && x.Id_Seed == idSeed);
            return model.OrderByDescending(x => x.Date_PurchaseOffer);
        }

        #region Meow

        // List All
        public List<PURCHASE_OFFER> ListAllActive()
        {
            return db.PURCHASE_OFFER.Where(x => x.Is_Deleted == false).OrderByDescending(x => x.Id_PurchasesOffer).ToList();
        }

        // List All Limit
        public List<PURCHASE_OFFER> ListAllLimit()
        {
            return db.PURCHASE_OFFER.Where(x => x.Is_Deleted == false).GroupBy(x => x.Id_Product).Select(x => x.FirstOrDefault()).Take(5).ToList();
        }

        // List Purchase Offer By Trader ID
        public List<PURCHASE_OFFER> ListPOByTraderID(int traderID)
        {
            return db.PURCHASE_OFFER.Where(x => x.Is_Deleted == false && x.Id_Trader == traderID && x.Quantity_PurchaseOffer > 0).OrderByDescending(x => x.Id_PurchasesOffer).ToList();
        }

        // Suitable Sale Offer
        // Trader Home Page: List Purchase Offer => Suitable Sale Offer
        public List<List<SALE_OFFER>> SuitalbeSaleOffers(List<PURCHASE_OFFER> listPurchaseOffer)
        {
            var listSaleOffer = new List<List<SALE_OFFER>>();

            // Duyệt tất cả các Id_Product và chỉ lấy những Id_Product khác nhau sau đó add vào listProductID
            List<int> listProductID = listPurchaseOffer.Select(x => x.PRODUCT.Id_Product).AsParallel().Distinct().ToList();

            foreach (var item in listProductID)
            {
                List<SALE_OFFER> subListSO = db.SALE_OFFER.Where(x => x.PRODUCT_DETAIL.PRODUCT.Id_Product == item && x.Remain_SaleQuantity > 0 && x.Is_Deleted == false).Take(5).ToList();
                listSaleOffer.Add(subListSO);
            }

            return listSaleOffer;
        }

        // Top Product Base On Trader Purchase Offer
        public List<TopProductDetailsDTO> ListTopProductDetails()
        {
            //SQL chọn ra top 7 Product có số lượng yêu cầu mua nhiều nhất:
            //select Id_ProductDetail, SUM(Quantity_PurchaseOffer) as TotalQuant, AVG(Price_Purchase) as AvgPrice
            //from PURCHASE_OFFER
            //group by Id_ProductDetail
            //order by TotalQuant Desc

            var listTopProducts = db.PURCHASE_OFFER.Where(po => po.Is_Deleted == false).GroupBy(po => po.Id_Product).Select(x => new TopProductDetailsDTO
            {
                Id_Product = x.FirstOrDefault().Id_Product,
                Name_Product = x.FirstOrDefault().PRODUCT.Name_Product,
                Name_Seed = x.FirstOrDefault().SEED.Name_Seed,
                Quantity_PurchaseOffer = x.Sum(q => q.Quantity_PurchaseOffer),
                Price_Purchase = (int)x.Average(p => p.Price_Purchase),
                Image_Product = x.FirstOrDefault().PRODUCT.Image_Product
            }).OrderByDescending(x => x.Quantity_PurchaseOffer).Take(7).ToList();

            return listTopProducts;
        }

        #endregion
    }
}
