using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao.Authentication
{
    public class TransactionScheduleDao
    {
        FarmHubDbContext db = null;
        public TransactionScheduleDao()
        {
            db = new FarmHubDbContext();
        }

        public void ChangeScheduledTransactions()
        {
            IEnumerable<TRANSACTION_ORDER> transModel = db.TRANSACTION_ORDER.Where(x => x.Id_StatusTrans != 9//Đã Nhận Được Hàng 
                                                                                    && x.Id_StatusTrans != 10//Mới Thiết Lập
                                                                                    && x.Id_StatusTrans != 11//Bên Mua Đặt Lại
                                                                                    && x.Id_StatusTrans != 12//Bên Bán Đặt Lại
                                                                                    && x.Id_StatusTrans != 14//Đã Từ Chối
                                                                                    && x.Id_StatusTrans != 15//Bên Mua Hủy 
                                                                                    && x.Id_StatusTrans != 16//Bên Bán Hủy  
                                                                                );

            DateTime expectedPayDate;
            foreach (var item in transModel)
            {
               
                expectedPayDate = item.Transaction_Date.Value.AddDays(Convert.ToInt32(item.Paying_Time));

                if (expectedPayDate.Date < DateTime.Now.Date)
                {
                    byte? newStatusID = ChangeStatus(item.Id_StatusTrans);

                    item.Transaction_Date = DateTime.Now;
                    item.Id_StatusTrans = newStatusID;

                    if (item.Id_StatusTrans == 15)
                    {
                        item.PURCHASE_OFFER_DETAIL.PURCHASE_OFFER.TRADER.USER_AUTHENTICATION.Penalty -= 1;
                    }

                    if (item.Id_StatusTrans == 16)
                    {
                        item.SALE_OFFER_DETAIL.SALE_OFFER.FARM.FARMER.USER_AUTHENTICATION.Penalty -= 1;
                    }

                    db.SaveChanges();
                }            
            }

            db.SaveChanges();
        }

        public byte? ChangeStatus(byte? idStatus)
        {
            switch (idStatus)
            {
                case 1:         //Đã Chuyển Tiền
                case 2:         //Đã Chuyển Tiền Lại
                    return 3;       //Đã Nhận Tiền

                case 6:         //Sẵn Sàng Giao Hàng
                    return 9;       //Đã Nhận Được Hàng

                case 13:        //Đã Đồng Ý
                case 4:         //Chưa Nhận Được Tiền 
                case 5:         //Gia Hạn Giao Tiền
                    return 15;      //Bên Mua Hủy 

                case 8:         //Chưa Nhận Được Hàng 
                case 7:         //Gia Hạn Giao Hàng
                    return 16;      //Bên Bán Hủy 
            }
            return 0;
        }

        public void ChangeScheduledUserStatus()
        {
            try
            {
                IEnumerable<USER_AUTHENTICATION> userModel = db.USER_AUTHENTICATION.Where(x => x.Status_User == 1);//Active

                foreach (var item in userModel)
                {
                    if (item.Penalty == 0)
                    {
                        item.Status_User = 0;
                    }
                }
                db.SaveChanges();
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
        }

    }
}
