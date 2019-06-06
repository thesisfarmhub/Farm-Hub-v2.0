using Model.Dao.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmHub.Areas.Admin.Controllers
{
    public class FeedBackController : Controller
    {
        FeedBackDao dao = new FeedBackDao();
        // GET: Admin/FeedBack
        public ActionResult FeedBackIndex()
        {
            var model = dao.GetListFeedBack();
            return View(model);
        }

       
    }
}