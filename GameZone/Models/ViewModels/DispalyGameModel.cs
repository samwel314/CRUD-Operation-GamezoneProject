namespace GameZone.Models.ViewModels
{
    public class DispalyGameModel
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty; 
        public string Description { get; set; } = string.Empty;
        public string CategoryName { get ; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;   
        
        public List<string> Icons = default!; 
    }
}
