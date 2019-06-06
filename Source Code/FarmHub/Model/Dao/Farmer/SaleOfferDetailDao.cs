using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.Farmer
{
    public class SaleOfferDetailDao
    {
        FarmHubDbContext db = null;
        public SaleOfferDetailDao()
        {
            db = new FarmHubDbContext();

        }
        public IEnumerable<TRANSACTION_ORDER> TransactionListByPurchaseOfferID(int saleOfferId)
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

            var transactions = db.SALE_OFFER.Where(x => x.Id_SaleOffer == saleOfferId)
                                          .Join(db.SALE_OFFER_DETAIL, so => so.Id_SaleOffer, sod => sod.Id_SaleOffer, (so, sod) => new { SO = so, SOD = sod })
                                          .Join(db.TRANSACTION_ORDER, so_sod => so_sod.SOD.Id_SaleOfferDetail, to => to.Id_SaleOfferDetail, (so_sod, to) => to)
                                          .Where(x => x.Is_Deleted == false && (x.Id_StatusTrans == 10 || x.Id_StatusTrans == 11));
            return transactions.ToList<TRANSACTION_ORDER>();

        }

        // Detail
        public SALE_OFFER Details(int saleOfferId)
        {
            return db.SALE_OFFER.Find(saleOfferId);
        }

        public void GetAcceptResult(int transactionId)
        {
            var model = db.TRANSACTION_ORDER.Find(transactionId);

            // Recalculate PO remain.
            model.Transaction_Date = DateTime.Now;
            model.SALE_OFFER_DETAIL.SALE_OFFER.Remain_SaleQuantity -= model.Transaction_Mass;
            model.Id_StatusTrans = 13;//Status 13: "Đã Đồng ý".

            db.SaveChanges();

        }

        public void MakeCounterOffer(int transactionId, int counterOfferQuantity)
        {
            var model = db.TRANSACTION_ORDER.Find(transactionId);

            model.Transaction_Date = DateTime.Now;
            model.Transaction_Mass = counterOfferQuantity;
            model.SALE_OFFER_DETAIL.SALE_OFFER.Remain_SaleQuantity -= counterOfferQuantity;
            model.Id_StatusTrans = 12;//Status 12: "Bên Bán Đặt Lại".

            db.SaveChanges();
        }
    }
}
