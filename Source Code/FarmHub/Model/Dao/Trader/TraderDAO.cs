using Model.EF;
using System.Linq;

namespace Model.Dao.Trader
{
    public class TraderDAO
    {
        public TRADER GetTraderByUserID(int userID)
        {
            return new FarmHubDbContext().TRADERs.FirstOrDefault(x => x.Id_User == userID);
        }
    }
}
