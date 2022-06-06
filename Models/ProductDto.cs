namespace BeautyBareAPI.Models
{
    public class ProductDto
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
        public string BrandName { get; set; }
        public string BrandCountry { get; set; }

        public List<IngredientDto> Ingredients { get; set; }
    }
}
