using AutoMapper;
using MongoDB.Driver;
using MongoDbNight.Dtos.CategoryDtos;
using MongoDbNight.Entities;
using MongoDbNight.Settings;

namespace MongoDbNight.Services.CategoryServices
{
    public class CategoryService:ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            //bağlantı adresini aldım
            var client = new MongoClient(_databaseSettings.ConnectionString);
            //veritabanı adı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            //veritabanındaki category koleksiyonuna bağlanmak için kullanılır
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }
        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value);
        }
        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryId == id);
        }
        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            //Find(x => true): Bu ifade, MongoDB'deki belirli bir koleksiyondaki tüm dökümanları getirmek için kullanılır. x => true filtresi, her dökümanın koşulu sağladığını belirtir, bu nedenle koleksiyondaki tüm dökümanlar seçilir.
          var values = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }
        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var values = await _categoryCollection.Find<Category>(x => x.CategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(values);
        }
        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId, value);
        }
    }
}
