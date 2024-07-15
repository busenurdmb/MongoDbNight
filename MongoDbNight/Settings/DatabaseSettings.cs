namespace MongoDbNight.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        //Property bazında miras aldığımda bu şekilde propertylerin içinde bir şeyin implemente edilmediğine dair bilgi dönen içerik sunuyor bizde direk propertyleri alıyoruz içeriisnde bir şeyin implemente edilip edilmediği ile ilgilenmiyoruz sade sınıf kullansakta olurda solide uymak adına hem interface hem sınıfı olsun istedik
        //public string CategoryCollectionName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
