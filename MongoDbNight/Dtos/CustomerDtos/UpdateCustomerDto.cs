﻿namespace MongoDbNight.Dtos.CustomerDtos
{
    public class UpdateCustomerDto
    {
        public string CustomerId { get; set; }
        public string CustomerNameSurname { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerMail { get; set; }
    }
}
