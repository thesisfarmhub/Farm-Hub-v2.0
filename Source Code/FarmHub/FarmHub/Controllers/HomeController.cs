using FarmHub.Models;
using Model.Dao.Farmer;
using Model.DTO.Trader;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FarmHub.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home => List Sale Offer : Chỉ là lấy thông tin từ DB show ra thôi. Sau khi Trader login thì sẽ có 1 Home Page riêng của Trader
        public ActionResult Index()
        {
            var listPurchaseOffer = purchaseOfferDAO.ListAllLimit();
            var suitalbleSaleOffers = purchaseOfferDAO.SuitalbeSaleOffers(listPurchaseOffer);
            var listTopProducts = purchaseOfferDAO.ListTopProductDetails();

            var homePageModel = new HomePageModel
            {
                ListPurchaseOffer = listPurchaseOffer,
                SuitalbeSaleOffers = suitalbleSaleOffers,
                ListTopProducts = listTopProducts
            };

            // ChartJS
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

            return View(homePageModel);
        }

        #region Function

        readonly PurchaseOfferDao purchaseOfferDAO = new PurchaseOfferDao();

        #endregion

    }
}