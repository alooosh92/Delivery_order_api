using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Delivery_order.VModel
{
    public class VMUserOrder
    {
        [Required]public Guid? Id { get; set; }
        [Required] public string? ShopName { get; set; }
        [Required] public DateTime? CreateDate { get; set; }
        [Required] public DateTime? ConfirmOrder { get; set; }
        [Required] public DateTime? AccseptOrder { get; set; }
        [Required] public DateTime? DeliveryTime { get; set; }
        [Required] public double Delivery { get; set; }
        [Required] public int Code { get; set; }
        [Required] public List<TabelRowItem>? ListOrder { get; set; }
    }
}

public class TabelRowItem
{
    [Required] public string? ItemName{ get; set; }
    [Required] public int Number { get; set; }
    [Required] public double Price { get; set; }
}