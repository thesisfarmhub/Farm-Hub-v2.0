
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;


using Model.DTO.Trader;
using System.Web.Services;
using System.Web.Script.Serialization;
using Model.Dao.Trader;

namespace FarmHub.Controllers
{
    public class TraderOfferController : Controller
    {

        public ActionResult TraderOfferIndex()
        {

            TraderOfferDTO traderOfferDTO = new TraderOfferDTO();
            traderOfferDTO.products = ProductList();
            traderOfferDTO.units = UnitList();
            traderOfferDTO.seeds = SeedList();

            return View(traderOfferDTO);
        }

        public IEnumerable<ProductDTO> ProductList()
        {
            var dao = new OfferDao();
            var productlist = dao.ProductList();

            List<ProductDTO> productDTOs = new List<ProductDTO>();

            foreach (var item in productlist)
            {
                ProductDTO product = new ProductDTO();
                product.productid = item.Id_Product;
                product.productName = item.Name_Product;

                productDTOs.Add(product);
            }

            return productDTOs;
        }

        public IEnumerable<UnitMassDTO> UnitList()
        {
            var dao = new OfferDao();
            var unitlist = dao.UnitList();

            List<UnitMassDTO> unitDTOs = new List<UnitMassDTO>();

            foreach (var item in unitlist)
            {
                UnitMassDTO unit = new UnitMassDTO();
                unit.id = item.Id_MassUnit;
                unit.name = item.Name_MassUnit;

                unitDTOs.Add(unit);
            }
            return unitDTOs;

        }
        public IEnumerable<SeedDTO> SeedList()
        {
            var dao = new OfferDao();
            var seedlist = dao.SeedList();

            List<SeedDTO> seedDTOs = new List<SeedDTO>();

            foreach (var item in seedlist)
            {
                SeedDTO seed = new SeedDTO();
                seed.seedId = item.Id_Seed;
                seed.seedName = item.Name_Seed;

                seedDTOs.Add(seed);
            }
            return seedDTOs;

        }

        [HttpGet]
        public JsonResult GetListPurchase()
        {

            var Traderid = Convert.ToInt32(Session["TraderID"]);

            var purchaselList = new PurchaseOfferDao().getPurchaseOfferByID(Traderid);
            List<PurchaseOfferDTO> purchaseOfferDTOs = new List<PurchaseOfferDTO>();

            if (Traderid == 0)
            {
                purchaselList = new PurchaseOfferDao().getPurchaseOfferByIDForGuest();
            }

            foreach (var p in purchaselList)
            {
                var purchaseOfferDTO = new PurchaseOfferDTO();
                purchaseOfferDTO.purchOfferID = p.Id_PurchasesOffer;
                purchaseOfferDTO.canBargain = p.Can_Bargain;
                purchaseOfferDTO.createdDate = ((DateTime)p.Date_PurchaseOffer).ToShortDateString();
                purchaseOfferDTO.productName = p.PRODUCT.Name_Product;
                purchaseOfferDTO.seedName = p.SEED.Name_Seed;
                purchaseOfferDTO.quantity = p.Quantity_PurchaseOffer;
                purchaseOfferDTO.massName = p.MASS_UNIT.Name_MassUnit;
                purchaseOfferDTO.trueMass = p.MASS_UNIT.Weight_To_Kg * p.Quantity_PurchaseOffer;
                purchaseOfferDTO.price = p.Price_Purchase;
                purchaseOfferDTO.numberOfOrder = p.Number_Of_Orders;
                purchaseOfferDTO.payingTime = p.Paying_Time;
                purchaseOfferDTO.deliveringTime = p.Delivering_Time;
                purchaseOfferDTOs.Add(purchaseOfferDTO);
            }
            return Json(new { data = purchaseOfferDTOs }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetListSale()
        {
            var purchaselList = new SaleOfferDao().SaleListAllPaging();
            List<SaleOfferDTO> saleOfferDTOs = new List<SaleOfferDTO>();

            foreach (var p in purchaselList)
            {
                var saleOfferDTO = new SaleOfferDTO();
                saleOfferDTO.id = p.Id_SaleOffer;
                saleOfferDTO.canBargain = p.Can_Bargain;
                saleOfferDTO.createdDate = ((DateTime)p.Date_SaleOffer).ToShortDateString();
                saleOfferDTO.quantity = p.Quantity_SaleOffer;
                saleOfferDTO.farmName = p.FARM.Name_Farm;
                saleOfferDTO.massName = p.MASS_UNIT.Name_MassUnit;
                saleOfferDTO.trueMass = p.MASS_UNIT.Weight_To_Kg * p.Quantity_SaleOffer;
                saleOfferDTO.price = p.Price_Offer;
                saleOfferDTO.productName = p.PRODUCT_DETAIL.PRODUCT.Name_Product;
                saleOfferDTO.seedName = p.PRODUCT_DETAIL.SEED.Name_Seed;

                saleOfferDTOs.Add(saleOfferDTO);
            }

            return Json(new { data = saleOfferDTOs }, JsonRequestBehavior.AllowGet);
        }

       



        [HttpPost]
        public ActionResult CreatePurchaseOffer(PurchaseOfferDTO model)
        {
            var traderId = Convert.ToInt32(Session["TraderId"]);
            if (ModelState.IsValid)
            {
                var dao = new OfferDao();
                dao.Insert(model, traderId);
            }
            //return "{\"msg\":\"success\"}";
            return Json(new object[] { new object() }, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult CallDeleteOffer(int id)
        {
            var dao = new OfferDao();
            dao.DeleteOffer(id);
            return Json(new object[] { new object() }, JsonRequestBehavior.AllowGet);
        }
    }
}