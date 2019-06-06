using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Dao.Farmer
{
    public class ProductKindDAO
    {
        readonly FarmHubDbContext db = null;

        public ProductKindDAO()
        {
            db = new FarmHubDbContext();

        }

        // ListAll
        public List<PRODUCT_KIND> ListAll()
        {
            return db.PRODUCT_KIND.Where(x => x.Id_ProductKind > 0).OrderByDescending(x => x.Id_ProductKind).ToList();
        }

        // ListAllActive
        public List<PRODUCT_KIND> ListAllActive()
        {
            return db.PRODUCT_KIND.Where(x => x.Is_Deleted == false).OrderByDescending(x => x.Id_ProductKind).ToList();
        }

        // Detail
        public PRODUCT_KIND Details(int id_PK)
        {
            return db.PRODUCT_KIND.Find(id_PK);
        }

        // Create
        public int Create(PRODUCT_KIND productKindModel)
        {
            productKindModel.Is_Deleted = false;
            db.PRODUCT_KIND.Add(productKindModel);
            db.SaveChanges();
            return productKindModel.Id_ProductKind;
        }

        // Update
        public bool Update(PRODUCT_KIND pkModel)
        {
            var targetUpdate = db.PRODUCT_KIND.Find(pkModel.Id_ProductKind);

            try
            {
                targetUpdate.Name_ProductKind = pkModel.Name_ProductKind;
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
        public bool Delete(int id_PK)
        {
            try
            {
                var targetDelete = db.PRODUCT_KIND.Find(id_PK);
                //db.PRODUCT_KIND.Remove(targetDelete);
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
