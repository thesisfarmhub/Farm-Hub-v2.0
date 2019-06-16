using FarmHub.Areas.Farmer.Models;
using FarmHub.Common;
using Model.Dao.Authentication;
using Model.Dao.Farmer;
using Model.DTO.Farmer;
using Model.DTO.Trader;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace FarmHub.Areas.Farmer.Controllers
{
    public class FarmerController : Controller
    {
        // Trang Chủ Farmer
        public ActionResult Index()
        {
            // Session
            var session = Convert.ToInt32(Session["FarmerID"]);
            var listSaleOffer = saleOfferDao.ListSaleOfferByFarmerID(session);
            //
            var listSaleOfferLimit = saleOfferDao.ListSaleOfferByFarmerID(session, 5); // only show litmit SO on Home Page           
            var suitablePurchaseOffer = new List<List<PURCHASE_OFFER>>();
            var purchaseOfferYouMayLike = saleOfferDao.PurchaseOfferYouMayLike(session);
            var listTopProducts = saleOfferDao.ListTopProductDetails();
            //
            if (listSaleOffer.Count() > 0) 
            {
                suitablePurchaseOffer = saleOfferDao.SuitablePurchaseOffer(listSaleOffer, 1); // only show litmit suitable on Home Page

                var farmerHomePageModel = new FarmerHomePageModel
                {
                    ListSaleOffer = listSaleOfferLimit,
                    SuitablePurchaseOffer = suitablePurchaseOffer,
                    FarmerListTopProduct = listTopProducts,
                    PurchaseOfferYouMayLike = purchaseOfferYouMayLike
                };

                ChartPurchaseOffer();
                ChartSaleOffer();

                return View(farmerHomePageModel);

            }
            else
            {
                var farmerHomePageModel = new FarmerHomePageModel
                {
                    ListSaleOffer = listSaleOfferLimit,
                    SuitablePurchaseOffer = suitablePurchaseOffer,
                    FarmerListTopProduct = listTopProducts,
                    PurchaseOfferYouMayLike = purchaseOfferYouMayLike
                };

                ChartPurchaseOffer();
                ChartSaleOffer();

                return View(farmerHomePageModel);
            }
        }

        public ActionResult Logout()
        {
            Session[Constant.USER_SESSION] = null;
            return RedirectToRoute("Farmer", new RouteValueDictionary(new { action = "Logout", controller = "Login" }));
        }

        public ActionResult Account()
        {
            var farmerID = Session["FarmerID"];
            var farmer = new FarmHubDbContext().FARMERs.Find(farmerID);
            return View(farmer);
        }

        [HttpPost]
        public ActionResult Account(FARMER farmer)
        {
            var result = dao.Update(farmer);

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật thất bại !!!");
                var farmerModelState = dao.Details(farmer.Id_Farmer);
                return View(farmerModelState);
            }


        }

        #region Function

        readonly FarmerDAO dao = new FarmerDAO();

        readonly SaleOfferDAO saleOfferDao = new SaleOfferDAO();

        readonly PurchaseOfferDao purchaseOfferDAO = new PurchaseOfferDao();

        // SetViewBagUserAuthen
        public void SetViewBagUserAuthen()
        {
            var dao = new UserAuthenDAO();
            ViewBag.Id_User = new SelectList(dao.ListAllActive(), "Id_User", "Name_User");
        }

        // ChartJS
        public void ChartPurchaseOffer()
        {
            var listPO = purchaseOfferDAO.ListAllActive();

            var productNames = listPO.Select(x => x.PRODUCT.Name_Product).Distinct();
            ViewBag.PRODUCTNAMES = productNames; // Label: Product Names

            var purchaseOfferChartDTO = listPO.GroupBy(x => x.PRODUCT.Name_Product).Select(x => new PurchaseOfferChartDTO
            {
                NumberOfOrders = x.Select(id => id.Id_PurchasesOffer).Count(),
                PurchaseOfferAvgPrice = (int)x.Average(p => p.Price_Purchase),
                PurchaseOfferTotalQuantity = (int)x.Sum(qu => qu.Quantity_PurchaseOffer)
            }).ToList();

            List<int> prices = new List<int>();
            foreach (var item in purchaseOfferChartDTO)
            {
                prices.Add(item.PurchaseOfferAvgPrice);
            }
            ViewBag.PRICES = prices.ToList(); // Data: Prices

            List<int> numberOfOffers = new List<int>();
            foreach (var item in purchaseOfferChartDTO)
            {
                numberOfOffers.Add(item.NumberOfOrders);
            }
            ViewBag.NUMBEROFOFFERS = numberOfOffers; // Number of orders
        }

        public void ChartSaleOffer()
        {
            var session = Convert.ToInt32(Session["FarmerID"]);
            var listSaleOffer = saleOfferDao.ListSaleOfferByFarmerID(session);

            var saleOfferProductNames = listSaleOffer.Select(x => x.PRODUCT_DETAIL.PRODUCT.Name_Product).Distinct();
            ViewBag.SO_PRODUCTNAMES = saleOfferProductNames.ToList(); // Label: Sale Offer Product Name

            var saleOfferChartDTO = listSaleOffer.GroupBy(x => x.PRODUCT_DETAIL.PRODUCT.Name_Product).Select(x => new SaleOfferChartDTO
            {
                NumberOfOrders = x.Select(id => id.Id_SaleOffer).Count(),
                SaleOfferAvgPrice = (int)x.Average(p => p.Price_Offer),
                SaleOfferTotalQuantity = (int)x.Sum(qu => qu.Quantity_SaleOffer)
            }).ToList();

            List<int> soPrices = new List<int>();
            foreach (var item in saleOfferChartDTO)
            {
                soPrices.Add(item.SaleOfferAvgPrice);
            }
            ViewBag.SO_PRICES = soPrices.ToList(); // Data: Sale Offer Prices

            List<int> soNumberOfOffers = new List<int>();
            foreach (var item in saleOfferChartDTO)
            {
                soNumberOfOffers.Add(item.NumberOfOrders);
            }
            ViewBag.SO_NUMBEROFOFFERS = soNumberOfOffers.ToList(); // Sale Offer Number Of Order
        }

        #endregion
    }
}
