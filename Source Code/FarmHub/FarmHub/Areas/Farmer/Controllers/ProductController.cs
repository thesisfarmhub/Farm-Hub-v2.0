using Model.Dao.Farmer;
using Model.EF;
using System.Web.Mvc;

namespace FarmHub.Areas.Farmer.Controllers
{
    public class ProductController : Controller
    {
        // GET: Farmer/Product
        public ActionResult Index()
        {
            var listProduct = dao.ListAllActive();
            return View(listProduct);
        }

        // GET: Farmer/Product/Details/5
        public ActionResult Details(int id)
        {
            var productModel = dao.Details(id);
            return View(productModel);
        }

        // GET: Farmer/Product/Create
        public ActionResult Create()
        {
            SetViewBagProductKind();
            return View();
        }

        // POST: Farmer/Product/Create
        [HttpPost]
        public ActionResult Create(PRODUCT productModel)
        {

            if (ModelState.IsValid)
            {
                var result = dao.Create(productModel);

                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Tạo mới thất bại !!!");
                }
            }

            SetViewBagProductKind();
            return View();
        }

        // GET: Farmer/Product/Edit/5
        public ActionResult Edit(int id)
        {
            SetViewBagProductKind();
            var productModel = dao.Details(id);
            return View(productModel);
        }

        // POST: Farmer/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PRODUCT productModel)
        {
            if (ModelState.IsValid)
            {
                var result = dao.Update(productModel);

                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thất bại !!!");
                }
            }

            SetViewBagProductKind();
            var productModelState = dao.Details(productModel.Id_Product);
            return View(productModelState);
        }

        // GET: Farmer/Product/Delete/5
        public ActionResult Delete(int id)
        {
            var productModel = dao.Details(id);
            return View(productModel);
        }

        // POST: Farmer/Product/Delete/5
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

            var productModel = dao.Details(id);
            return View(productModel);
        }

        #region Function

        readonly ProductDAO dao = new ProductDAO();

        // SetViewBagProductKind
        public void SetViewBagProductKind()
        {
            ProductKindDAO pkDAO = new ProductKindDAO();
            ViewBag.Id_ProductKind = new SelectList(pkDAO.ListAllActive(), "Id_ProductKind", "Name_ProductKind");
        }

        #endregion

    }
}
