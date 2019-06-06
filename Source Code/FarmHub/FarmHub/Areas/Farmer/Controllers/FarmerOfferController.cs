using Model.Dao.Farmer;
using Model.DTO.Farmer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmHub.Areas.Farmer.Controllers
{
    public class FarmerOfferController : Controller
    {

        public ActionResult FarmerOfferIndex()
        {
            int id = Convert.ToInt32(Session["UserId"]);
            var dao = new FarmerOfferDao();

            FarmerOfferDTO farmerOfferDTO = new FarmerOfferDTO();

            farmerOfferDTO.units = UnitList();
            farmerOfferDTO.farms = FarmList(id);

            return View(farmerOfferDTO);
        }

        [HttpGet]
        public JsonResult ProductDetailList(int idFarm)
        {
            var dao = new FarmerOfferDao();
            var productDetaillist = dao.ProductDetailList(idFarm);

            List<ProductDetailDTO> productDTOs = new List<ProductDetailDTO>();

            foreach (var item in productDetaillist)
            {
                ProductDetailDTO productDetail = new ProductDetailDTO();
                productDetail.id = item.Id_ProductDetail;
                productDetail.productName = item.PRODUCT.Name_Product;
                productDetail.seedname = item.SEED.Name_Seed;
                productDetail.cropName = item.Name_Crop;
                productDTOs.Add(productDetail);
            }

            return Json(new { data = productDTOs }, JsonRequestBehavior.AllowGet);
        }


        public IEnumerable<FarmDTO> FarmList(int userId)
        {
            var dao = new FarmerOfferDao();
            var farmlist = dao.FarmList(userId);

            List<FarmDTO> farmDTOs = new List<FarmDTO>();

            foreach (var item in farmlist)
            {
                FarmDTO farm = new FarmDTO();
                farm.id = item.Id_Farm;
                farm.name = item.Name_Farm;

                farmDTOs.Add(farm);
            }
            return farmDTOs;

        }

        public IEnumerable<UnitMassDTO> UnitList()
        {
            var dao = new FarmerOfferDao();
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



        [HttpGet]
        public JsonResult GetListSale()
        {
            var FarmerId = Convert.ToInt32(Session["FarmerId"]);


            var salelList = new SaleOfferDAO().getSaleOfferByIdUser(FarmerId);
            List<SaleOfferDTO> saleOfferDTOs = new List<SaleOfferDTO>();

            foreach (var s in salelList)
            {
                var saleOfferDTO = new SaleOfferDTO();
                saleOfferDTO.saleOfferid = s.Id_SaleOffer;
                saleOfferDTO.canBargain = s.Can_Bargain;
                saleOfferDTO.createdDate = ((DateTime)s.Date_SaleOffer).ToShortDateString();
                saleOfferDTO.farmName = s.FARM.Name_Farm;
                saleOfferDTO.productName = s.PRODUCT_DETAIL.PRODUCT.Name_Product;
                saleOfferDTO.seedName = s.PRODUCT_DETAIL.SEED.Name_Seed;
                saleOfferDTO.quantity = s.Quantity_SaleOffer;
                saleOfferDTO.massName = s.MASS_UNIT.Name_MassUnit;
                saleOfferDTO.price = s.Price_Offer;
                saleOfferDTO.numberOfOrder = s.Number_Of_Orders;

                saleOfferDTOs.Add(saleOfferDTO);
            }
            return Json(new { data = saleOfferDTOs }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetListPurchase()
        {
            var purchaselList = new PurchaseOfferDao().getPurchaseOffer();
            List<PurchaseOfferDTO> purchaseOfferDTOs = new List<PurchaseOfferDTO>();

            foreach (var p in purchaselList)
            {
                var purchaseOfferDTO = new PurchaseOfferDTO();
                purchaseOfferDTO.id = p.Id_PurchasesOffer;
                purchaseOfferDTO.canBargain = p.Can_Bargain;
                purchaseOfferDTO.createdDate = ((DateTime)p.Date_PurchaseOffer).ToShortDateString();
                purchaseOfferDTO.productName = p.PRODUCT.Name_Product;
                purchaseOfferDTO.seedName = p.SEED.Name_Seed;
                purchaseOfferDTO.quantity = p.Quantity_PurchaseOffer;
                purchaseOfferDTO.massName = p.MASS_UNIT.Name_MassUnit;
                purchaseOfferDTO.traderName = p.TRADER.Name_Trader;
                purchaseOfferDTO.price = p.Price_Purchase;
                purchaseOfferDTO.numberOfOrder = p.Number_Of_Orders;
                purchaseOfferDTO.payingTime = p.Paying_Time;
                purchaseOfferDTO.deliveringTime = p.Delivering_Time;

                purchaseOfferDTOs.Add(purchaseOfferDTO);
            }

            return Json(new { data = purchaseOfferDTOs }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateSaleOffer(SaleOfferDTO model)
        {
            var farmerId = Convert.ToInt32(Session["FarmerId"]);
            if (ModelState.IsValid)
            {
                var dao = new FarmerOfferDao();
                dao.Insert(model);
            }
            return Json(new object[] { new object() }, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult CallDeleteOffer(int id)
        {
            var dao = new FarmerOfferDao();
            dao.DeleteOffer(id);
            return Json(new object[] { new object() }, JsonRequestBehavior.AllowGet);
        }
    }
}