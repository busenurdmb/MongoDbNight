﻿namespace MongoDbNight.Dtos.OrderDtos
{
    public class UpdateOrderDto
    {
        public string OrderId { get; set; }
        public int OrderProductPiece { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerId { get; set; }
        public string ProductId { get; set; }
    }
}
