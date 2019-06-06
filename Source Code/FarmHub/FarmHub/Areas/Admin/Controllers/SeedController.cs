using Model.Dao.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmHub.Areas.Admin.Controllers
{
    public class SeedController : Controller
    {
        SeedDao dao = new SeedDao();
        // GET: Admin/Seed
        public ActionResult SeedIndex()
        {
            var model = dao.ListSeed();
            return View(model);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            dao.Delete(id);
            return Json(new object[] { new object() }, JsonRequestBehavior.AllowGet);
        }
    }
}