using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.Farmer
{
    public class PurchaseOfferDetailDao
    {
        FarmHubDbContext db = null;
        public PurchaseOfferDetailDao()
        {
            db = new FarmHubDbContext();
            
        }

        //public IEnumerable<PURCHASE_OFFER_DETAIL> PurchaseDetailListAllPaging(int page, int pageSize)
        //{
        //    IQueryable<PURCHASE_OFFER_DETAIL> model = db.PURCHASE_OFFER_DETAIL;

        //    return model.OrderByDescending(x => x.Id_PurchaseOfferDetail).ToPagedList(page, pageSize);
        //}

        public IEnumerable<TRANSACTION_ORDER> PurchaseDetailListByPurchaseOfferID(int id)
        {   
            //Status: Accepted
            var model = db.TRANSACTION_ORDER.Where(x => x.PURCHASE_OFFER_DETAIL.PURCHASE_OFFER.Id_PurchasesOffer == id);
            return model;
        }

        

        // Detail
        public PURCHASE_OFFER Details(int id)
        {
            return db.PURCHASE_OFFER.Find(id);
        }


    }
}
