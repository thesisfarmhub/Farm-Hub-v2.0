using Model.DTO.Farmer;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Dao.Farmer
{
    public class SaleOfferDAO
    {
        readonly FarmHubDbContext db = null;

        public SaleOfferDAO()
        {
            db = new FarmHubDbContext();

        }

        #region Meow
        // List All
        public List<SALE_OFFER> ListAll()
        {
            return db.SALE_OFFER.Where(x => x.Id_SaleOffer > 0).OrderByDescending(x => x.Id_SaleOffer).ToList();
        }

        // List All Active
        public List<SALE_OFFER> ListAllActive()
        {
            return db.SALE_OFFER.Where(x => x.Is_Deleted == false).OrderByDescending(x => x.Id_SaleOffer).ToList();
        }

        // List Sale Offer By Farmer ID Limit
        public List<SALE_OFFER> ListSaleOfferByFarmerID(int farmerID, int take)
        {
            return db.SALE_OFFER.Where(x => x.FARM.Id_Farmer == farmerID && x.Remain_SaleQuantity > 0 && x.Is_Deleted == false)/*.GroupBy(x => x.PRODUCT_DETAIL.PRODUCT.Id_Product).Select(gr => gr.FirstOrDefault())*/.OrderByDescending(x => x.Id_SaleOffer).Take(take).ToList();
        }

        // List Sale Offer By Farmer ID Non-Limit
        public List<SALE_OFFER> ListSaleOfferByFarmerID(int farmerID)
        {
            return db.SALE_OFFER.Where(x => x.FARM.Id_Farmer == farmerID && x.Remain_SaleQuantity > 0 && x.Is_Deleted == false).OrderByDescending(x => x.Id_SaleOffer).ToList();
        }

        // Suitable Purchase Offer
        // Farmer Home Page: List Sale Offer => Suitalbe Purchase Offer
        public List<List<PURCHASE_OFFER>> SuitablePurchaseOffer(List<SALE_OFFER> listSaleOffer, int take)
        {
            var listPurchaseOffer = new List<List<PURCHASE_OFFER>>();

            // Duyệt tất cả các Id_Product và chỉ lấy những Id_Product khác nhau sau đó add vào listProductID
            List<int> listProductID = listSaleOffer.Select(x => x.PRODUCT_DETAIL.PRODUCT.Id_Product).AsParallel().Distinct().ToList();

            foreach (var item in listProductID)
            {
                List<PURCHASE_OFFER> subListPO = db.PURCHASE_OFFER.Where(x => x.PRODUCT.Id_Product == item && x.Remain_PurchaseQuantity > 0 && x.Is_Deleted == false).Take(take).ToList();
                listPurchaseOffer.Add(subListPO);
            }

            return listPurchaseOffer;
        }

        // List Purchase Offer Base On Farmer Reference: PurchaseOfferYouMayLike
        // Từ FarmerID chọn Id_ProductKind lớn nhất, từ Id_ProductKind lấy được list ProductID
        // Từ listProductID lấy ra được listPurchaseOffer
        public List<PURCHASE_OFFER> PurchaseOfferYouMayLike(int farmerID)
        {
            try
            {
                var id_ProductKind = db.FARMER_PREFERENCE_DETAIL.Where(x => x.FARMER_PREFERENCE.Id_Farmer == farmerID).FirstOrDefault().Id_ProductKind.Value;
                //
                var listProductID = db.PRODUCTs.Where(x => x.Id_ProductKind == id_ProductKind).Select(x => x.Id_Product).ToList();
                //
                var listPurchaseOffer = new List<PURCHASE_OFFER>();
                foreach (var item in listProductID)
                {
                    var purchaseOffer = db.PURCHASE_OFFER.Where(x => x.PRODUCT.Id_Product == item && x.Remain_PurchaseQuantity > 0).FirstOrDefault();
                    if (listPurchaseOffer.Count() < 5)
                    {
                        listPurchaseOffer.Add(purchaseOffer);
                    }
                }

                return listPurchaseOffer;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // Top Product Base On Farmer Purchase Offer
        public List<FarmerTopProductDTO> ListTopProductDetails()
        {
            //SQL chọn ra top 7 Product có số lượng nhu cầu bán nhiều nhất:
            //select Id_ProductDetail, SUM(Quantity_SaleOffer) as TotalQuant, AVG(Price_Offer) as AvgPrice
            //from SALE_OFFER
            //group by Id_ProductDetail
            //order by TotalQuant Desc

            var listTopProducts = db.SALE_OFFER.Where(so => so.Is_Deleted == false).GroupBy(so => so.Id_ProductDetail).Select(x => new FarmerTopProductDTO
            {
                Id_Farm = x.FirstOrDefault().Id_Farm,
                Id_ProductDetail = x.FirstOrDefault().Id_ProductDetail,
                Name_Product = x.FirstOrDefault().PRODUCT_DETAIL.PRODUCT.Name_Product,
                Name_Seed = x.FirstOrDefault().PRODUCT_DETAIL.SEED.Name_Seed,
                Price_Offer = (int)x.Average(p => p.Price_Offer),
                Quantity_SaleOffer = x.Sum(q => q.Quantity_SaleOffer),
                Date_SaleOffer = x.FirstOrDefault().Date_SaleOffer,
                Image_Product = x.FirstOrDefault().PRODUCT_DETAIL.Image_ProductDetail
            }).OrderByDescending(x => x.Quantity_SaleOffer).Take(7).ToList(); // Take top 7 Products

            return listTopProducts;
        }

        // Details
        public SALE_OFFER Details(int id_SaleOffer)
        {
            return db.SALE_OFFER.Find(id_SaleOffer);
        }

        // DetailsInclude
        public SALE_OFFER DetailsInclude(int id_SaleOffer)
        {
            //return db.SALE_OFFER.Find(id_SaleOffer);
            return db.SALE_OFFER.FirstOrDefault(x => x.Id_SaleOffer == id_SaleOffer);
        }

        // Create
        public int Create(SALE_OFFER saleOfferModel)
        {
            saleOfferModel.Is_Deleted = false;
            db.SALE_OFFER.Add(saleOfferModel);
            db.SaveChanges();
            return saleOfferModel.Id_SaleOffer;
        }

        // Update
        public bool Update(SALE_OFFER saleOfferModel)
        {
            var targetUpdate = db.SALE_OFFER.Find(saleOfferModel.Id_SaleOffer);

            try
            {
                targetUpdate.Id_Farm = saleOfferModel.Id_Farm;
                targetUpdate.Id_MassUnit = saleOfferModel.Id_MassUnit;
                targetUpdate.Id_ProductDetail = saleOfferModel.Id_ProductDetail;
                targetUpdate.Date_SaleOffer = saleOfferModel.Date_SaleOffer;
                targetUpdate.Price_Offer = saleOfferModel.Price_Offer;
                targetUpdate.Quantity_SaleOffer = saleOfferModel.Quantity_SaleOffer;
                targetUpdate.Remain_SaleQuantity = saleOfferModel.Remain_SaleQuantity;
               
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
        }

        // Delete
        public bool Delete(int id_SaleOffer)
        {
            try
            {
                var targetDelete = db.SALE_OFFER.Find(id_SaleOffer);
                //db.SALE_OFFER.Remove(targetDelete);
                targetDelete.Is_Deleted = true;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region ChenLong
        public IEnumerable<SALE_OFFER> getSaleOfferByIdUser(int FarmerId)
        {
           
            IQueryable<SALE_OFFER> model = db.SALE_OFFER.Where(x => x.FARM.Id_Farmer == FarmerId && x.Is_Deleted == false).OrderBy(x => x.Date_SaleOffer);

            foreach (var item in model)
            {
                item.Number_Of_Orders = Convert.ToByte(db.SALE_OFFER.Where(x => x.Id_SaleOffer == item.Id_SaleOffer)
                                          .Join(db.SALE_OFFER_DETAIL, so => so.Id_SaleOffer, sod => sod.Id_SaleOffer, (so, sod) => new { SO = so, SOD = sod })
                                          .Join(db.TRANSACTION_ORDER, so_sod => so_sod.SOD.Id_SaleOfferDetail, to => to.Id_SaleOfferDetail, (so_sod, to) => new { SO_SOD = so_sod, TO = to })
                                          //.Where(po_pod_to => po_pod_to.TO.Id_StatusTrans == 9 || po_pod_to.TO.Id_StatusTrans == 11)
                                          .Count());
               
            }


            db.SaveChanges();
            return model;
        }

        #endregion
    }
}
