using System.ComponentModel;

namespace Delivery_order.Models
{
    public class Order
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }        
        public DateTime? OrderDate { get; set; } = DateTime.Now;
        [Required]
        public double DeliveryPrice { get; set; }
        [Required]
        public double FromLate { get; set; }
        [Required]
        public double FromLong { get; set; }
        [Required]
        public double ToLate { get; set; }
        [Required]
        public double ToLong { get; set; }
        public DateTime? IsDone { get; set; }
        public DateTime? RequestAccept { get; set; }
        public DateTime? IsEnd { get; set; }
        [Required, MaxLength(4), MinLength(4)]
        public int Pincode { get; set; } = Random.Shared.Next(1000, 9999);
        [Required]
        public User? User { get; set; }
        
        public Shop? Shop {  get; set; }
        }
}
