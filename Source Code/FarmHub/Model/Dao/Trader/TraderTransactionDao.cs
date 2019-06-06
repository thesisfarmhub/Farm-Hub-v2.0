using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.Trader
{
    public class TraderTransactionDao
    {
        FarmHubDbContext db = null;
        public TraderTransactionDao()
        {
            db = new FarmHubDbContext();
        }

        public IEnumerable<TRANSACTION_ORDER> GetListTransaction()
        {
            IQueryable<TRANSACTION_ORDER> model = db.TRANSACTION_ORDER;
            //Status: Đã Hoàn Tất 
            var transList = model.Where(x => x.Is_Deleted == false && (x.Id_StatusTrans != 16
                                                                        && x.Id_StatusTrans != 15
                                                                        && x.Id_StatusTrans != 14
                                                                        && x.Id_StatusTrans != 11
                                                                        && x.Id_StatusTrans != 12
                                                                        && x.Id_StatusTrans != 10
                                                                        && x.Id_StatusTrans != 9
                                                                        && x.Id_StatusTrans != 2));
            return transList.OrderByDescending(x => x.Transaction_Date);
        }

        public void ExecuteHandler(string Command, int transactionId)
        {
            var model = db.TRANSACTION_ORDER.Find(transactionId);
            switch (Command)
            {
                case "Transfered":
                    model.Transaction_Date = DateTime.Now;
                    model.Id_StatusTrans = 1;//Đã Chuyển Tiền
                    db.SaveChanges();
                    break;

                case "Extend":
                    model.Transaction_Date = DateTime.Now;
                    model.Paying_Time += 3;
                    model.Id_StatusTrans = 5;//Gia Hạn Giao Tiền
                    db.SaveChanges();
                    break;

                case "Delivered":
                    model.Transaction_Date = DateTime.Now;
                    model.Id_StatusTrans = 9;//Đã Nhận Được Hàng 
                    db.SaveChanges();
                    break;

                case "NotDelivered":
                    model.Transaction_Date = DateTime.Now;
                    model.Id_StatusTrans = 8;//Chưa Nhận Được Hàng 
                    db.SaveChanges();
                    break;

                case "Cancel":
                    model.Transaction_Date = DateTime.Now;
                    if (model.Id_StatusTrans != 7)//Gia Hạn Giao Hàng
                    {
                        model.PURCHASE_OFFER_DETAIL.PURCHASE_OFFER.TRADER.USER_AUTHENTICATION.Penalty -= 1;
                    }
                    model.Id_StatusTrans = 15;//Bên Mua Hủy                     
                    db.SaveChanges();
                    break;
            }
        }

        public bool ConfirmReady(TRANSACTION_ORDER entity)
        {
            try
            {
                var TransOrder = db.TRANSACTION_ORDER.Find(entity.Id_TransactionOrder);
                TransOrder.Transaction_Date = DateTime.Today;
                TransOrder.Id_StatusTrans = 5;//"Sẵn Sàng Giao Hàng"

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void CancelDelivered(TRANSACTION_ORDER entity)
        { 
                var TransOrder = db.TRANSACTION_ORDER.Find(entity.Id_TransactionOrder);
                TransOrder.Transaction_Date = DateTime.Today;
                TransOrder.Id_StatusTrans = 14;//"Bên mua Hủy "
                TransOrder.SALE_OFFER_DETAIL.SALE_OFFER.FARM.FARMER.USER_AUTHENTICATION.Penalty -= 1;

            db.SaveChanges();

            if (TransOrder.SALE_OFFER_DETAIL.SALE_OFFER.FARM.FARMER.USER_AUTHENTICATION.Penalty == 0)
            {
                TransOrder.SALE_OFFER_DETAIL.SALE_OFFER.FARM.FARMER.USER_AUTHENTICATION.Is_Deleted = true;
            }
        }
    }
  
    
}
