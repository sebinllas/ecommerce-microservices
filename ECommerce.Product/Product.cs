using System;

namespace ECommerce.Product
{
    public enum ProductGender{
        Male,
        Female,
        Unisex,
    }

    public enum ProductAgeGroup
    {
        Child,
        Adolescent,
        Adult
    } 

    public class Product
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int QuantityInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public ProductGender Gender { get; set; }
        public ProductAgeGroup AgeGroup { get; set; }
    }
}