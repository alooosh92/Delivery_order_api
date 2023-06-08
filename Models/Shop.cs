using System.ComponentModel;

namespace Delivery_order.Models
{
    public class Shop
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }
        [Required,MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        public Region? Region { get; set; }
        [DefaultValue(0)]
        public double Evaluation { get; set; }
        [DefaultValue(0)] 
        public double ResidentsNumber { get; set; }
        [Required]
        public double LocationLate { get; set; }
        [Required]
        public double LocationLong { get; set; }
        [Required]
        public ShopType? Type { get; set; }
        [Required]
        public string? UrlImage { get; set; }
        [Required]
        public string? UrlIcon { get; set; }

    }
}
