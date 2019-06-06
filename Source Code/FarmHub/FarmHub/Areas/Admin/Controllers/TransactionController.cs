using Model.Dao.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmHub.Areas.Admin.Controllers
{
    public class TransactionController : Controller
    {
        TransactionDao dao = new TransactionDao();
        // GET: Admin/Transaction
        public ActionResult OnGoingTransaction()
        {
            var model =dao.GetOnGoingTrans();
            return View(model);
        }

        public ActionResult EndedTransaction()
        {
            var model = dao.GetEndedTrans();
            return View(model);
        }
    }
}