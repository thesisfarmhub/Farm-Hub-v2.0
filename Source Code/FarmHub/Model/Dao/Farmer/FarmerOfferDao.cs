using Model.DTO.Farmer;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.Farmer
{
    public class FarmerOfferDao
    {
        FarmHubDbContext db = null;
        public FarmerOfferDao()
        {
            db = new FarmHubDbContext();

        }

        public int Insert(SaleOfferDTO model)
        {
            SALE_OFFER saleModel = new SALE_OFFER();
            saleModel.Date_SaleOffer = DateTime.Now;
            saleModel.Can_Bargain = model.canBargain;
            saleModel.Id_Farm = model.farmId;
            saleModel.Id_ProductDetail = model.productDetailId;
            saleModel.Quantity_SaleOffer = model.quantity;
            saleModel.Id_MassUnit = model.idUnit;
            saleModel.Price_Offer = model.price;
            saleModel.Paying_Time = model.payingTime;
            saleModel.Delivering_Time = model.deliveringTime;
            saleModel.Remain_SaleQuantity = model.quantity;
            saleModel.Is_Deleted = false;
            db.SALE_OFFER.Add(saleModel);


            db.SaveChanges();

            return 1;
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

        public IEnumerable<MASS_UNIT> UnitList()
        {
            IQueryable<MASS_UNIT> model = db.MASS_UNIT;
            var unitList = model.Where(x => x.Is_Deleted == false);
            return unitList;
        }

        public IEnumerable<PRODUCT_DETAIL> ProductDetailList(int idFarm)
        {
            IQueryable<PRODUCT_DETAIL> model = db.PRODUCT_DETAIL;
            var productDetaiList = model.Where(x => x.Is_Deleted == false && x.Id_Farm == idFarm);
            return productDetaiList.OrderBy(x => x.PRODUCT.Name_Product);
        }

        public IEnumerable<FARM> FarmList(int userId)
        {
            IQueryable<FARM> model = db.FARMs;
            var farmList = model.Where(x => x.Is_Deleted == false && x.FARMER.Id_User == userId);
            return farmList;
        }
    }
}
