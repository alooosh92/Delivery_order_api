namespace Delivery_order.VModel
{
    public class AddItemToOrdre
    {
        [Required] public Guid? Item { get; set; }
        [Required] public int NumberOfItem { get; set; }
        public string? Notes { get; set; }
        [Required] public Guid? LocationId {  get; set; }
        [Required] public double Price { get; set; }
    }
}
