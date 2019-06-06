using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.Admin
{
    public class ProductDao
    {
        FarmHubDbContext db = null;
        public ProductDao()
        {
            db = new FarmHubDbContext();
        }

        public IEnumerable<PRODUCT> ListProduct()
        {
            return db.PRODUCTs.Where(x => x.Is_Deleted == false).OrderByDescending(x => x.Id_Product);
        }

        public void Create(PRODUCT model)
        {
            model.Is_Deleted = false;

            db.PRODUCTs.Add(model);
            db.SaveChanges();
        }

        public PRODUCT Details(int id_Product)
        {
            return db.PRODUCTs.Find(id_Product);
        }

        public void Edit(PRODUCT model)
        {
            var targetUpdate = db.PRODUCTs.Find(model.Id_Product);

            targetUpdate.Id_ProductKind = model.Id_ProductKind;
            targetUpdate.Name_Product = model.Name_Product;
            targetUpdate.Image_Product = model.Image_Product;

            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var model = db.PRODUCTs.Find(id);
            model.Is_Deleted = true;

            db.SaveChanges();
        }

        public IEnumerable<PRODUCT_KIND> GetProductKind()
        {
            return db.PRODUCT_KIND.Where(x => x.Is_Deleted == false).OrderBy(x => x.Id_ProductKind);
        }

      
    }
}
