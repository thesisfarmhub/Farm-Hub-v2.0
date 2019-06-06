using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Dao.Farmer
{
    public class FarmDAO
    {
        readonly FarmHubDbContext db = null;

        public FarmDAO()
        {
            db = new FarmHubDbContext();

        }

        // ListAllByFarmerID
        public List<FARM> ListFarmByFarmerID(int farmerID)
        {
            return db.FARMs.Where(x => x.Id_Farmer == farmerID && x.Is_Deleted == false).OrderByDescending(x => x.Id_Farm).ToList();
        }

        // ListAllInclude
        public List<PRODUCT_DETAIL> ListAllInclude()
        {
            var productDetailDAO = new ProductDetailDAO();
            return productDetailDAO.ListAllIncludeFarmAndSeed();
        }

        // ListAll
        public List<FARM> ListAll()
        {
            return db.FARMs.Where(x => x.Id_Farm > 0).OrderByDescending(x => x.Id_Farm).ToList();
        }

        // Detail
        public FARM Details(int id_Farm)
        {
            return db.FARMs.Find(id_Farm);
        }

        // Create
        public int Create(FARM farmModel)
        {
            farmModel.Is_Deleted = false;
            db.FARMs.Add(farmModel);
            db.SaveChanges();
            return farmModel.Id_Farm;
        }

        // Update
        public bool Update(FARM farmModel)
        {
            var targetUpdate = db.FARMs.Find(farmModel.Id_Farm);

            try
            {
                targetUpdate.Id_Farmer = farmModel.Id_Farmer;
                targetUpdate.Name_Farm = farmModel.Name_Farm;
                targetUpdate.Address_Farm = farmModel.Address_Farm;
                targetUpdate.City_Farm = farmModel.City_Farm;
                targetUpdate.Acreage = farmModel.Acreage;
                targetUpdate.Description_Farm = farmModel.Description_Farm;
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
        public bool Delete(int id_Farm)
        {
            try
            {
                var targetDelete = db.FARMs.Find(id_Farm);
                //db.FARMs.Remove(targetDelete);
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
