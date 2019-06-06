using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.Trader
{
    public class PurchaseOfferDetailDao
    {
        FarmHubDbContext db = null;
        public PurchaseOfferDetailDao()
        {
            db = new FarmHubDbContext();

        }

        public IEnumerable<PURCHASE_OFFER_DETAIL> PurchaseDetailListAllPaging(int page, int pageSize)
        {
            IQueryable<PURCHASE_OFFER_DETAIL> model = db.PURCHASE_OFFER_DETAIL;

            return model.OrderByDescending(x => x.Id_PurchaseOfferDetail).ToPagedList(page, pageSize);
        }

        public IEnumerable<TRANSACTION_ORDER> TransactionListByPurchaseOfferID(int purchaseOfferId)
        {
            #region Lambda
            //var query = database.Posts.Join(database.Post_Metas,
            //                    post => post.ID,
            //                    meta => meta.Post_ID,
            //                    (post, meta) => new { Post = post, Meta = meta });
            #endregion

            #region SQL
            //var results = from c in db.Companies
            //              join cn in db.Countries on c.CountryID equals cn.ID
            //              join ct in db.Cities on c.CityID equals ct.ID
            //              join sect in db.Sectors on c.SectorID equals sect.ID
            //              where (c.CountryID == cn.ID) && (c.CityID == ct.ID) && (c.SectorID == company.SectorID) && (company.SectorID == sect.ID)
            //              select new { country = cn.Name, city = ct.Name, c.ID, c.Name, c.Address1, c.Address2, c.Address3, c.CountryID, c.CityID, c.Region, c.PostCode, c.Telephone, c.Website, c.SectorID, Status = (ContactStatus)c.StatusID, sector = sect.Name };


            //return results.ToList();
            #endregion

            var transactions = db.PURCHASE_OFFER.Where(x => x.Id_PurchasesOffer == purchaseOfferId)
                                          .Join(db.PURCHASE_OFFER_DETAIL, po => po.Id_PurchasesOffer, pod => pod.Id_PurchasesOffer, (po, pod) => new { PO = po, POD = pod })
                                          .Join(db.TRANSACTION_ORDER, po_pod => po_pod.POD.Id_PurchaseOfferDetail, to => to.Id_PurchaseOfferDetail, (po_pod, to) => to)
                                          .Where(x => x.Is_Deleted == false && (x.Id_StatusTrans == 10 || x.Id_StatusTrans == 12));
            return transactions.ToList<TRANSACTION_ORDER>();
        }

        // Detail
        public PURCHASE_OFFER Details(int id)
        {
            return db.PURCHASE_OFFER.Find(id);
        }

        public void GetAcceptResult(int transactionId)
        {
            var model=db.TRANSACTION_ORDER.Find(transactionId);


            
            // Recalculate PO remain.
            model.Transaction_Date = DateTime.Now;
            model.PURCHASE_OFFER_DETAIL.PURCHASE_OFFER.Remain_PurchaseQuantity -= model.Transaction_Mass;
            model.Id_StatusTrans = 13;//Status 13: "Đã Đồng ý".

            db.SaveChanges();
            
        }

        public void MakeCounterOffer(int transactionId, int counterOfferQuantity)
        {
            var model = db.TRANSACTION_ORDER.Find(transactionId);

            model.Transaction_Date = DateTime.Now;
            model.Transaction_Mass = counterOfferQuantity;
            model.PURCHASE_OFFER_DETAIL.PURCHASE_OFFER.Remain_PurchaseQuantity -= counterOfferQuantity;
            model.Id_StatusTrans = 11;//Status 11: "Bên Mua Đặt Lại".

            db.SaveChanges();
        }

    }
}
