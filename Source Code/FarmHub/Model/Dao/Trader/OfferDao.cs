using Model.DTO.Trader;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.Trader
{
    public class OfferDao
    {
        FarmHubDbContext db = new FarmHubDbContext();
        public OfferDao()
        {
            var db = new FarmHubDbContext();
        }

        

        public void Insert(PurchaseOfferDTO model, int traderID)
        {
            
            PURCHASE_OFFER purchModel = new PURCHASE_OFFER();

            purchModel.Date_PurchaseOffer = DateTime.Now;
            purchModel.Can_Bargain = model.canBargain;
            purchModel.Id_Trader = traderID;
            purchModel.Id_Product = model.productID;
            purchModel.Id_Seed = model.seedId;
            purchModel.Quantity_PurchaseOffer = model.quantity;
            purchModel.Remain_PurchaseQuantity = model.quantity;
            purchModel.Id_MassUnit = model.unitId;
            purchModel.Price_Purchase = model.price;
            purchModel.Paying_Time = model.payingTime;
            purchModel.Delivering_Time = model.deliveringTime;
            purchModel.Is_Deleted = false;

            db.PURCHASE_OFFER.Add(purchModel);
            db.SaveChanges();
        }

        public bool DeleteOffer(int id)
        {
            try
            {
                var Offer = db.PURCHASE_OFFER.Find(id);
                Offer.Is_Deleted = true;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<PRODUCT> ProductList()
        {


            IQueryable<PRODUCT> model = db.PRODUCTs;
            var productList = model.Where(x => x.Is_Deleted == false);
            return productList;
        }

        public IEnumerable<MASS_UNIT> UnitList()
        {
            IQueryable<MASS_UNIT> model = db.MASS_UNIT;
            var unitList = model.Where(x => x.Is_Deleted == false);
            return unitList;
        }

        public IEnumerable<SEED> SeedList()
        {
            IQueryable<SEED> model = db.SEEDs;
            var seedList = model.Where(x => x.Is_Deleted == false);
            return seedList;
        }


    }
}
