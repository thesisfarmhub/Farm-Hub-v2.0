using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao.Authentication
{
    public class LoginDao
    {
        FarmHubDbContext db = null;
        public LoginDao()
        {
            db = new FarmHubDbContext();
        }


        /*
         *  0  - "Tài Khoản hoặc mật khẩu ko chính xác": "InCorrect"
         * -1  - "Tài khoản đã bị khóa"  : "Locked"
         *  1  - "Đăng nhập thành công"  : "Succeed"
         */
        public string Login(string userName, string passWord)
        {

            var result = db.USER_AUTHENTICATION.SingleOrDefault(x => x.Name_User == userName && x.Password_User == passWord);
            if (result == null)
            {
                return "InCorrect";
            }
            else
            {
                if (result.Status_User == 0)
                {
                    return "Locked";
                }
                else
                {
                    return "Succeed";
                }
            }
        }

        public USER_AUTHENTICATION GetUserByID(string username)
        {
            return db.USER_AUTHENTICATION.SingleOrDefault(x => x.Name_User == username);
        }
    }
}
