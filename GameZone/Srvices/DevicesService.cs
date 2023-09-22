using GameZone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Srvices
{
    public class DevicesService : IDevicesService
    {
        private AppDbContext _db;
        public DevicesService(AppDbContext _db)
        {
            this._db = _db;
        }
        
        public IEnumerable<SelectListItem> GetSelects()
        {
            return _db.Devices
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .AsNoTracking()
                .ToList().OrderBy(x=>x.Text);
        }
    }
}
