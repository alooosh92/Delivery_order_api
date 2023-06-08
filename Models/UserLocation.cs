namespace Delivery_order.Models
{
    public class VMSUserLocation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }
        [Required]
        public double LocationLate { get; set; }
        [Required]
        public double LocationLong { get; set; }
        [Required, MaxLength(25)]
        public string? Description { get; set; }
        [Required]
        public User? User { get; set; }
    }
}
