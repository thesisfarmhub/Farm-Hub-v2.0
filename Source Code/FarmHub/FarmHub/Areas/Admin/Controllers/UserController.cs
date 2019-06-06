using Model.Dao.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmHub.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        UserDao dao = new UserDao();
        // GET: Admin/User
        public ActionResult UserIndex()
        {
            var model = dao.ListAllUser();
            return View(model);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            dao.Delete(id);
            return RedirectToAction("UserIndex");
        }
    }
}