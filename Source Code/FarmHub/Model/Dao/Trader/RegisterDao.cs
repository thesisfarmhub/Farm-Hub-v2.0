using Model.DTO;
using Model.DTO.Trader;
using Model.EF;

using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.Trader
{
    public class RegisterDao
    {

        FarmHubDbContext db = null;
        public RegisterDao()
        {
            db = new FarmHubDbContext();
        }
        public int InsertTrader(Register entity)
        {
            entity.UserAu.Status_User = 0;
            entity.UserAu.Created_Date = DateTime.Now;
            entity.UserAu.Id_UserKind = 2;

            db.USER_AUTHENTICATION.Add(entity.UserAu);
            db.TRADERs.Add(entity.trader);
            
            db.SaveChanges();

            return entity.UserAu.Id_User;
        }

        public int InsertFarmer(Register entity)
        {
            entity.UserAu.Status_User = 0;
            entity.UserAu.Created_Date = DateTime.Now;
            entity.UserAu.Id_UserKind = 1;
   
            db.USER_AUTHENTICATION.Add(entity.UserAu);
            db.FARMERs.Add(entity.farmer);

            db.SaveChanges();

            return entity.UserAu.Id_User;
        }
    }

}

