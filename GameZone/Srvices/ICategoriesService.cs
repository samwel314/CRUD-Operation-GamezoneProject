using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Srvices
{
    public interface ICategoriesService
    {
        IEnumerable<SelectListItem> GetSelects(); 
    }
}
