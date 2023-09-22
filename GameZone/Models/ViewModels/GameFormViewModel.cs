using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Models.ViewModels
{
	public class GameFormViewModel
	{
		[StringLength(250)]
		[Required(ErrorMessage = "Enter Game Name ")]
		public string Name { get; set; } = string.Empty;
		[StringLength(2000)]
		[Required(ErrorMessage = "Enter Game Description ")]
		public string Description { get; set; } = string.Empty;
		[Display(Name = "Game Category ")]
		public int CategoryId { get; set; }
		public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
		[Display(Name = "Works On ")]
		public List<int> SelectedDevices { get; set; } = default!;

		public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
	}
}
