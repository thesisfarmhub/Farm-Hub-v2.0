using FarmHub.Areas.Admin.Models;
using FarmHub.Common;
using Model.Dao.Authentication;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
namespace FarmHub.Controllers
{
    public class EditPasswordController : Controller
    {
        // GET: EditPassword
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditPassword(string oldPassword, string newPassworConfirm , string NewPassword)
        {
            if (ModelState.IsValid)
            {
                if (NewPassword.Equals(newPassworConfirm))
                {

                    Session["UserId"] = 1;
                    int userID = Convert.ToInt32(Session["UserId"]);

                    var dao = new EditPasswordDao();
                    var result = dao.MatchPassword(userID, Encryptor.MD5Hash(oldPassword));

                    if (result == "Succeed")
                    {
                    
                        var encryptorMD5Pass = Encryptor.MD5Hash(NewPassword);
                        NewPassword = encryptorMD5Pass;
                        //UserLoginSession currentUser = (UserLoginSession)Session["Constant.USER_SESSION"];
                        bool update = dao.Update( userID, NewPassword);
                        if (update)
                        {
                            return RedirectToAction("Index", "Register");
                        }
                        else
                        {
                            ModelState.AddModelError("", ErrorList.EDITPASSWORD_ERROR);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", ErrorList.WRONGPASSWORD_ERROR);
                    }
                }
                else
                {
                    ModelState.AddModelError("", ErrorList.PASSWORDCONFIRM_ERROR);
                }
            }

            return View("Index");
        }


        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    var user = new UserDao().ViewDetail(id);
        //    return View(user);
        //}

        //[HttpPost]
        //public ActionResult Edit(USER_AUTHENTICATION user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dao = new UserDao();

        //        if (!string.IsNullOrEmpty(user.Password))
        //        {
        //            var encryptorMD5Pass = Encryptor.MD5Hash(user.Password);
        //            user.Password = encryptorMD5Pass;
        //        }


        //        bool result = dao.Update(user);
        //        if (result)
        //        {
        //            return RedirectToAction("Index", "User");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", ErrorList.REGISTER_ERROR);
        //        }
        //    }
        //    return View("index");
        //}
    }
}