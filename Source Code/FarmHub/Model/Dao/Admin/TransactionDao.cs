using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.Admin
{
    public class TransactionDao
    {
        FarmHubDbContext db = null;
        public TransactionDao()
        {
            db = new FarmHubDbContext();
        }

        public IEnumerable<TRANSACTION_ORDER> GetOnGoingTrans()
        {
            return db.TRANSACTION_ORDER.Where(x => x.Is_Deleted == false && x.Id_StatusTrans != 14
                                                                         && x.Id_StatusTrans != 15
                                                                         && x.Id_StatusTrans != 16).OrderByDescending(x =>x.Transaction_Date);


        }

        public IEnumerable<TRANSACTION_ORDER> GetEndedTrans()
        {
            return db.TRANSACTION_ORDER.Where(x => x.Is_Deleted == false &&(x.Id_StatusTrans == 14
                                                                         || x.Id_StatusTrans == 15
                                                                         || x.Id_StatusTrans == 16)).OrderByDescending(x => x.Transaction_Date);


        }
    }
}
