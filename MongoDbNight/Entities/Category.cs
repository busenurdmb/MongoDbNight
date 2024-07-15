using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbNight.Entities
{
    public class Category
    {
        [BsonId] //MongoDb de bir sutünün Id olduğunu bildirmek için bu attribüt ekleniyor
        [BsonRepresentation(BsonType.ObjectId)] //bunun benzersiz olup guid bir değer alabilmesi için bu attribüt ekleniyor
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
