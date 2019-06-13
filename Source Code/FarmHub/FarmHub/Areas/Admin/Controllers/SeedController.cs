using FarmHub.Areas.Admin.Models;
using Model.Dao.Admin;
using Model.EF;
using System.Collections.Generic;
using System.Linq;
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

        public void SetViewBagProduct(int? productID = null)
        {
            ViewBag.Id_Product = new SelectList(new FarmHubDbContext().PRODUCTs.Where(x => x.Is_Deleted == false), "Id_Product", "Name_Product", productID);
        }

        // Auto Complete
        public JsonResult GetSearchValue(string search)
        {
            FarmHubDbContext db = new FarmHubDbContext();
            List<SeedAutoCompleteModel> allSearch = db.SEEDs.Where(x => x.Name_Seed.Contains(search)).Select(x => new SeedAutoCompleteModel
            {
                Id_Seed = x.Id_Seed,
                Name_Seed = x.Name_Seed,
                Code_Seed = x.Code_Seed
            }).ToList();
            return new JsonResult { Data = allSearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // Auto Complete
        public JsonResult GetSearchValueCodeSeed(string search)
        {
            FarmHubDbContext db = new FarmHubDbContext();
            List<SeedAutoCompleteModel> allSearch = db.SEEDs.Where(x => x.Code_Seed.Contains(search)).Select(x => new SeedAutoCompleteModel
            {
                Id_Seed = x.Id_Seed,
                Name_Seed = x.Name_Seed,
                Code_Seed = x.Code_Seed
            }).ToList();
            return new JsonResult { Data = allSearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Create()
        {
            SetViewBagProduct();
            return View();
        }

        [HttpPost]
        public ActionResult Create(SEED model)
        {
            var result = dao.Create(model);

            if (result)
            {
                return RedirectToAction("SeedIndex");
            }
            else
            {
                ModelState.AddModelError("", "Tạo mới thất bại !!!");
                SetViewBagProduct();
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            var product = new FarmHubDbContext().PRODUCTs.Find(id).Id_Product;
            SetViewBagProduct(product);

            var model = dao.Details(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(SEED model)
        {
            var result = dao.Edit(model);

            if (result)
            {
                return RedirectToAction("SeedIndex");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật thất bại !!!");
                SetViewBagProduct();
                return View(model);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            dao.Delete(id);
            return Json(new object[] { new object() }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            var seedModel = dao.Details(id);
            return View(seedModel);
        }

    }
}