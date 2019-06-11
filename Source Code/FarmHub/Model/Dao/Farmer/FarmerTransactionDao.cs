using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.Farmer
{
    public class FarmerTransactionDao
    {
        private readonly FarmHubDbContext db;

        public FarmerTransactionDao()
        {
            db = new FarmHubDbContext();

        }
        public IEnumerable<TRANSACTION_ORDER> GetListTransaction()
        {
            IQueryable<TRANSACTION_ORDER> model = db.TRANSACTION_ORDER;

            var modelList = model.Where(x => x.Is_Deleted == false
                                        && x.Id_StatusTrans != 16
                                        && x.Id_StatusTrans != 15
                                        && x.Id_StatusTrans != 14
                                        && x.Id_StatusTrans != 12
                                        && x.Id_StatusTrans != 11
                                        && x.Id_StatusTrans != 10
                                        && x.Id_StatusTrans != 9);

            return modelList;
        }

        public void ExecuteHandler(string Command, int transactionId)
        {
            var model = db.TRANSACTION_ORDER.Find(transactionId);
            switch (Command)
            {
                case "Readied":
                    model.Transaction_Date = DateTime.Now;
                    model.Id_StatusTrans = 6;//Sẵn Sàng Giao Hàng
                    db.SaveChanges();
                    break;

                case "Extend":
                    model.Transaction_Date = DateTime.Now;
                    model.Paying_Time += 3;
                    model.Id_StatusTrans = 7;//Gia Hạn Giao Hàng
                    model.SALE_OFFER_DETAIL.Fine = Convert.ToInt32(model.Transaction_Price * 0.1);
                    model.Transaction_TotalMoney -= model.SALE_OFFER_DETAIL.Fine;

                    db.SaveChanges();
                    break;

                case "NotReceived":
                    model.Transaction_Date = DateTime.Now;
                    if (model.Id_StatusTrans == 3)
                    {
                       
                        model.Id_StatusTrans = 15;//model.Transaction_Date = DateTime.Now;
                        model.PURCHASE_OFFER_DETAIL.PURCHASE_OFFER.TRADER.USER_AUTHENTICATION.Penalty -= 1;
                    }
                    else {
                       
                        model.Id_StatusTrans = 4;//Chưa Nhận Được Tiền 
                    }
                   
                    db.SaveChanges();
                    break;

                case "Cancel":
                    model.Transaction_Date = DateTime.Now;
                    if (model.Id_StatusTrans != 5)//Gia Hạn Giao Tiền
                    {
                        model.SALE_OFFER_DETAIL.SALE_OFFER.FARM.FARMER.USER_AUTHENTICATION.Penalty -= 1;
                    }
                    model.Id_StatusTrans = 16;//Bên Bán Hủy 
                    db.SaveChanges();
                    break;
            }
        }
    }
}
