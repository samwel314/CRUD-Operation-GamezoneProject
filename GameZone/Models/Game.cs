using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class Game : BaseEntity
    {
        [StringLength(2000)]
        public string Description { get; set; } =string.Empty;
        [StringLength(500)]
        public string Cover { get; set; } = string.Empty; 
        public int CategoryId { get; set; } 
        public Category Category { get; set; } = default!;
        public ICollection<GameDevice> Devices { get; set; } = default!; 
    }
}
