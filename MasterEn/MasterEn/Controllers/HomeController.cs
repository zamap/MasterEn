using System;
using MasterEn.Models;
using System.Web.Mvc;

namespace MasterEn.Controllers
{
	public class HomeController : Controller
	{

		public class Info
		{
			public string Name { get; set; }
		}

		public class HomeController : Controller
		{
			public static List<string> Items = new List<string>()
                                               {
                                                   "TEST"
                                               };

			public ActionResult Index()
			{
				return View(Items);
			}

			public ActionResult SubIndex()
			{
				return PartialView(Items);
			}

			[HttpPost]
			public ActionResult AddItem(Info item)
			{
				Items.Add(item.Name);

				return Json("ok", JsonRequestBehavior.AllowGet);
			}
		}

		//public ActionResult Index()
		//{
		//	return View();
		//}

		//public ActionResult Shop()
		//{
		//	ViewBag.Message = "Интернет магазин";

		//	return View();
		//}
		//public ActionResult LearningMaterials()
		//{
		//	ViewBag.Message = "Учебные материалы";

		//	return View();
		//}
		//public ActionResult LearningLevels()
		//{
		//	ViewBag.Message = "Уровни обучения";

		//	return View();
		//}
		//public ActionResult Teacher()
		//{
		//	ViewBag.Message = "Преподаватель";

		//	return View();
		//}
		//public ActionResult HowToStart()
		//{
		//	ViewBag.Message = "Как начать";

		//	return View();
		//}
		//public ActionResult PriceList()
		//{
		//	ViewBag.Message = "Стоимость";

		//	return View();
		//}

		//public ActionResult WaysToPay()
		//{
		//	ViewBag.Message = "Способы оплаты";

		//	return View();
		//}
		//public ActionResult UsefullLinks()
		//{
		//	ViewBag.Message = "Полезные ссылки";

		//	return View();
		//}

		//public ActionResult Contract()
		//{
		//	ViewBag.Message = "Your contact page.";

		//	return View();
		//}
		//public ActionResult Contact()
		//{
		//	ViewBag.Message = "Контакты";

		//	return View();
		//}

		//[HttpGet]
		//public ActionResult Create()
		//{
		//	return PartialView("_Create");
		//}

		//[HttpPost]
		//public ActionResult SendBuyRequest(MyViewModel model)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		try
		//		{
		//			SaveChanges(model);
		//			return Json(new { success = true });
		//		}
		//		catch (Exception e)
		//		{
		//			ModelState.AddModelError("", e.Message);
		//		}

		//	}
		//	//Something bad happened
		//	return PartialView("_Create", model);
		//}


		//static void SaveChanges(MyViewModel model)
		//{
		//	// Uncommment next line to demonstrate errors in modal
		//	//throw new Exception("Error test");
		//}


	}
}