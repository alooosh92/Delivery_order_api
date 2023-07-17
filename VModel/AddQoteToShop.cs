namespace Delivery_order.VModel
{
    public class AddQoteToShop
    {
        [Required] public DateTime? StartDate { get; set; }
        [Required] public DateTime? EndDate { get; set; }
        [Required] public string? ImageUrl { get; set; }
        [Required] public double? Price { get; set; }
        [Required] public Guid? Shop { get; set; }
        [Required] public string? Title { get; set; }
        [Required] public string? Body { get; set; }
    }
}
