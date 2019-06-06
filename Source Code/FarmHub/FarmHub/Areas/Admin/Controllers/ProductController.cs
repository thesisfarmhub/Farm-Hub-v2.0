using Model.Dao.Admin;
using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmHub.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ProductDao dao = new ProductDao();
        // GET: Admin/Product
        public ActionResult ProductIndex()
        {

            var model = dao.ListProduct();
            return View(model);
        }

        public void SetViewBagProductKind(int? productKindID = null)
        {
           
            ViewBag.Id_ProductKind = new SelectList(dao.GetProductKind(), "Id_ProductKind", "Name_ProductKind", productKindID);
        }

        public ActionResult Create()
        {
            SetViewBagProductKind();
            return View();
        }

        [HttpPost]
        public ActionResult Create(PRODUCT model)
        {

            if (ModelState.IsValid)
            {
                string fileName = null;
                string fileExtension = null;

                fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                fileExtension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + fileExtension;

                model.Image_Product = "/Data/Image/Farmer/Base/" + fileName;
                fileName = Path.Combine(Server.MapPath("/Data/Image/Farmer/Base/"), fileName);

                model.ImageFile.SaveAs(fileName);


                dao.Create(model);
            }
            return RedirectToAction("ProductIndex");
        }

        public ActionResult Details(int id)
        {
            var productModel = dao.Details(id);
            return View(productModel);
        }

        public ActionResult Edit(int id)
        {
            var productKindID = new FarmHubDbContext().PRODUCTs.Find(id).Id_ProductKind;
            SetViewBagProductKind(productKindID);

            var model = dao.Details(id);
            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(PRODUCT model)
        {
            string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            string fileExtension = Path.GetExtension(model.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + fileExtension;

            model.Image_Product = "/Data/Image/Farmer/Base/" + fileName;
            fileName = Path.Combine(Server.MapPath("/Data/Image/Farmer/Base/"), fileName);

            model.ImageFile.SaveAs(fileName);

            if (ModelState.IsValid)
            {
                dao.Edit(model);
            }
            return RedirectToAction("ProductIndex");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            dao.Delete(id);
            return Json(new object[] { new object() }, JsonRequestBehavior.AllowGet);
        }
    }
}