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
        [Required, DefaultValue(false)]
        public bool IsDone { get; set; }
        [Required, DefaultValue(false)]
        public bool RequestAccept { get; set; }
        [Required, DefaultValue(false)]
        public bool IsEnd { get; set; }
        [Required, MaxLength(4), MinLength(4)]
        public int Pincode { get; set; } = Random.Shared.Next(1000, 9999);
        [Required]
        public User? User { get; set; }
        [Required]
        public Shop? Shop {  get; set; }
        //  public List<ItemPay>? Items { get; set; } = new List<ItemPay>();   

    }
}
