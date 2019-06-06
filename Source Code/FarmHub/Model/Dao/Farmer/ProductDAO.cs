using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Dao.Farmer
{
    public class ProductDAO
    {
        readonly FarmHubDbContext db = null;

        public ProductDAO()
        {
            db = new FarmHubDbContext();

        }

        // ListAll
        public List<PRODUCT> ListAll()
        {
            return db.PRODUCTs.Where(x => x.Id_Product > 0).OrderByDescending(x => x.Id_Product).ToList();
        }

        // ListAllActive
        public List<PRODUCT> ListAllActive()
        {
            return db.PRODUCTs.Where(x => x.Is_Deleted == false).OrderByDescending(x => x.Id_Product).ToList();
        }

        // Detail
        public PRODUCT Details(int id_Product)
        {
            return db.PRODUCTs.Find(id_Product);
        }

        // Create
        public int Create(PRODUCT productModel)
        {
            productModel.Is_Deleted = false;
            db.PRODUCTs.Add(productModel);
            db.SaveChanges();
            return productModel.Id_Product;
        }

        // Update
        public bool Update(PRODUCT productModel)
        {
            var targetUpdate = db.PRODUCTs.Find(productModel.Id_Product);

            try
            {
                targetUpdate.Id_ProductKind = productModel.Id_ProductKind;
                targetUpdate.Name_Product = productModel.Name_Product;
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
        public bool Delete(int id_Product)
        {
            try
            {
                var targetDelete = db.PRODUCTs.Find(id_Product);
                //db.PRODUCTs.Remove(targetDelete);
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
