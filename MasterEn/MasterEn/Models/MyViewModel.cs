using System.ComponentModel.DataAnnotations;

namespace MasterEn.Models
{
	public class MyViewModel
	{
		public string Foo { get; set; }

		[Required(ErrorMessage = "The bar is absolutely required")]
		public string Bar { get; set; }
	}
}