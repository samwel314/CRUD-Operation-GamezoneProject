using GameZone.Attribute;
using GameZone.wwwroot.Settings;

namespace GameZone.Models.ViewModels
{
	public class EditGameViewModel : GameFormViewModel
	{
		public int Id { get; set; }	
		[ExtensionCover(StData.AllowedExte)]
		[SIzeCover(StData.MaxinByte)]
		public IFormFile ? Cover { get; set; } = default!;
	}
}
