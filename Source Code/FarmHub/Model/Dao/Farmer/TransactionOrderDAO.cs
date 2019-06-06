using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Dao.Farmer
{
    public class TransactionOrderDAO
    {
        readonly FarmHubDbContext db = null;

        public TransactionOrderDAO()
        {
            db = new FarmHubDbContext();
        }

        // ListAll
        public List<TRANSACTION_ORDER> ListAll()
        {
            return db.TRANSACTION_ORDER.Where(x => x.Id_TransactionOrder > 0).OrderByDescending(x => x.Id_TransactionOrder).ToList();
        }

        // ListAllActive
        public List<TRANSACTION_ORDER> ListAllActive()
        {
            return db.TRANSACTION_ORDER.Where(x => x.Is_Deleted == false).OrderByDescending(x => x.Id_TransactionOrder).ToList();
        }

        // List Transaction Order By FarmerID
        public List<TRANSACTION_ORDER> ListTransOrderByFarmerID(int farmerID)
        {
            return db.TRANSACTION_ORDER.Where(x => x.Is_Deleted == false && x.PRODUCT_DETAIL.FARM.Id_Farmer == farmerID).OrderByDescending(x => x.Id_TransactionOrder).ToList();
        }

        // Detail
        public TRANSACTION_ORDER Details(int transOrderID)
        {
            return db.TRANSACTION_ORDER.Find(transOrderID);
        }


    }
}
