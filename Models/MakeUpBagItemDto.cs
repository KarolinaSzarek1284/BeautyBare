using BeautyBareAPI.Entities;

namespace BeautyBareAPI.Models
{
    public class MakeUpBagItemDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
