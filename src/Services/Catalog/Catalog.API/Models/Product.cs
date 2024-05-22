﻿namespace Catalog.API.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public List<String> Catagories { get; set; } = new();
        public string ImageUrl { get; set; } = default!;
        public float price  { get; set; }
    }
}
