namespace Delivery_order.VModel
{
    public class VMSUserLoction
    {
        [Required]
        public Guid? Id { get; set; }
        [Required]
        public double LocationLate { get; set; }
        [Required]
        public double LocationLong { get; set; }
        [Required, MaxLength(25)]
        public string? Description { get; set; }
    }
}
