using Model.Dao.Trader;
using Model.DTO.Trader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmHub.Controllers
{
    public class TraderOfferDetailController : Controller
    {
        PurchaseOfferDetailDao dao = new PurchaseOfferDetailDao();
        // GET: OfferDetail
        public ActionResult TraderOfferDetail(int traderOfferId)
        {
            

            var offerDetail = dao.Details(traderOfferId);
            var offerDTO = new PurchaseOfferDTO();

            offerDTO.purchOfferID = traderOfferId;
            offerDTO.productID = offerDetail.PRODUCT.Id_Product;
            offerDTO.productName = offerDetail.PRODUCT.Name_Product;    
            offerDTO.seedName = offerDetail.SEED.Name_Seed;
            offerDTO.price = offerDetail.Price_Purchase;
            offerDTO.quantity = offerDetail.Quantity_PurchaseOffer;
            offerDTO.massName = offerDetail.MASS_UNIT.Name_MassUnit;
            offerDTO.payingTime = offerDetail.Paying_Time;
            offerDTO.deliveringTime = offerDetail.Delivering_Time;
            offerDTO.image = offerDetail.PRODUCT.Image_Product;
            offerDTO.canBargain = offerDetail.Can_Bargain;
            offerDTO.remainQuantity = offerDetail.Remain_PurchaseQuantity;
            return View(offerDTO);
        }

        [HttpGet]
        public JsonResult GetSuitableListSale(int purchaseOfferId)
        {
            var purchaselList = new SaleOfferDao().SuitableSaleOfferByProduct(purchaseOfferId);
            List<SaleOfferDTO> saleOfferDTOs = new List<SaleOfferDTO>();

            foreach (var p in purchaselList)
            {
                var saleOfferDTO = new SaleOfferDTO();
                saleOfferDTO.id = p.Id_SaleOffer;
                saleOfferDTO.canBargain = p.Can_Bargain;
                saleOfferDTO.createdDate = ((DateTime)p.Date_SaleOffer).ToShortDateString();
                saleOfferDTO.quantity = p.Quantity_SaleOffer;
                saleOfferDTO.seedName = p.PRODUCT_DETAIL.SEED.Name_Seed;
                saleOfferDTO.farmName = p.FARM.Name_Farm;
                saleOfferDTO.massName = p.MASS_UNIT.Name_MassUnit;
                saleOfferDTO.price = p.Price_Offer;
                saleOfferDTO.productName = p.PRODUCT_DETAIL.PRODUCT.Name_Product;

                saleOfferDTOs.Add(saleOfferDTO);
            }

            return Json(new { data = saleOfferDTOs }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SaleOfferListByPurchaseOfferID(int purchaseOfferId)
        {
            var saleList = new PurchaseOfferDetailDao().TransactionListByPurchaseOfferID(purchaseOfferId);
            List<TraderTransactionDTO> transactionDTOs = new List<TraderTransactionDTO>();

            foreach (var p in saleList)
            {
                var transactionDTO = new TraderTransactionDTO();

                transactionDTO.transId = p.Id_TransactionOrder;
                transactionDTO.endTransDay = ((DateTime)p.Transaction_Date).ToShortDateString();
                transactionDTO.productName = p.PRODUCT_DETAIL.PRODUCT.Name_Product;
                transactionDTO.seedName = p.PRODUCT_DETAIL.SEED.Name_Seed;
                transactionDTO.farmName = p.SALE_OFFER_DETAIL.SALE_OFFER.FARM.Name_Farm;
                transactionDTO.farmerName = p.SALE_OFFER_DETAIL.SALE_OFFER.FARM.FARMER.Name_Farmer;
                transactionDTO.quantity = p.Transaction_Mass;
                transactionDTO.unitName = p.PURCHASE_OFFER_DETAIL.PURCHASE_OFFER.MASS_UNIT.Name_MassUnit;
                transactionDTO.price = p.Transaction_Price;
                transactionDTO.totalMoney = p.Transaction_Mass * p.PURCHASE_OFFER_DETAIL.PURCHASE_OFFER.MASS_UNIT.Weight_To_Kg * p.Transaction_Price;
                transactionDTO.StatusName = p.STATUS_TRANS.Name_StatusTrans;
                transactionDTOs.Add(transactionDTO);
            }

            return Json(transactionDTOs, JsonRequestBehavior.AllowGet);
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