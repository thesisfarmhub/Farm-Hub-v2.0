using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Dao.Farmer
{
    public class SeedDAO
    {
        readonly FarmHubDbContext db = null;

        public SeedDAO()
        {
            db = new FarmHubDbContext();
        }

        // ListAll
        public List<SEED> ListAll()
        {
            return db.SEEDs.Where(x => x.Id_Seed > 0).OrderByDescending(x => x.Id_Seed).ToList();
        }

        // ListAllActive
        public List<SEED> ListAllActive()
        {
            return db.SEEDs.Where(x => x.Is_Deleted == false).OrderByDescending(x => x.Id_Seed).ToList();
        }

        // Detail
        public SEED Details(int id_Seed)
        {
            return db.SEEDs.Find(id_Seed);
        }

        // Create
        public int Create(SEED seedModel)
        {
            seedModel.Is_Deleted = false;
            db.SEEDs.Add(seedModel);
            db.SaveChanges();
            return seedModel.Id_Seed;
        }

        // Update
        public bool Update(SEED seedModel)
        {
            var targetUpdate = db.SEEDs.Find(seedModel.Id_Seed);

            try
            {
                targetUpdate.Name_Seed = seedModel.Name_Seed;
                targetUpdate.Code_Seed = seedModel.Code_Seed;
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
        public bool Delete(int id_Seed)
        {
            try
            {
                var targetDelete = db.SEEDs.Find(id_Seed);
                //db.SEEDs.Remove(targetDelete);
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
