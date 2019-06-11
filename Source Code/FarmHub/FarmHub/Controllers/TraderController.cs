using FarmHub.Models;
using Model.Dao.Farmer;
using Model.DTO.Farmer;
using Model.DTO.Trader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FarmHub.Controllers
{
    public class TraderController : Controller
    {
        public ActionResult Index()
        {
            var session = Convert.ToInt32(Session["TraderID"]);

            var listPurchaseOffer = purchaseOfferDAO.ListPOByTraderID(session, 5); // Show list PO limit on Home Page

            var listPO = purchaseOfferDAO.ListPOByTraderID(session); // Full list PO

            var suitalbleSaleOffers = purchaseOfferDAO.SuitalbeSaleOffers(listPO, 1); // Show list suitable limit on Home Page

            var listTopProducts = purchaseOfferDAO.ListTopProductDetails();

            var traderHomePageModel = new TraderHomePageModel
            {
                ListPurchaseOffer = listPurchaseOffer,
                SuitalbeSaleOffers = suitalbleSaleOffers,
                ListTopProducts = listTopProducts
            };

            // ChartJS        
            
            #region Chart Purchase Offer

            var productNames = listPO.Select(x => x.PRODUCT.Name_Product).Distinct();
            ViewBag.PRODUCTNAMES = productNames.ToList(); // Label: Product Names

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
            ViewBag.NUMBEROFOFFERS = numberOfOffers.ToList(); // Number of orders
            #endregion

            #region Chart Sale Offer

            var listSO = saleOfferDao.ListAllActive();

            var saleOfferProductNames = listSO.Select(x => x.PRODUCT_DETAIL.PRODUCT.Name_Product).Distinct();
            ViewBag.SO_PRODUCTNAMES = saleOfferProductNames.ToList(); // Label: Sale Offer Product Name

            var saleOfferChartDTO = listSO.GroupBy(x => x.PRODUCT_DETAIL.PRODUCT.Name_Product).Select(x => new SaleOfferChartDTO
            {
                NumberOfOrders = x.Select(id => id.Id_SaleOffer).Count(),
                SaleOfferAvgPrice = (int)x.Average(p => p.Price_Offer),
                SaleOfferTotalQuantity = (int)x.Sum(qu => qu.Quantity_SaleOffer)
            }).ToList();

            List<int> soPrices = new List<int>();
            foreach(var item in saleOfferChartDTO)
            {
                soPrices.Add(item.SaleOfferAvgPrice);
            }
            ViewBag.SO_PRICES = soPrices.ToList(); // Data: Sale Offer Prices

            List<int> soNumberOfOffers = new List<int>();
            foreach(var item in saleOfferChartDTO)
            {
                soNumberOfOffers.Add(item.NumberOfOrders);
            }
            ViewBag.SO_NUMBEROFOFFERS = soNumberOfOffers.ToList(); // Sale Offer Number Of Order

            #endregion

            return View(traderHomePageModel);
        }

        #region Function 

        readonly Model.Dao.Trader.PurchaseOfferDao purchaseOfferDAO = new Model.Dao.Trader.PurchaseOfferDao();
        readonly SaleOfferDAO saleOfferDao = new SaleOfferDAO();

        #endregion
    }
}