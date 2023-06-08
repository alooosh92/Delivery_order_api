using System.ComponentModel;

namespace Delivery_order.Models
{

    public class Item
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }
        [Required, MaxLength(20)]
        public string? Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string? Description { get; set; }
        [DefaultValue(0)]
        public double Evaluation { get; set; }
        [DefaultValue(0)]
        public double ResidentsNumber { get; set; }
        [Required]
        public Shop? Shop { get; set; }
        [Required]
        public string? Image { get; set; }
        
    }
}
