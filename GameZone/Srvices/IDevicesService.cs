using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Srvices
{
    public interface IDevicesService
    {
        IEnumerable<SelectListItem> GetSelects();
    }
}
