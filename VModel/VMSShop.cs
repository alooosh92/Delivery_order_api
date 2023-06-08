using System.ComponentModel;

namespace Delivery_order.VModel
{
    public class VMSShop
    {
        [Required] public Guid? Id { get; set; }
        [Required] public string? ShopName { get; set; }
        [Required] public string? UrlImage { get; set; }
        [Required] public string? UrlLogo { get; set; }
        [Required] public string? Type { get; set; }
        [Required] public bool IsFood { get;set; }
        [Required] public List<string>? ShopDescription { get; set; }
        [Required] public double LateLocation { get; set; }
        [Required] public double LongLocation { get; set; }
        [Required] public double Evaluation { get; set; }        
        [Required] public double ResidentsNumber { get; set; }
    }
}
