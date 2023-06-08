namespace Delivery_order.Models
{
    public class ShopType
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }
        [Required,MaxLength(25)]
        public string? Type { get; set; }        
        [Required]
        public bool IsFood { get; set; }
    }
}
