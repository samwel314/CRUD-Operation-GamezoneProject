using GameZone.Models;
using GameZone.Models.ViewModels;

namespace GameZone.Srvices
{
    public interface IGamesService
    {
         Task Create(CreateGameModel Game);
        IEnumerable<DispalyGameModel> Disply();
        Task<Game ?> Edit(EditGameViewModel Game);
        DispalyGameModel ? GetGame(int id);
		Game? GetGameToEdit(int id);

        bool Delete(int Id); 
	}
}
