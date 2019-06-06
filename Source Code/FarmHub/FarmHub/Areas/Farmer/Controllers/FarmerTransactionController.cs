using Model.Dao.Farmer;
using Model.DTO.Farmer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmHub.Areas.Farmer.Controllers
{
    public class FarmerTransactionController : Controller
    {
        FarmerTransactionDao dao = new FarmerTransactionDao();
        // GET: Farmer/FarmerTransaction
        public ActionResult FarmerTransactionIndex()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetListTransaction()
        {
            var transactionList = dao.GetListTransaction();
            List<FarmerTransactionDTO> transactionDTOs = new List<FarmerTransactionDTO>();

            foreach (var p in transactionList)
            {
                var traderTransactionDTO = new FarmerTransactionDTO();
                traderTransactionDTO.transId = p.Id_TransactionOrder;
                traderTransactionDTO.endTransDay = ((DateTime)p.Transaction_Date).ToShortDateString();
                traderTransactionDTO.productName = p.PRODUCT_DETAIL.PRODUCT.Name_Product;
                traderTransactionDTO.seedName = p.PRODUCT_DETAIL.SEED.Name_Seed;
                traderTransactionDTO.farmName = p.SALE_OFFER_DETAIL.SALE_OFFER.FARM.Name_Farm;
                traderTransactionDTO.traderName = p.PURCHASE_OFFER_DETAIL.PURCHASE_OFFER.TRADER.Name_Trader;
                traderTransactionDTO.price = p.Transaction_Price;
                traderTransactionDTO.quantity = p.SALE_OFFER_DETAIL.Quantity_SaleOfferDetail;
                traderTransactionDTO.unitName = p.Transaction_Mass;
                traderTransactionDTO.totalMoney = p.Transaction_TotalMoney;
                traderTransactionDTO.StatusName = p.STATUS_TRANS.Name_StatusTrans;
                traderTransactionDTO.invoiceImage = p.Image_Invoice;

                transactionDTOs.Add(traderTransactionDTO);
            }

            return Json(new { data = transactionDTOs }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Handler(string Command, int transactionId)
        {
            dao.ExecuteHandler(Command, transactionId);
            return Json(new object[] { new object() }, JsonRequestBehavior.AllowGet);
        }
    }
}