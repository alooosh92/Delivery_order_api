namespace Delivery_order.VModel
{
    public class VMMessage
    {
        [Required] public string? Message { get; set; }
        [Required] public string? Title { get; set; }
        [Required] public string? Region { get; set; }
    }
}
