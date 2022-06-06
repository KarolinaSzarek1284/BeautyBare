namespace BeautyBareAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string Contraindications { get; set; }
        public string Apllying { get; set; }
        public int Capacity { get; set; }
        public bool IsVegan { get; set; }
        public string Country { get; set; }
        public bool InUse { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
