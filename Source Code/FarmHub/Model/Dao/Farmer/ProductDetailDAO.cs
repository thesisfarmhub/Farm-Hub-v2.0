using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Dao.Farmer
{
    public class ProductDetailDAO
    {
        readonly FarmHubDbContext db = null;

        public ProductDetailDAO()
        {
            db = new FarmHubDbContext();
        }

        // ListAllIncludeFarm
        public List<PRODUCT_DETAIL> ListAllIncludeFarmAndSeed()
        {
            return db.PRODUCT_DETAIL.Include("FARM").Include("SEED").Where(x => x.Is_Deleted == false).ToList();
        }

        // ListAll
        public List<PRODUCT_DETAIL> ListAll()
        {
            return db.PRODUCT_DETAIL.Where(x => x.Id_ProductDetail > 0).OrderByDescending(x => x.Id_ProductDetail).ToList();
        }

        // ListAllActive
        public List<PRODUCT_DETAIL> ListAllActive()
        {
            return db.PRODUCT_DETAIL.Where(x => x.Is_Deleted == false).OrderByDescending(x => x.Id_ProductDetail).ToList();
        }

        // List Product Details By Farm ID
        public List<PRODUCT_DETAIL> ListAllByFarmID(int farmID)
        {
            return db.PRODUCT_DETAIL.Where(x => x.Id_Farm == farmID && x.Is_Deleted == false).OrderByDescending(x => x.Id_ProductDetail).ToList();
        }

        // Detail
        public PRODUCT_DETAIL Details(int productDetailsID)
        {
            return db.PRODUCT_DETAIL.Find(productDetailsID);
        }

        // Create
        public int Create(PRODUCT_DETAIL productDetailModel)
        {
            try
            {
                productDetailModel.Is_Deleted = false;
                db.PRODUCT_DETAIL.Add(productDetailModel);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
            return productDetailModel.Id_ProductDetail;
        }

        // Update
        public bool Update(PRODUCT_DETAIL productDetailModel)
        {
            var targetUpdate = db.PRODUCT_DETAIL.Find(productDetailModel.Id_ProductDetail);

            try
            {
                targetUpdate.Id_Product = productDetailModel.Id_Product;
                targetUpdate.Id_Farm = productDetailModel.Id_Farm;
                targetUpdate.Id_Seed = productDetailModel.Id_Seed;
                targetUpdate.Name_Crop = productDetailModel.Name_Crop;
                targetUpdate.Start_Time = productDetailModel.Start_Time;
                targetUpdate.End_Time = productDetailModel.End_Time;
                targetUpdate.Harvest_StartTime = productDetailModel.Harvest_StartTime;
                targetUpdate.Harvest_EndTime = productDetailModel.Harvest_EndTime;
                targetUpdate.Geography_Location = productDetailModel.Geography_Location;
                targetUpdate.Quantity_Expected = productDetailModel.Quantity_Expected;
                targetUpdate.Image_ProductDetail = productDetailModel.Image_ProductDetail;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
        }

        // Delete
        public bool Delete(int id_PD)
        {
            try
            {
                var targetDelete = db.PRODUCT_DETAIL.Find(id_PD);
                //db.PRODUCT_DETAIL.Remove(targetDelete);
                targetDelete.Is_Deleted = true;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
        }

    }
}
