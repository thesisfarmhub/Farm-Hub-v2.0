using FarmHub.Areas.Farmer.Models;
using Model.Dao.Authentication;
using Model.Dao.Farmer;
using Model.DTO.Farmer;
using Model.DTO.Trader;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FarmHub.Areas.Farmer.Controllers
{
    public class FarmerController : Controller
    {
        // Trang Chủ Farmer
        public ActionResult Index()
        {
            // Session
            var session = Convert.ToInt32(Session["FarmerID"]);

            var listSaleOfferLimit = saleOfferDao.ListSaleOfferByFarmerID(session, 5); // only show litmit SO on Home Page
            var listSaleOffer = saleOfferDao.ListSaleOfferByFarmerID(session);
            var suitablePurchaseOffer = saleOfferDao.SuitablePurchaseOffer(listSaleOffer, 1); // only show litmit suitable on Home Page
            var listTopProducts = saleOfferDao.ListTopProductDetails();

            var farmerHomePageModel = new FarmerHomePageModel
            {
                ListSaleOffer = listSaleOfferLimit,
                SuitablePurchaseOffer = suitablePurchaseOffer,
                FarmerListTopProduct = listTopProducts
            };

            #region Chart Purchase Offer

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

            #endregion

            #region Chart Sale Offer

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

            #endregion

            return View(farmerHomePageModel);
        }

        // ChartJS
        public ActionResult Dashboard()
        {
            var list = new FarmHubDbContext().PURCHASE_OFFER.Where(x => x.Is_Deleted == false).ToList();
            List<int> repartition = new List<int>();
            List<int> prices = new List<int>();
            var productNames = list.Select(x => x.PRODUCT.Name_Product).Distinct();
            var quantityPurchaseOffer = list.GroupBy(x => x.PRODUCT.Name_Product).ToString();

            foreach(var item in productNames)
            {
                repartition.Add(list.Count(x => x.PRODUCT.Name_Product == item));
            }

            foreach(var item in quantityPurchaseOffer)
            {
                prices.Add(item);
            }

            ViewBag.PRODUCTNAMES = productNames;
            ViewBag.REP = repartition.ToList();
            ViewBag.PRICES = prices.ToList();
            return View();
        }

        #region Function

        readonly FarmerDAO dao = new FarmerDAO();

        readonly SaleOfferDAO saleOfferDao = new SaleOfferDAO();

        // SetViewBagUserAuthen
        public void SetViewBagUserAuthen()
        {
            var dao = new UserAuthenDAO();
            ViewBag.Id_User = new SelectList(dao.ListAllActive(), "Id_User", "Name_User");
        }

        readonly PurchaseOfferDao purchaseOfferDAO = new PurchaseOfferDao();

        #endregion
    }
}
