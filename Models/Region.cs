namespace Delivery_order.Models
{
    public class Region
    {
        [Key] public int Id { get; set; }
        [Required,MaxLength(20)] public string? RegionName { get; set; }
      //  [Required] public List<Shop>? Shop { get; set; } = new List<Shop>();
    }
}
