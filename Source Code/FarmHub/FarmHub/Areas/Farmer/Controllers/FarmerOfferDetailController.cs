using Model.Dao.Farmer;
using Model.DTO.Farmer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmHub.Areas.Farmer.Controllers
{
    public class FarmerOfferDetailController : Controller
    {
        SaleOfferDetailDao dao = new SaleOfferDetailDao();
        // GET: Farmer/FarmerOfferDetail
        public ActionResult FarmerOfferDetail(int saleOfferId )
        {
           var dao = new SaleOfferDetailDao();

            var saleOfferDetail = dao.Details(saleOfferId);
            var SaleOfferDTO = new SaleOfferDTO();

            SaleOfferDTO.saleOfferid = saleOfferId;
            SaleOfferDTO.productId= saleOfferDetail.PRODUCT_DETAIL.Id_Product;
            SaleOfferDTO.productName = saleOfferDetail.PRODUCT_DETAIL.PRODUCT.Name_Product;
            SaleOfferDTO.seedName = saleOfferDetail.PRODUCT_DETAIL.SEED.Name_Seed;
            SaleOfferDTO.price = saleOfferDetail.Price_Offer;
            SaleOfferDTO.quantity = saleOfferDetail.Price_Offer;
            SaleOfferDTO.massName = saleOfferDetail.MASS_UNIT.Name_MassUnit;
            SaleOfferDTO.payingTime = saleOfferDetail.Paying_Time;
            SaleOfferDTO.deliveringTime = saleOfferDetail.Delivering_Time;
            SaleOfferDTO.image = saleOfferDetail.PRODUCT_DETAIL.Image_ProductDetail;
            SaleOfferDTO.canBargain = saleOfferDetail.Can_Bargain;
            SaleOfferDTO.remain = saleOfferDetail.Remain_SaleQuantity;
            return View(SaleOfferDTO);
        }

        [HttpGet]
        public JsonResult GetSuitableListPurchase(int saleOfferId)
        {
            var PurchaselList = new PurchaseOfferDao().SuitPurchaseOfferBySaleOfferId(saleOfferId);
            List<PurchaseOfferDTO> saleOfferDTOs = new List<PurchaseOfferDTO>();

            foreach (var p in PurchaselList)
            {
                var purchaseOfferDTO = new PurchaseOfferDTO();
                purchaseOfferDTO.id = p.Id_PurchasesOffer;
                purchaseOfferDTO.canBargain = p.Can_Bargain;
                purchaseOfferDTO.createdDate = ((DateTime)p.Date_PurchaseOffer).ToShortDateString();
                purchaseOfferDTO.productName = p.PRODUCT.Name_Product;
                purchaseOfferDTO.seedName = p.SEED.Name_Seed;
                purchaseOfferDTO.quantity = p.Quantity_PurchaseOffer;
                purchaseOfferDTO.traderName = p.TRADER.Name_Trader;
                purchaseOfferDTO.massName = p.MASS_UNIT.Name_MassUnit;

                purchaseOfferDTO.price = p.Price_Purchase;
               

                saleOfferDTOs.Add(purchaseOfferDTO);
            }

            return Json(new { data = saleOfferDTOs }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult PurchaseOfferListBySaleOfferID(int saleOfferId)
        {

            var saleList = new SaleOfferDetailDao().TransactionListByPurchaseOfferID(saleOfferId);
            List<TraderTransactionDTO> purchaseOfferDTOs = new List<TraderTransactionDTO>();

            foreach (var p in saleList)
            {
                var TransactionOfferDTO = new TraderTransactionDTO();

                TransactionOfferDTO.transId = p.Id_TransactionOrder;
                TransactionOfferDTO.endTransDay = ((DateTime)p.Transaction_Date).ToShortDateString();
                TransactionOfferDTO.productName = p.SALE_OFFER_DETAIL.SALE_OFFER.PRODUCT_DETAIL.PRODUCT.Name_Product ;
                TransactionOfferDTO.seedName = p.SALE_OFFER_DETAIL.SALE_OFFER.PRODUCT_DETAIL.SEED.Name_Seed;
                TransactionOfferDTO.traderName = p.PURCHASE_OFFER_DETAIL.PURCHASE_OFFER.TRADER.Name_Trader;
                TransactionOfferDTO.quantity = p.Transaction_Mass;
                TransactionOfferDTO.unitName = p.Transaction_Unitmass;
                TransactionOfferDTO.price = p.Transaction_Price;
                TransactionOfferDTO.totalMoney = p.Transaction_Mass * p.SALE_OFFER_DETAIL.SALE_OFFER.MASS_UNIT.Weight_To_Kg * p.Transaction_Price;
                TransactionOfferDTO.StatusName = p.STATUS_TRANS.Name_StatusTrans;
                
                purchaseOfferDTOs.Add(TransactionOfferDTO);
            }

            return Json(purchaseOfferDTOs, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AccepOffer(int transactionId)
        {

            dao.GetAcceptResult(transactionId);

            //return Json(new { Remain = remainQuantity});
            return Json(new object[] { new object() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CounterOffer(int transactionId, int counterOfferQuantity)
        {
            dao.MakeCounterOffer(transactionId, counterOfferQuantity);
            return Json(new object[] { new object() }, JsonRequestBehavior.AllowGet);
        }

    }
}