using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Dao.Farmer
{
    public class FarmerDAO
    {
        readonly FarmHubDbContext db = null;

        public FarmerDAO()
        {
            db = new FarmHubDbContext();
        }

        // ListAll
        public List<FARMER> ListAll()
        {
            return db.FARMERs.Where(x => x.Id_Farmer > 0).OrderByDescending(x => x.Id_Farmer).ToList();
        }

        // ListAllActive
        public List<FARMER> ListAllActive()
        {
            return db.FARMERs.Where(x => x.Is_Deleted == false).OrderByDescending(x => x.Id_Farmer).ToList();
        }

        // GetFarmerNameByFarmerID
        public string GetFarmerNameByFarmerID(int farmerID)
        {
            return db.FARMERs.Find(farmerID).Name_Farmer.ToString();
        }

        // GetFarmerByUserID
        public FARMER GetFarmerByUserID(int userID)
        {
            return new FarmHubDbContext().FARMERs.FirstOrDefault(x => x.Id_User == userID);
        }

        // Detail
        public FARMER Details(int id_Farmer)
        {
            return db.FARMERs.Find(id_Farmer);
        }

        // Create
        public int Create(FARMER farmerModel)
        {
            farmerModel.Is_Deleted = false;
            db.FARMERs.Add(farmerModel);
            db.SaveChanges();
            return farmerModel.Id_Farmer;
        }

        // Update
        public bool Update(FARMER farmerModel)
        {
            var targetUpdate = db.FARMERs.Find(farmerModel.Id_Farmer);

            try
            {
                targetUpdate.Id_User = farmerModel.Id_User;
                targetUpdate.Name_Farmer = farmerModel.Name_Farmer;
                targetUpdate.Birthday_Farmer = farmerModel.Birthday_Farmer;
                targetUpdate.Gender_Farmer = farmerModel.Gender_Farmer;
                targetUpdate.Address_Farmer = farmerModel.Address_Farmer;
                targetUpdate.Telephone_Farmer = farmerModel.Telephone_Farmer;
                targetUpdate.Email_Farmer = farmerModel.Email_Farmer;
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
        public bool Delete(int id_Farmer)
        {
            try
            {
                var targetDelete = db.FARMERs.Find(id_Farmer);
                //db.FARMERs.Remove(targetDelete);
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
