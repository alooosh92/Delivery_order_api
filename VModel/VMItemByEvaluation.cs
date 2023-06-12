namespace Delivery_order.VModel
{
    public class VMItemByEvaluation
    {
        [Required]public Guid? id {  get; set; }
        [Required] public string? name { get; set; }
        [Required] public string? shop { get; set; }
        [Required] public double Evaluation { get; set; }
        [Required] public double price { get; set; }
        [Required] public string? image { get; set; }
    }
}
