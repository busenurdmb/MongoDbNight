using AutoMapper;
using MongoDB.Driver;
using MongoDbNight.Dtos.ProductDtos;
using MongoDbNight.Entities;
using MongoDbNight.Settings;

namespace MongoDbNight.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettins)
        {
            var client = new MongoClient(_databaseSettins.ConnectionString);
            var database = client.GetDatabase(_databaseSettins.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettins.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettins.CategoryCollectionName);
            _mapper = mapper;
           
        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(value);
        }
        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }
        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();

            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find(x => x.CategoryId == item.CategoryId).FirstAsync();
            }

            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
        }
        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var values = await _productCollection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);
        }
        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);
        }
    }
}
