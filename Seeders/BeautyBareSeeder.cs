using BeautyBareAPI.Entities;

namespace BeautyBareAPI.Seeders
{
    public class BeautyBareSeeder
    {
        private readonly BeautyBareContext _dbContext;

        public BeautyBareSeeder(BeautyBareContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Products.Any())
                {
                    var products = GetProducts();
                    _dbContext.Products.AddRange(products);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Admin"
                },
            };

            return roles;
        }

        private IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    Name = "Luxury Ceramides",
                    Description = "CERAMIDOWY KREM-SERUM POD OCZY I NA POWIEKI to luksusowy krem dla skóry dojrzałej," +
                    " który poprawia gładkość i napięcie skóry oraz zmniejsza widoczność worków pod oczami.",
                    Category = "Pielęgnacja twarzy",
                    Subcategory = "Krem pod oczy",
                    Contraindications = "Brak",
                    Apllying = "Codziennie rano i wieczorem wmasuj krem w oczyszczoną skórę wokół oczu i na powieki.",
                    Capacity = 15,
                    IsVegan = false,
                    Country = "Poland",
                    InUse = false,
                    Ingredients = new List<Ingredient>()
                    {
                        new Ingredient()
                        {
                            Name = "Aqua"
                        },
                        new Ingredient()
                        {
                            Name = "Rosa Damascena Flower Water"
                        },
                        new Ingredient()
                        {
                            Name = "Caprylic/Capric Triglyceride"
                        },
                        new Ingredient()
                        {
                            Name = "Dicaprylyl Ether"
                        },
                        new Ingredient()
                        {
                            Name = "Hydrogenated Coco-Glycerides"
                        },

                    },
                    Brand = new Brand()
                    {
                        Name = "DERMIKA",
                        Country = "Poland"
                    }
                },

                new Product()
                {
                    Name = "Cellular Luminous",
                    Description = "intensywne serum przeciw przebarwieniom skóry",
                    Category = "Pielęgnacja twarzy",
                    Subcategory = "Serum",
                    Contraindications = "Brak",
                    Apllying = "Stosuj codziennie rano i wieczorem na oczyszczoną skórę.",
                    Capacity = 100,
                    IsVegan = false,
                    Country = "Poland",
                    InUse = false,
                    Ingredients = new List<Ingredient>()
                    {
                        new Ingredient()
                        {
                            Name = "Aqua"
                        },
                        new Ingredient()
                        {
                            Name = "Isopropyl Palmitate"
                        },
                        new Ingredient()
                        {
                            Name = "Cetearyl Isononanoate"
                        },
                        new Ingredient()
                        {
                            Name = "Dimethicone"
                        },
                        new Ingredient()
                        {
                            Name = "Glycerin"
                        },

                    },
                    Brand = new Brand()
                    {
                        Name = "NIVEA",
                        Country = "Germany"
                    }
                },

                new Product()
                {
                    Name = "dermo face sebio+",
                    Description = "żel do mycia twarzy, 2 kwasy AHA + LHA",
                    Category = "Oczyszczanie i demakijaż",
                    Subcategory = "Żele i pianki do twarzy",
                    Contraindications = "Brak",
                    Apllying = "Codziennie rano i wieczorem wmasuj krem w oczyszczoną skórę wokół oczu i na powieki.",
                    Capacity = 195,
                    IsVegan = false,
                    Country = "Poland",
                    InUse = false,
                    Ingredients = new List<Ingredient>()
                    {
                        new Ingredient()
                        {
                            Name = "Aqua"
                        },
                        new Ingredient()
                        {
                            Name = "Polysorbate 20"
                        },
                        new Ingredient()
                        {
                            Name = "Poloxamer 184"
                        },
                        new Ingredient()
                        {
                            Name = "Glycerin"
                        },
                        new Ingredient()
                        {
                            Name = "Peat Extract"
                        },

                    },
                    Brand = new Brand()
                    {
                        Name = "TOŁPA",
                        Country = "Poland"
                    }
                }
            };



            return products;
        }
    }
}
