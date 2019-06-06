using Model.Dao.Farmer;
using Model.EF;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace FarmHub.Areas.Farmer.Controllers
{
    public class ProductDetailsController : Controller
    {
        // GET: Farmer/ProductDetails
        public ActionResult Index(int id)
        {
            Session["FarmID"] = id;
            var listPD = dao.ListAllByFarmID(id);
            return View(listPD);
        }

        // GET: Farmer/ProductDetails/Details/5
        public ActionResult Details(int id)
        {
            var productModel = dao.Details(id);
            return View(productModel);
        }

        // GET: Farmer/ProductDetails/Create
        public ActionResult Create()
        {
            FarmIDForViewBag();
            SetViewBagProduct();
            SetViewBagSeed();
            return View();
        }

        // POST: Farmer/ProductDetails/Create
        [HttpPost]
        public ActionResult Create(PRODUCT_DETAIL pdModel)
        {
            string fileName = null;
            string fileExtension = null;

            try
            {
                fileName = Path.GetFileNameWithoutExtension(pdModel.ImageFile.FileName);
                fileExtension = Path.GetExtension(pdModel.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + fileExtension;

                pdModel.Image_ProductDetail = "/Data/Image/Farmer/Customer/" + fileName;
                fileName = Path.Combine(Server.MapPath("/Data/Image/Farmer/Customer/"), fileName);
                pdModel.ImageFile.SaveAs(fileName);

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Hình ảnh không được để trống");
                FarmIDForViewBag();
                SetViewBagProduct();
                SetViewBagSeed();
                return View(pdModel);
            }

            pdModel.Id_Farm = Convert.ToInt32(Session["FarmID"]);
            var result = dao.Create(pdModel);

            if (result > 0)
            {
                // Session
                var session = Convert.ToInt32(Session["FarmerID"]);
                var db = new FarmHubDbContext();
                var farmerID = db.FARMERs.Find(session).Id_Farmer;
                var farmID = db.FARMs.FirstOrDefault(x => x.Id_Farmer == farmerID).Id_Farm;
                return RedirectToAction("Index", new { id = farmID });

            }
            else
            {
                ModelState.AddModelError("", "Tạo mới thất bại !!!");
                FarmIDForViewBag();
                SetViewBagProduct();
                SetViewBagSeed();
                return View(pdModel);
            }
        }

        // GET: Farmer/ProductDetails/Edit/5
        public ActionResult Edit(int id)
        {
            // Set and select value from ViewBag
            var farmID = new FarmHubDbContext().PRODUCT_DETAIL.Find(id).Id_Farm;
            SetViewBagFarm(farmID);
            var producID = new FarmHubDbContext().PRODUCT_DETAIL.Find(id).Id_Product;
            SetViewBagProduct(producID);
            var seedID = new FarmHubDbContext().PRODUCT_DETAIL.Find(id).Id_Seed;
            SetViewBagSeed(seedID);

            var pdModel = dao.Details(id);
            return View(pdModel);
        }

        // POST: Farmer/ProductDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(PRODUCT_DETAIL productDetailsModel)
        {
            string fileName = null;
            string fileExtension = null;

            try
            {
                fileName = Path.GetFileNameWithoutExtension(productDetailsModel.ImageFile.FileName);
                fileExtension = Path.GetExtension(productDetailsModel.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + fileExtension;
                productDetailsModel.Image_ProductDetail = "/Data/Image/Farmer/Customer/" + fileName;
                fileName = Path.Combine(Server.MapPath("/Data/Image/Farmer/Customer/"), fileName);
                productDetailsModel.ImageFile.SaveAs(fileName);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Hình ảnh không được để trống");

                // Set and select value from ViewBag
                var farmmID = new FarmHubDbContext().PRODUCT_DETAIL.Find(productDetailsModel.Id_ProductDetail).Id_Farm;
                SetViewBagFarm(farmmID);
                var producID = new FarmHubDbContext().PRODUCT_DETAIL.Find(productDetailsModel.Id_ProductDetail).Id_Product;
                SetViewBagProduct(producID);
                var seedID = new FarmHubDbContext().PRODUCT_DETAIL.Find(productDetailsModel.Id_ProductDetail).Id_Seed;
                SetViewBagSeed(seedID);

                var productDetailsModelState = dao.Details(productDetailsModel.Id_ProductDetail);
                return View(productDetailsModelState);
            }

            var result = dao.Update(productDetailsModel);

            if (result)
            {
                // Session
                var session = Convert.ToInt32(Session["FarmerID"]);
                var db = new FarmHubDbContext();
                var farmerID = db.FARMERs.Find(session).Id_Farmer;
                var farmID = db.FARMs.FirstOrDefault(x => x.Id_Farmer == farmerID).Id_Farm;
                return RedirectToAction("Index", new { id = farmID });
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật thất bại");

                // Set and select value from ViewBag
                var farmmID = new FarmHubDbContext().PRODUCT_DETAIL.Find(productDetailsModel.Id_ProductDetail).Id_Farm;
                SetViewBagFarm(farmmID);
                var producID = new FarmHubDbContext().PRODUCT_DETAIL.Find(productDetailsModel.Id_ProductDetail).Id_Product;
                SetViewBagProduct(producID);
                var seedID = new FarmHubDbContext().PRODUCT_DETAIL.Find(productDetailsModel.Id_ProductDetail).Id_Seed;
                SetViewBagSeed(seedID);

                var productDetailsModelState = dao.Details(productDetailsModel.Id_ProductDetail);
                return View(productDetailsModelState);
            }
        }

        // GET: Farmer/ProductDetails/Delete/5
        public ActionResult Delete(int id)
        {
            var productDetailsModel = dao.Details(id);
            return View(productDetailsModel);
        }

        // POST: Farmer/ProductDetails/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                var result = dao.Delete(id);

                if (result)
                {
                    // Session
                    var session = Convert.ToInt32(Session["FarmerID"]);
                    var db = new FarmHubDbContext();
                    var farmerID = db.FARMERs.Find(session).Id_Farmer;
                    var farmID = db.FARMs.FirstOrDefault(x => x.Id_Farmer == farmerID).Id_Farm;
                    return RedirectToAction("Index", new { id = farmID });
                }
                else
                {
                    ModelState.AddModelError("", "Xóa thất bại !!!");
                }
            }

            var pdModel = dao.Details(id);
            return View(pdModel);
        }

        #region Function

        readonly ProductDetailDAO dao = new ProductDetailDAO();

        // SetViewBagProduct
        public void SetViewBagProduct(int? productID = null)
        {
            ProductDAO dao = new ProductDAO();
            ViewBag.Id_Product = new SelectList(dao.ListAllActive(), "Id_Product", "Name_Product", productID);
        }

        // SetViewBagFarm
        public void SetViewBagFarm(int? farmID = null)
        {
            // Session
            var session = Convert.ToInt32(Session["FarmerID"]);
            var farmerID = new FarmHubDbContext().FARMERs.Find(session).Id_Farmer;
            FarmDAO dao = new FarmDAO();
            ViewBag.Id_Farm = new SelectList(dao.ListFarmByFarmerID(farmerID), "Id_Farm", "Name_Farm", farmID);
        }

        // SetViewBagSeed
        public void SetViewBagSeed(int? seedID = null)
        {
            SeedDAO dao = new SeedDAO();
            ViewBag.Id_Seed = new SelectList(dao.ListAllActive(), "Id_Seed", "Name_Seed", seedID);
        }

        // SetViewBag FarmID dùng cho create tự dộng gán giá trị Id_Farm vào Product Details
        public void FarmIDForViewBag()
        {
            // Session
            var session = Convert.ToInt32(Session["FarmerID"]);
            var farmIDSaved = Convert.ToInt32(Session["FarmID"]); // giá trị farmID lấy từ Index

            var farmerID = new FarmHubDbContext().FARMERs.Find(session).Id_Farmer;
            FarmDAO dao = new FarmDAO();
            ViewBag.FarmIDForPD = new SelectList(dao.ListFarmByFarmerID(farmerID), "Id_Farm", "Name_Farm", farmIDSaved);
        }
        #endregion
    }
}
