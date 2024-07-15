namespace MongoDbNight.Settings
{
    public interface IDatabaseSettings
    {
        //Collection->Tablo İsmini Karşılıyor
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string OrderCollectionName { get; set; }
        public string CustomerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
