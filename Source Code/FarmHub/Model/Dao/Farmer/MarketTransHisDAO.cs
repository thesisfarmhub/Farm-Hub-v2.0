using Model.EF;
using System.Collections.Generic;
using System.Linq;

namespace Model.Dao.Farmer
{
    public class MarketTransHisDAO
    {
        readonly FarmHubDbContext db = null;

        public MarketTransHisDAO()
        {
            db = new FarmHubDbContext();
        }

        // ListAll
        public List<MARKET_TRANS_HIS> ListAll()
        {
            return db.MARKET_TRANS_HIS.Where(x => x.Id_MarketTransHis > 0).OrderByDescending(x => x.Id_MarketTransHis).ToList();
        }

        // Detail
        public MARKET_TRANS_HIS Details(int id_MTH)
        {
            return db.MARKET_TRANS_HIS.Find(id_MTH);
        }
    }
}
