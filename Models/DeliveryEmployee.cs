namespace Delivery_order.Models
{
    public class DeliveryEmployee
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }
        [Required]
        public Order? Order { get; set; }
        [Required]
        public User? Employee { get; set; }
    }
}
