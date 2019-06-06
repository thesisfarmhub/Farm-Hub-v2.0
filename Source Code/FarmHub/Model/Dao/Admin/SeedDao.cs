using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Delete(int id)
        {
            var model = db.SEEDs.Find(id);
            model.Is_Deleted = true;

            db.SaveChanges();
        }
    }
}
