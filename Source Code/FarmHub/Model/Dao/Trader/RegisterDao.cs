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

        public int InsertUser(Register entity)
        {
            entity.UserAu.Created_Date = DateTime.Now;
            entity.UserAu.Status_User = false;//Chưa Hoạt Động
            entity.UserAu.Is_Deleted = false;

            db.USER_AUTHENTICATION.Add(entity.UserAu);
            db.SaveChanges();

            return db.USER_AUTHENTICATION.Max(x => x.Id_User);
        }

        public int InsertTrader(Register entity,bool gender)
        {

            var userId=InsertUser(entity);

            entity.trader.Id_User = userId;
            entity.trader.Gender_Trader = gender;
            entity.trader.Is_Deleted = false;
            
            db.TRADERs.Add(entity.trader);
            
            db.SaveChanges();

            return db.TRADERs.Max(x => x.Id_Trader);
        }

        public int InsertFarmer(Register entity,bool gender)
        {
            var userId = InsertUser(entity);

            entity.farmer.Id_User = userId;
            entity.farmer.Gender_Farmer = gender;
            entity.farmer.Is_Deleted = false;
            
            db.FARMERs.Add(entity.farmer);

            db.SaveChanges();

            return db.FARMERs.Max(x => x.Id_Farmer);
        }
    }
}

