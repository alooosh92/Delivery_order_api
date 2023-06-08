namespace Delivery_order.Models
{
    public class Qote
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        [Required] public DateTime? StartDate { get; set; }
        [Required] public DateTime? EndDate { get; set; }
        [Required] public string? ImageUrl { get; set; }
        [Required] public double? Price { get; set; }
        [Required] public Shop? Shop { get; set; }
    }
}
