using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.Authentication
{
    public class FeedBackDao
    {
        FarmHubDbContext db = null;
        public FeedBackDao()
        {
            db = new FarmHubDbContext();
        }

        public IEnumerable<TOPIC> GetListTopic()
        {
            return db.TOPICs.Where(x => x.Id_Topic != 4);
        }

        public IEnumerable<FEED_BACK> GetListFeedBack()
        {
            return db.FEED_BACK.Where(x => x.Is_Deleted == false);
        }
    }
}
