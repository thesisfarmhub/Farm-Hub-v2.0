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
        public ActionResult CreateRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTrader(Register user, bool gender)
        {
            if (ModelState.IsValid)
            {
                var dao = new RegisterDao();

                var encryptorMD5Pass = Encryptor.MD5Hash(user.UserAu.Password_User);
                user.UserAu.Password_User = encryptorMD5Pass;
                user.UserAu.Id_UserKind = 2;
                user.UserAu.Penalty = 3;
                long id = dao.InsertTrader(user, gender);
                if (id > 0)
                {
                    Session["FarmerId"] = id;
                    return RedirectToAction("Index", "Trader");
                }

                else
                {
                    ModelState.AddModelError("", Common.ErrorList.REGISTER_ERROR);
                }

            }
            else
            {
                ModelState.AddModelError("", Common.ErrorList.Wrong_Validation);
            }
            return View("CreateRegister");
        }
        [HttpPost]
        public ActionResult CreateFarmer(Register user, bool gender)
        {
            if (ModelState.IsValid)
            {
                var dao = new RegisterDao();

                var encryptorMD5Pass = Encryptor.MD5Hash(user.UserAu.Password_User);
                user.UserAu.Password_User = encryptorMD5Pass;
                user.UserAu.Id_UserKind = 1;
                user.UserAu.Penalty = 5;
                
                long id = dao.InsertFarmer(user, gender);
                if (id > 0)
                {
                    Session["TraderId"] = id;
                    return RedirectToAction("Index", "Farmer", new { area = "Farmer" });
                }
                else
                {
                    ModelState.AddModelError("", Common.ErrorList.REGISTER_ERROR);
                }
            }
            else
            {
                ModelState.AddModelError("", Common.ErrorList.Wrong_Validation);
            }
            return View("CreateRegister");
        }




    }
}
