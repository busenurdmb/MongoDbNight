namespace MongoDbNight.Dtos.ProductDtos
{
    public class CreateProductDto
    {
       
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

       public string CategoryId { get; set; }
        public IFormFile ImageUrl { get; set; }
        public string SavedUrl { get; set; }
        public string SavedFileName { get; set; }
    }
}
