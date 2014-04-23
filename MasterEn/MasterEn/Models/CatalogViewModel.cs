using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasterEn.Classes;

namespace MasterEn.Models
{
	public class CatalogViewModel
	{
		private readonly ApplicationDbContext _db;

		public CatalogViewModel()
		{
			_db = new ApplicationDbContext();
			CatalogItemModels = _db.CatalogItemModels.ToList();
		}

		public void SaveChanges()
		{
			_db.SaveChanges();
		}

		public List<CatalogItemModel> CatalogItemModels { get; set; }

	}
}