using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Dao.Authentication
{
    public class UserAuthenDAO
    {
        readonly FarmHubDbContext db = null;

        public UserAuthenDAO()
        {
            db = new FarmHubDbContext();

        }

        // ListAll
        public List<USER_AUTHENTICATION> ListAll()
        {
            return db.USER_AUTHENTICATION.Where(x => x.Id_User > 0).OrderByDescending(x => x.Id_User).ToList();
        }

        // ListAllActive
        public List<USER_AUTHENTICATION> ListAllActive()
        {
            return db.USER_AUTHENTICATION.Where(x => x.Status_User == true).OrderByDescending(x => x.Id_User).ToList();
        }

        // Detail
        public USER_AUTHENTICATION Details(int id_UserAuthen)
        {
            return db.USER_AUTHENTICATION.Find(id_UserAuthen);
        }

        // Create
        public int Create(USER_AUTHENTICATION userAuthenModel)
        {
            userAuthenModel.Created_Date = DateTime.Now;
            userAuthenModel.Status_User = true;
            db.USER_AUTHENTICATION.Add(userAuthenModel);
            db.SaveChanges();
            return userAuthenModel.Id_User;
        }

        // Update
        public bool Update(USER_AUTHENTICATION userAuthenModel)
        {
            var targetUpdate = db.USER_AUTHENTICATION.Find(userAuthenModel.Id_User);

            try
            {
                targetUpdate.Id_UserKind = userAuthenModel.Id_UserKind;
                targetUpdate.Name_User = userAuthenModel.Name_User;
                targetUpdate.Password_User = userAuthenModel.Password_User;
                targetUpdate.Created_Date = userAuthenModel.Created_Date;
                targetUpdate.Status_User = userAuthenModel.Status_User;
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
        public bool Delete(int id_UserAuthen)
        {
            try
            {
                var targetDelete = db.USER_AUTHENTICATION.Find(id_UserAuthen);
                db.USER_AUTHENTICATION.Remove(targetDelete);
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
