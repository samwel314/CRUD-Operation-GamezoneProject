using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using GameZone.Attribute;
using GameZone.wwwroot.Settings;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Models.ViewModels
{
    public class CreateGameModel : GameFormViewModel
	{

		[ExtensionCover(StData.AllowedExte)]
        [SIzeCover(StData.MaxinByte)]
        public IFormFile Cover { get; set; } = default!;
    }
}
