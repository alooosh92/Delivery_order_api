namespace Delivery_order.VModel
{
    public class VMOrder
    {
        public double Late { get; set; }
        public double Long { get; set; }
        public string? Notes { get; set; }
        [Required] public Guid? LocationId { get; set; }
        [Required] public double Price { get; set; }
    }
}
