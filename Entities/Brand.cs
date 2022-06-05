﻿namespace BeautyBareAPI.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
