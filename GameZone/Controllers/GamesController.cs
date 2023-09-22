using GameZone.Data;
using GameZone.Models;
using GameZone.Models.ViewModels;
using GameZone.Srvices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoriesService _CategoriesService; 
        private readonly IDevicesService _DevicesService;
        private readonly IGamesService _GamesService;

        public GamesController(ICategoriesService CategoriesService , IDevicesService DevicesService , IGamesService GamesService)
        {
            _CategoriesService = CategoriesService;
            _DevicesService = DevicesService; 
            _GamesService = GamesService;   
        }
        //[HttpDelete]
        public IActionResult Delete (int Id)
        {
            var game = _GamesService.Delete(Id);
            if (!game)
                return BadRequest(); 
            return Ok();  
        }
		public IActionResult Edit(int Id)
		{
			var data = _GamesService.GetGameToEdit(Id);
			if (data is null)
				return NotFound();
            EditGameViewModel edit = new EditGameViewModel
            {
                Id = data.Id,
                Name = data.Name,   
                Description = data.Description,
                Categories = _CategoriesService.GetSelects(),
                Devices = _DevicesService.GetSelects(), 
            };
                
			return View(edit);
		}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameViewModel create)
        {
            if (!ModelState.IsValid)
            {
                create.Categories
                    = _CategoriesService.GetSelects();
                create.Devices = _DevicesService.GetSelects();
                return View(create);
            }
            var game =  await _GamesService.Edit(create);
            if (game is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int Id)
        {
            var data = _GamesService.GetGame(Id);
            if (data is null)
                return NotFound();
            return View(data);

        }
        public IActionResult Index()
        {
			var data = _GamesService.Disply();
			return View(data);
		}
        [HttpGet]
        public IActionResult Create ()
        {
            var ViewData =
                new CreateGameModel
                ()
                {
                    Categories = _CategoriesService.GetSelects(),
                    Devices = _DevicesService.GetSelects()
                };
            return View(ViewData);  
        }
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Create(CreateGameModel create)
        {
            if (!ModelState.IsValid)
            {
                create.Categories
                    = _CategoriesService.GetSelects();
                create.Devices = _DevicesService.GetSelects();
                return View(create);
            }
            await _GamesService.Create(create);
            return RedirectToAction(nameof(Index));
        }
    }
}
