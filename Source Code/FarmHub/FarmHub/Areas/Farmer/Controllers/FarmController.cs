using Model.Dao.Farmer;
using Model.EF;
using System;
using System.Web.Mvc;

namespace FarmHub.Areas.Farmer.Controllers
{
    public class FarmController : Controller
    {
        // GET: Farmer/Farm
        public ActionResult Index()
        {
            // Session
            var session = Convert.ToInt32(Session["FarmerID"]);
            var listFarm = dao.ListFarmByFarmerID(session);
            return View(listFarm);
        }

        // GET: Farmer/Farm/Details/5
        public ActionResult Details(int id)
        {
            var farmModel = dao.Details(id);
            return View(farmModel);
        }

        // GET: Farmer/Farm/Create
        public ActionResult Create()
        {
            SetViewBagFarmer();
            return View();
        }

        // POST: Farmer/Farm/Create
        [HttpPost]
        public ActionResult Create(FARM farmModel)
        {
            if (ModelState.IsValid)
            {
                var result = dao.Create(farmModel);

                if (result > 0)
                {
                    // Session
                    var session = Convert.ToInt32(Session["FarmerID"]);
                    return RedirectToAction("Index", new { id = session });
                }
                else
                {
                    ModelState.AddModelError("", "Tạo mới thất bại !!!");
                }
            }

            ModelState.AddModelError("", "Tạo mới thất bại !!!");
            SetViewBagFarmer();
            return View();
        }

        // GET: Farmer/Farm/Edit/5
        public ActionResult Edit(int id)
        {
            var farmModel = dao.Details(id);
            return View(farmModel);
        }

        // POST: Farmer/Farm/Edit/5
        [HttpPost]
        public ActionResult Edit(FARM farmModel)
        {
            if (ModelState.IsValid)
            {
                var result = dao.Update(farmModel);

                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thất bại !!!");
                }
            }

            ModelState.AddModelError("", "Cập nhật thất bại !!!");
            var farmModelState = dao.Details(farmModel.Id_Farm);
            return View(farmModelState);
        }

        // GET: Farmer/Farm/Delete/5
        public ActionResult Delete(int id)
        {
            var farmModel = dao.Details(id);
            return View(farmModel);
        }

        // POST: Farmer/Farm/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                var result = dao.Delete(id);

                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Xóa thất bại !!!");
                }
            }

            var farmModel = dao.Details(id);
            return View(farmModel);
        }

        #region Function

        readonly FarmDAO dao = new FarmDAO();

        // SetViewBagFarmer
        public void SetViewBagFarmer()
        {
            // Session
            var session = Convert.ToInt32(Session["FarmerID"]);
            FarmerDAO farmerDAO = new FarmerDAO();
            ViewBag.Name_Farmer = farmerDAO.GetFarmerNameByFarmerID(session);
            ViewBag.Id_Farmer = session;
        }

        #endregion
    }
}
