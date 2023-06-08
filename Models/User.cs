namespace Delivery_order.Models
{
    public class User : IdentityUser
    {
        [Required,MaxLength(30)]
        public string? Name { get;set; }
        [Required]
        public bool Sex { get; set; }
        [Required]
        public double UserPoint { get; set; }
        public Region? Region { get; set; }
        public string? Adress { get; set; }
        public string? InvitationLink { get; set; } = Guid.NewGuid().ToString().Trim();
    }
}
