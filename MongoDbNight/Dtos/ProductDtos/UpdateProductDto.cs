﻿namespace MongoDbNight.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public string SavedUrl { get; set; }
        public string SavedFileName { get; set; }
        public string CategoryId { get; set; }
    }
}
