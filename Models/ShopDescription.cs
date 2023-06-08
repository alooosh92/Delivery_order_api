namespace Delivery_order.Models
{
    public class ShopDescription
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }
        [Required,MaxLength(20)]
        public string? Description { get; set; }
        [Required]
        public Shop? Shop { get; set; }
    }
}
