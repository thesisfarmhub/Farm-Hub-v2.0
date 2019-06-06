using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao.Farmer;

using FarmHub.Common;
using Model.DTO;
using Model.DTO.Trader;
using Model.Dao.Trader;

namespace FarmHub.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }


       

        [HttpPost]
        public ActionResult CreateTrader(Register user)
        {
            if (ModelState.IsValid)
            {
                var dao = new RegisterDao();

                var encryptorMD5Pass = Encryptor.MD5Hash(user.UserAu.Password_User);
                user.UserAu.Password_User = encryptorMD5Pass;

                long id = dao.InsertTrader(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", Common.ErrorList.REGISTER_ERROR);
                }
            }
            return View("Create");
         }
        [HttpPost]
        public ActionResult CreateFarmer(Register user)
        {
            if (ModelState.IsValid)
            {
                var dao = new RegisterDao();

                var encryptorMD5Pass = Encryptor.MD5Hash(user.UserAu.Password_User);
                user.UserAu.Password_User = encryptorMD5Pass;

                long id = dao.InsertTrader(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", Common.ErrorList.REGISTER_ERROR);
                }
            }
            return View("Create");
        }




    }
}
