using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmHub.Common;
using FarmHub;

namespace Model.Dao.Authentication
{
    public class EditPasswordDao
    {
        FarmHubDbContext db = null;
        public EditPasswordDao()
        {
            db = new FarmHubDbContext();
        }

       
        public string MatchPassword(int userID, string passWord)
        {
            
         
            var result = db.USER_AUTHENTICATION.SingleOrDefault(x => x.Id_User == userID /*&& x.Password_User == passWord*/);
            if (result == null)
            {
                return "InCorrect";
            }
            else
            {
                return "Succeed";   
            }

        }

        public Boolean Update(int userID, string newPassWord)
        {
            try
            {
                

                var user = db.USER_AUTHENTICATION.Find(userID);
                //user.Name_User = user.Name_User;
                //user.Id_User = user.Id_User;
                user.Password_User = newPassWord;
                
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
