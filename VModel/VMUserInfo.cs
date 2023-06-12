namespace Delivery_order.VModel
{
    public class VMUserInfo
    {
        [Required] public string? Id { get; set; }
        [Required] public string? Name { get; set; }
        [Required] public string? Mobile { get; set; }
        [Required] public bool Sex { get; set; }
        [Required] public int? Region { get; set; }
    }
}
