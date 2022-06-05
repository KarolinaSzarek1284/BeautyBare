namespace BeautyBareAPI.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
