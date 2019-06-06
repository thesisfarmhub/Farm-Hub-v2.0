using Model.DTO.Trader;
using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Dao.Trader
{
    public class PurchaseOfferDao
    {
        FarmHubDbContext db = null;
        public PurchaseOfferDao()
        {
            db = new FarmHubDbContext();
        }

        public IEnumerable<PURCHASE_OFFER> getPurchaseOfferByID(int traderID)
        {
         
            IQueryable<PURCHASE_OFFER> model = db.PURCHASE_OFFER.Where(x => x.Id_Trader == traderID && x.Remain_PurchaseQuantity > 0 && x.Is_Deleted == false).OrderByDescending(x => x.Date_PurchaseOffer);

            foreach (var item in model)
            {
                item.Number_Of_Orders = Convert.ToByte(db.PURCHASE_OFFER.Where(x => x.Id_PurchasesOffer == item.Id_PurchasesOffer)
                                          .Join(db.PURCHASE_OFFER_DETAIL, po => po.Id_PurchasesOffer, pod => pod.Id_PurchasesOffer, (po, pod) => new { PO = po, POD = pod })
                                          .Join(db.TRANSACTION_ORDER, po_pod => po_pod.POD.Id_PurchaseOfferDetail, to => to.Id_PurchaseOfferDetail, (po_pod, to) => new { PO_POD = po_pod, TO = to })
                                          .Where(po_pod_to => po_pod_to.TO.Id_StatusTrans == 10 || po_pod_to.TO.Id_StatusTrans == 12)
                                          .Count());
            }

            return model;
        }

        //

        public IEnumerable<PURCHASE_OFFER> getPurchaseOfferByIDForGuest()
        {

            IQueryable<PURCHASE_OFFER> model = db.PURCHASE_OFFER;

            return model;
        }
        #region Meow

        // List All
        public List<PURCHASE_OFFER> ListAll()
        {
            return db.PURCHASE_OFFER.Where(x => x.Is_Deleted == false).OrderByDescending(x => x.Id_PurchasesOffer).ToList();
        }

        // List All Limit
        public List<PURCHASE_OFFER> ListAllLimit()
        {
            return db.PURCHASE_OFFER.Where(x => x.Is_Deleted == false).OrderByDescending(x => x.Id_PurchasesOffer).Take(5).ToList();
        }

        // List Purchase Offer By Trader ID Limit
        public List<PURCHASE_OFFER> ListPOByTraderID(int traderID, int take)
        {
            return db.PURCHASE_OFFER.Where(x => x.Is_Deleted == false && x.Id_Trader == traderID && x.Remain_PurchaseQuantity > 0).GroupBy(x => x.Id_Product).Select(gr => gr.FirstOrDefault()).OrderByDescending(x => x.Id_PurchasesOffer).Take(take).ToList();
        }

        // List Purchase Offer By Trader ID Non-Limit
        public List<PURCHASE_OFFER> ListPOByTraderID(int traderID)
        {
            return db.PURCHASE_OFFER.Where(x => x.Is_Deleted == false && x.Id_Trader == traderID && x.Remain_PurchaseQuantity > 0).OrderByDescending(x => x.Id_PurchasesOffer).ToList();
        }

        // Suitable Sale Offer Limit
        // Trader Home Page: List Purchase Offer => Suitable Sale Offer
        public List<List<SALE_OFFER>> SuitalbeSaleOffers(List<PURCHASE_OFFER> listPurchaseOffer, int take)
        {
            var listSaleOffer = new List<List<SALE_OFFER>>();

            // Duyệt tất cả các Id_Product và chỉ lấy những Id_Product khác nhau sau đó add vào listProductID
            List<int> listProductID = listPurchaseOffer.Select(x => x.PRODUCT.Id_Product).AsParallel().Distinct().ToList();

            foreach (var item in listProductID)
            {
                List<SALE_OFFER> subListSO = db.SALE_OFFER.Where(x => x.PRODUCT_DETAIL.PRODUCT.Id_Product == item && x.Remain_SaleQuantity > 0 && x.Is_Deleted == false).Take(take).ToList();
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
