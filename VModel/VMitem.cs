using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Delivery_order.VModel
{
    public class VMitem
    {
        [Required] public Guid? Id { get; set; }
        [Required] public string? Name { get; set; }
        [Required] public string? Info { get; set; }
        [Required] public double Price { get; set; }
        [Required] public double ShopLate { get; set; }
        [Required] public double ShopLong { get; set; }
        [Required] public double Evaluation { get; set; }
        [Required] public string? Image { get; set; }
        [Required] public Guid? Shopid { get; set; }
    }
}
