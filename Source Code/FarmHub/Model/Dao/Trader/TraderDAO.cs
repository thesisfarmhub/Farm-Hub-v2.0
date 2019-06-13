using Model.EF;
using System;
using System.Linq;

namespace Model.Dao.Trader
{
    public class TraderDAO
    {
        readonly FarmHubDbContext db = null;

        public TraderDAO()
        {
            db = new FarmHubDbContext();

        }

        public TRADER GetTraderByUserID(int userID)
        {
            return new FarmHubDbContext().TRADERs.FirstOrDefault(x => x.Id_User == userID);
        }

        public bool Update(TRADER trader)
        {
            var targetUpdate = db.TRADERs.Find(trader.Id_Trader);

            try
            {

                targetUpdate.Id_Trader = trader.Id_Trader;
                targetUpdate.Id_User = trader.Id_User;
                targetUpdate.Name_Trader = trader.Name_Trader;
                targetUpdate.Birthday_Trader = trader.Birthday_Trader;
                targetUpdate.Gender_Trader = trader.Gender_Trader;
                targetUpdate.Address_Trader = trader.Address_Trader;
                targetUpdate.Telephone_Trader = trader.Telephone_Trader;
                targetUpdate.Email_Trader = trader.Email_Trader;

                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
        }

        public TRADER Details(int traderID)
        {
            return db.TRADERs.Find(traderID);
        }
    }
}
