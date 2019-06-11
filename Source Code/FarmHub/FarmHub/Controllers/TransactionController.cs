using Model.Dao.Farmer;
using Model.Dao.Trader;
using Model.DTO.Trader;
using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmHub.Controllers
{
    public class TraderTransactionController : Controller
    {
        TraderTransactionDao dao =new TraderTransactionDao();
        // GET: Transaction
        public ActionResult TransactionIndex()
        {
            
            return View();
        }

        [HttpGet]
        public JsonResult GetListImportantTransaction()
        {
            var transactionList = dao.GetListTransaction();
            List<TraderTransactionDTO> transactionDTOs = new List<TraderTransactionDTO>();

            foreach (var p in transactionList)
            {
                var traderTransactionDTO = new TraderTransactionDTO();
                traderTransactionDTO.transId = p.Id_TransactionOrder;
                traderTransactionDTO.endTransDay = ((DateTime)p.Transaction_Date).ToShortDateString();
                traderTransactionDTO.productName = p.PRODUCT_DETAIL.PRODUCT.Name_Product;
                traderTransactionDTO.seedName = p.PRODUCT_DETAIL.SEED.Name_Seed;
                traderTransactionDTO.farmName = p.SALE_OFFER_DETAIL.SALE_OFFER.FARM.Name_Farm;
                traderTransactionDTO.farmerName = p.SALE_OFFER_DETAIL.SALE_OFFER.FARM.FARMER.Name_Farmer;
                traderTransactionDTO.price = p.Transaction_Price;
                traderTransactionDTO.quantity = p.Transaction_Mass;
                traderTransactionDTO.unitName = p.Transaction_Unitmass;
                traderTransactionDTO.totalMoney = p.Transaction_TotalMoney;
                traderTransactionDTO.StatusName = p.STATUS_TRANS.Name_StatusTrans;


                transactionDTOs.Add(traderTransactionDTO);
            }

            return Json(new { data = transactionDTOs }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Handler(string Command,int transactionId,TRANSACTION_ORDER model)
        {
            if (model.ImageFile != null)
            {
                string fileName = null;
                string fileExtension = null;

                fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                fileExtension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + fileExtension;

                model.Image_Invoice = "/Data/Image/Trader/Invoices/" + fileName;
                fileName = Path.Combine(Server.MapPath("/Data/Image/Trader/Invoices/"), fileName);
                model.ImageFile.SaveAs(fileName);
            }

            dao.ExecuteHandler(Command, transactionId);
            return Json(new object[] { new object() }, JsonRequestBehavior.AllowGet);
        }
        
    }
}