using FarmHub.Areas.Admin.Models;
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

        // Auto Complete
        public JsonResult GetSearchValue(string search)
        {
            FarmHubDbContext db = new FarmHubDbContext();
            List<ProductAutoCompleteModel> allSearch = db.PRODUCTs.Where(x => x.Name_Product.Contains(search)).Select(x => new ProductAutoCompleteModel
            {
                Id_Product = x.Id_Product,
                Name_Product = x.Name_Product
            }).ToList();
            return new JsonResult { Data = allSearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Create()
        {
            SetViewBagProductKind();
            return View();
        }

        [HttpPost]
        public ActionResult Create(PRODUCT model)
        {
            string fileName = null;
            string fileExtension = null;

            try
            {
                fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                fileExtension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + fileExtension;

                model.Image_Product = "/Data/Image/Farmer/Base/" + fileName;
                fileName = Path.Combine(Server.MapPath("/Data/Image/Farmer/Base/"), fileName);
                model.ImageFile.SaveAs(fileName);

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Hình ảnh không được để trống");
                SetViewBagProductKind();
                return View(model);
            }

            var result = dao.Create(model);

            if (result)
            {
                return RedirectToAction("ProductIndex");
            }
            else
            {
                ModelState.AddModelError("", "Tạo mới thất bại !!!");
                SetViewBagProductKind();
                return View(model);
            }
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
            string fileName = null;
            string fileExtension = null;

            try
            {
                fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                fileExtension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + fileExtension;
                model.Image_Product = "/Data/Image/Farmer/Base/" + fileName;
                fileName = Path.Combine(Server.MapPath("/Data/Image/Farmer/Base/"), fileName);
                model.ImageFile.SaveAs(fileName);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Hình ảnh không được để trống");

                // Set and select value from ViewBag
                var productKindID = new FarmHubDbContext().PRODUCTs.Find(model.Id_Product).Id_ProductKind;
                SetViewBagProductKind(productKindID);

                var productModelState = dao.Details(model.Id_Product);
                return View(productModelState);
            }

            var result = dao.Update(model);

            if (result)
            {
                return RedirectToAction("ProductIndex");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật thất bại");

                // Set and select value from ViewBag
                var productKindID = new FarmHubDbContext().PRODUCTs.Find(model.Id_Product).Id_ProductKind;
                SetViewBagProductKind(productKindID);

                var productModelState = dao.Details(model.Id_Product);
                return View(productModelState);
            }
        }

        public ActionResult Details(int id)
        {
            var productModel = dao.Details(id);
            return View(productModel);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            dao.Delete(id);
            return Json(new object[] { new object() }, JsonRequestBehavior.AllowGet);
        }
    }
}