﻿namespace HotelManagerSystem.Models.Request.CreateRequest
{
    public class CreateDescDirectoryRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}