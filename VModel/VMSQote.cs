namespace Delivery_order.VModel
{
    public class VMSQote
    {
        [Required] public Guid? Id { get; set; }
        [Required] public string? ImageUrl { get; set; }
        [Required] public string? Shoptype { get; set; }
    }
}
