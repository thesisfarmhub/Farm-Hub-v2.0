using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Dao.Admin
{
    public class SeedDao
    {
        FarmHubDbContext db = null;
        public SeedDao()
        {
            db = new FarmHubDbContext();
        }

        public IEnumerable<SEED> ListSeed()
        {
            return db.SEEDs.Where(x => x.Is_Deleted == false);
        }

        public bool Create(SEED seed)
        {
            try
            {
                seed.Is_Deleted = false;
                db.SEEDs.Add(seed);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(SEED seed)
        {
            try
            {
                var targetEdit = db.SEEDs.Find(seed.Id_Seed);
                targetEdit.Id_Product = seed.Id_Product;
                targetEdit.Name_Seed = seed.Name_Seed;
                targetEdit.Code_Seed = seed.Code_Seed;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public SEED Details(int id_Seed)
        {
            return db.SEEDs.Find(id_Seed);
        }

        public void Delete(int id)
        {
            var model = db.SEEDs.Find(id);
            model.Is_Deleted = true;

            db.SaveChanges();
        }
    }
}
