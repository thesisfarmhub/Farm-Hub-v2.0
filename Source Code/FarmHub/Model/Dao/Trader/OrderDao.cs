using Model.DTO.Trader;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.Trader
{
    public class OrderDao
    {
        FarmHubDbContext db = null;

        public OrderDao()
        {
            db = new FarmHubDbContext();
        }

        public SALE_OFFER saleDetail(int id)
        {
            return db.SALE_OFFER.Find(id);
        }

        public void Insert(TraderOrderDTO model, int idsaleOfferId, int traderId, string counterOffered)
        {
            var saleModel = db.SALE_OFFER.Find(idsaleOfferId);
          


            //Assign value to Purchase Offer
            model.purchaseOffer.Id_Product = saleModel.PRODUCT_DETAIL.Id_Product;
            model.purchaseOffer.Id_Seed = saleModel.PRODUCT_DETAIL.Id_Seed;
            model.purchaseOffer.Id_MassUnit = saleModel.Id_MassUnit;
            model.purchaseOffer.Price_Purchase = saleModel.Price_Offer;
            model.purchaseOffer.Can_Bargain = saleModel.Can_Bargain;

            model.purchaseOffer.Date_PurchaseOffer = DateTime.Now;
            model.purchaseOffer.Remain_PurchaseQuantity = 0;
            model.purchaseOffer.Is_Deleted = false;
            model.purchaseOffer.Id_Trader = traderId;
            

            db.PURCHASE_OFFER.Add(model.purchaseOffer);
            db.SaveChanges();

            int poId = model.purchaseOffer.Id_PurchasesOffer;
            int soId = saleModel.Id_SaleOffer;
            double? Quantity = model.purchaseOffer.Quantity_PurchaseOffer;
            double? TotalMoney = Quantity * saleModel.MASS_UNIT.Weight_To_Kg * saleModel.Price_Offer;




             db.Database.ExecuteSqlCommand("EXEC CreatePurchaseDetail @Id_PurchasesOffer, @Quantity_PurchaseOfferDetail",
                                                            new SqlParameter("@Id_PurchasesOffer", poId),
                                                            new SqlParameter("@Quantity_PurchaseOfferDetail", Quantity));

             db.Database.ExecuteSqlCommand("EXEC CreateSaleDetail @Id_SaleOffer, @Quantity_SaleOfferDetail",
                                                           new SqlParameter("@Id_SaleOffer", soId),
                                                           new SqlParameter("@Quantity_SaleOfferDetail", Quantity));

            
            var soDetailId = db.SALE_OFFER_DETAIL.Max(x => x.Id_SaleOfferDetail);
            var poDetailId = db.PURCHASE_OFFER_DETAIL.Max(x => x.Id_PurchaseOfferDetail);

          
           
            if (counterOffered=="true")
            {
                                     
                db.Database.ExecuteSqlCommand("EXEC CreateTransactionOrder @Id_SaleOfferDetail,@Id_PurchaseOfferDetail,@Id_ProductDetail,@Transaction_Mass,@Transaction_Unitmass,@Transaction_Price,@Transaction_TotalMoney,@Paying_Time,@Delivering_Time,@Id_StatusTrans",
                                                           new SqlParameter("@Id_SaleOfferDetail", soDetailId),
                                                           new SqlParameter("@Id_PurchaseOfferDetail", poDetailId),
                                                           new SqlParameter("@Id_ProductDetail", saleModel.Id_ProductDetail),
                                                           new SqlParameter("@Transaction_Mass", Quantity),
                                                           new SqlParameter("@Transaction_Unitmass", saleModel.MASS_UNIT.Name_MassUnit),
                                                           new SqlParameter("@Transaction_Price", saleModel.Price_Offer),
                                                           new SqlParameter("@Transaction_TotalMoney", TotalMoney),
                                                           new SqlParameter("@Paying_Time", model.purchaseOffer.Paying_Time),
                                                           new SqlParameter("@Delivering_Time", model.purchaseOffer.Delivering_Time),
                                                           new SqlParameter("@Id_StatusTrans", 11));//"Bên Mua Đặt Lại"

            }
            else
            {
                db.Database.ExecuteSqlCommand("EXEC CreateTransactionOrder @Id_SaleOfferDetail,@Id_PurchaseOfferDetail,@Id_ProductDetail,@Transaction_Mass,@Transaction_Unitmass,@Transaction_Price,@Transaction_TotalMoney,@Paying_Time,@Delivering_Time,@Id_StatusTrans",
                                                           new SqlParameter("@Id_SaleOfferDetail", soDetailId),
                                                           new SqlParameter("@Id_PurchaseOfferDetail", poDetailId),
                                                           new SqlParameter("@Id_ProductDetail", saleModel.Id_ProductDetail),
                                                           new SqlParameter("@Transaction_Mass", Quantity),
                                                           new SqlParameter("@Transaction_Unitmass", saleModel.MASS_UNIT.Name_MassUnit),
                                                           new SqlParameter("@Transaction_Price", saleModel.Price_Offer),
                                                           new SqlParameter("@Transaction_TotalMoney", TotalMoney),
                                                           new SqlParameter("@Paying_Time", model.purchaseOffer.Paying_Time),
                                                           new SqlParameter("@Delivering_Time", model.purchaseOffer.Delivering_Time),
                                                           new SqlParameter("@Id_StatusTrans",10));//"Mới Thiết Lập"
            }
            

            db.SaveChanges();
        }
    }
}
