using System.Drawing;
using MasterEn.Models;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterEn.Controllers
{
	[Authorize(Roles = "Admin")]
	public class CatalogController : Controller
	{

		private CatalogViewModel _catalogViewModel;
		public CatalogController()
		{

			_catalogViewModel = new CatalogViewModel();
		}
		
		[AllowAnonymous]
		public FileStreamResult GetImage(int id)
		{
			var reg = _catalogViewModel.CatalogItemModels.FirstOrDefault(i => i.CatalogItemId == id);
			if (reg == null) return null;
			if (reg.Image == null) return null;
			var ms = new MemoryStream(reg.Image);
			return new FileStreamResult(ms, "image/jpg");
		}
		public byte[] ImageToByteArray(Image imageIn)
		{
			var ms = new MemoryStream();
			imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
			return ms.ToArray();
		}

		[AllowAnonymous]
		public ActionResult Index()
		{

			return View(_catalogViewModel);
		}
		[AllowAnonymous]
		public ActionResult DetailedInformation(int сatalogItemId)
		{
			return View(_catalogViewModel.CatalogItemModels.FirstOrDefault(item => item.CatalogItemId == сatalogItemId));
		}

		//public ActionResult Create()
		//{
		//	return View();
		//}

		public ActionResult Create()
		{
			var catalogitemmodel = new CatalogItemModel();
			catalogitemmodel.Age = 3;
			catalogitemmodel.Description = "put there item description";
			catalogitemmodel.ShortDescription = "put there item short description";
			catalogitemmodel.Size = "2x23";
			catalogitemmodel.Name = "name";

			return View(catalogitemmodel);
		}

		[HttpPost]
		public ActionResult Create(CatalogItemModel catalogitemmodel, HttpPostedFileBase imageFile)
		{
			if (imageFile != null)
				using (var ms = new MemoryStream())
				{
					imageFile.InputStream.CopyTo(ms);
					catalogitemmodel.Image = ms.ToArray();
				}

			if (ModelState.IsValid)
			{
				_catalogViewModel.CatalogItemModels.Add(catalogitemmodel);
				_catalogViewModel.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("DetailedInformation", catalogitemmodel);
		}

		public ActionResult Edit(int сatalogItemId)
		{
			var catalogitem = _catalogViewModel.CatalogItemModels.FirstOrDefault(item => item.CatalogItemId == сatalogItemId);
			if (catalogitem == null) return View("DetailedInformation");

			return View("Create", catalogitem);
		}

		[HttpPost]
		public ActionResult Edit(int сatalogItemId, HttpPostedFileBase imageFile)
		{
			var catalogitem = _catalogViewModel.CatalogItemModels.FirstOrDefault(item => item.CatalogItemId == сatalogItemId);
			if (catalogitem == null) return View("DetailedInformation");
			
			if (imageFile != null)
				using (var ms = new MemoryStream())
				{
					imageFile.InputStream.CopyTo(ms);
					catalogitem.Image = ms.ToArray();
				}

			if (ModelState.IsValid)
			{
				//_db.CatalogItemModels.Add(catalogitemmodel);
				_catalogViewModel.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("DetailedInformation", catalogitem);
		}

		public ActionResult Delete(int сatalogItemId)
		{
			var catalogitem = _catalogViewModel.CatalogItemModels.FirstOrDefault(item => item.CatalogItemId == сatalogItemId);
			if (ModelState.IsValid)
			{
				_catalogViewModel.CatalogItemModels.Remove(catalogitem);
				_catalogViewModel.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("Index");
		}
		
	}
}