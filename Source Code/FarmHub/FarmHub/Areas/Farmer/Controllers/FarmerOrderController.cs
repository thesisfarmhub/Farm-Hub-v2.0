using Model.Dao.Farmer;
using Model.DTO.Farmer;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmHub.Areas.Farmer.Controllers
{
    public class FarmerOrderController : Controller
    {
        FarmerOrderDao dao = new FarmerOrderDao();
        
        public ActionResult FarmerOrderIndex(int purchaseOfferId)
        {
            var farmerId = Convert.ToInt32(Session["FarmerId"]);
            FarmerOrderDTO farmerOrder = new FarmerOrderDTO();
           
            farmerOrder.purchaseOfferDetail = PurchaseOfferDetail(purchaseOfferId);

            var productId = farmerOrder.purchaseOfferDetail.Id_Product;
            var seedId = farmerOrder.purchaseOfferDetail.Id_Seed;

            farmerOrder.farms = FarmList(farmerId,productId, seedId);
            farmerOrder.productDetailId = ProducDetail(productId, seedId).Id_ProductDetail;

            return View(farmerOrder);
        }

        //[HttpGet]
        //public JsonResult ProductDetailList(int idFarm ,int purchaseOfferId)
        //{
        //    var dao = new FarmerOrderDao();
        //    var productDetaillist = dao.ProductDetailList(idFarm, purchaseOfferId);

        //    List<ProductDetailDTO> productDTOs = new List<ProductDetailDTO>();

        //    foreach (var item in productDetaillist)
        //    {
        //        ProductDetailDTO productDetail = new ProductDetailDTO();
        //        productDetail.id = item.Id_ProductDetail;
        //        productDetail.productName = item.PRODUCT.Name_Product;
        //        productDetail.seedname = item.SEED.Name_Seed;
        //        productDetail.cropName = item.Name_Crop;
        //        productDTOs.Add(productDetail);
        //    }

        //    return Json(new { data = productDTOs }, JsonRequestBehavior.AllowGet);
        //}


        public IEnumerable<FarmDTO> FarmList(int farmerId,int? productId, int? seedId)
        {
            
            var dao = new FarmerOrderDao();
            var farmlist = dao.FarmList(farmerId, productId, seedId);

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

        public PRODUCT_DETAIL ProducDetail(int? productId, int? seedId)
        {
            return dao.GetProductDetail(productId, seedId);
        }

        public PURCHASE_OFFER PurchaseOfferDetail(int purchaseOfferId)
        {
            var purchaseDetail = dao.purchaseDetail(purchaseOfferId);

            return purchaseDetail;
        }

        
        [HttpPost]
        public ActionResult CreateOffer(FarmerOrderDTO model,int farmId, int purchaseOfferId, string counterOffered)
        {

            var dao = new FarmerOrderDao();
            dao.Insert(model, farmId, purchaseOfferId, counterOffered);
            return RedirectToAction("FarmerOfferIndex", "FarmerOffer");
        }

    }
}