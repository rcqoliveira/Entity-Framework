﻿namespace RC.EntityFramework.Api.Core.Request
{
    public class ProductUpdateRequest 
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
    }
}
