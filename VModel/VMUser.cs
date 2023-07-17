namespace Delivery_order.VModel
{
    public class VMUser
    {
        [Required]
        public string? userId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public bool Sex { get; set; }
        [Required]
        public Region? Region { get; set; }
        public string? Adress { get; set; }
        [Required,Phone]
        public string? Phone { get; set; }
        public string? fireBaseToken { get; set; }
    }
}
