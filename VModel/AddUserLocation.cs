namespace Delivery_order.VModel
{
    public class AddUserLocation
    {
        [Required]
        public double LocationLate { get; set; }
        [Required]
        public double LocationLong { get; set; }
        [Required, MaxLength(25)]
        public string? Description { get; set; }
        [Required]
        public string? User { get; set; }
    }
}
