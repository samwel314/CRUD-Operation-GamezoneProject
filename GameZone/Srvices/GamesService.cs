using GameZone.Data;
using GameZone.Models;
using GameZone.Models.ViewModels;
using GameZone.wwwroot.Settings;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GameZone.Srvices

{
    public class GamesService : IGamesService
    {
        private AppDbContext _db;
        private IWebHostEnvironment _webHostEnvironment;
        private string _imagePath; 
        public GamesService(AppDbContext _db, IWebHostEnvironment webHostEnvironment)
        {
            this._db = _db;
            _webHostEnvironment = webHostEnvironment;
            _imagePath = $"{_webHostEnvironment.WebRootPath}{StData.Filepath}";
        }
        public async Task<Game ? > Edit(EditGameViewModel Game)
        {
            var  model = _db.Games.Include(X=>X.Devices).FirstOrDefault(x=>x.Id == Game.Id);
           if (model == null) 
                return null;
           var oldCover = model.Cover;  
            model.Name = Game.Name;
            model.Description = Game.Description;
            model.Devices =
                Game.SelectedDevices.Select(x => new GameDevice { DeviceId = x }).ToList();
            model.CategoryId = Game.CategoryId;
            if (Game.Cover != null)
            {
                model.Cover = await SaveCover(Game.Cover);   
            }
        
            _db.Update(model);
           var rows =  _db.SaveChanges();
            if (rows > 0)
            {
                if (Game.Cover!= null) 
                {
                  var path =   Path.Combine(_imagePath, oldCover);
                    File.Delete(path);  
                }
                return model;
            }
            else
            {
                var path = Path.Combine(_imagePath, model.Cover);
                File.Delete(path);
                return null;
            }
       
        }

        public async Task Create(CreateGameModel Game)
        {

            var CoverName = await SaveCover(Game.Cover);

            var model = new Game
            {
                Name = Game.Name,
                Description = Game.Description,
                Cover = CoverName,
                Devices =
                Game.SelectedDevices.Select(x => new GameDevice { DeviceId = x }).ToList()
                , CategoryId = Game.CategoryId,

            };

            _db.Add(model); 
            _db.SaveChanges();  
        }

        public IEnumerable<DispalyGameModel> Disply()
        {
            var data =
                 _db.Games.Select(g =>
                 new DispalyGameModel
                 {
                     Id = g.Id,
                     Name = g.Name,
                     Description = g.Description,
                     ImageUrl = g.Cover,
                     Icons = g.Devices.Select(d => d.Device.Icon).ToList(),
                     CategoryName = g.Category.Name,
                 }).ToList();

              return data; 
        }

        public DispalyGameModel ? GetGame(int id)
        {
            var data =
                _db.Games.Select(g =>
                new DispalyGameModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Description = g.Description,
                    ImageUrl = g.Cover,
                    Icons = g.Devices.Select(d => d.Device.Icon).ToList(),
                    CategoryName = g.Category.Name,
                }).FirstOrDefault(x => x.Id == id);

            return data;
        }

		public Game? GetGameToEdit(int id)
		{
			return _db.Games.Include(g=>g.Devices)
                .Include(g=>g.Category).FirstOrDefault(x=>x.Id == id);   
		}

      
        private async Task<string> SaveCover(IFormFile file)
        {
            var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            var path = Path.Combine(_imagePath, CoverName);

            using var stream = File.Create(path);
            await file.CopyToAsync(stream);
            return CoverName; 
        }

        public bool Delete(int Id)
        {
            var game = _db.Games.Find(Id);
            if (game == null)
                return false;
            _db.Remove(game);
            var rows = _db.SaveChanges();
            if (rows>0)
            {
                var path = Path.Combine(_imagePath, game.Cover);
                File.Delete(path);  
                return true;
            }
            return false;
           
        }
    }
}
