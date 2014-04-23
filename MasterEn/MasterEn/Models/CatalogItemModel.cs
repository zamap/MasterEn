using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MasterEn.Models
{
	[Table("CatalogItem")]
	public class CatalogItemModel
	{
		public CatalogItemModel()
		{
		}
		[Key]
		public int CatalogItemId { get; set; }
		public string Name { get; set; }
		public string ShortDescription { get; set; }
		[AllowHtml]
		public string Description { get; set; }
		public double Price { get; set; }
		public int ProductCount { get; set; }
		public string Size { get; set; }
		public string Video { get; set; }
		public int Age { get; set; }
		[Column(TypeName = "image")]
		public byte[] Image { get; set; }
		public byte[] SmallImage { get; set; }
		[Display(Name = "Display Catalog Item")]
		public bool DisplayItem { get; set; }
	}
}