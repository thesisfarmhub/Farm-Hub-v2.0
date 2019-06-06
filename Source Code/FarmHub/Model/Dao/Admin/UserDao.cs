using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using System.Data.SqlClient;
using System.Configuration;
namespace Model.Dao.Admin
{
    public class UserDao
    {
        FarmHubDbContext db = null;
        public UserDao()
        {
            db = new FarmHubDbContext();
        }

        public IEnumerable<USER_AUTHENTICATION> ListAllUser()
        {
            return db.USER_AUTHENTICATION.Where(x => x.Is_Deleted ==false).OrderByDescending(x => x.Created_Date);
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.USER_AUTHENTICATION.Find(id);
                db.USER_AUTHENTICATION.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



    }


}
