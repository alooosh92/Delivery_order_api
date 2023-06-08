namespace Delivery_order.Models
{
    public class ItemPay
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }
        [Required] public Item? Item { get; set; }
        [Required] public int NumberOfItem { get; set; }        
        public string? Notes { get; set; }
        [Required]
        public Order? Order { get; set; }
    }
}
