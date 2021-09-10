﻿using System;

namespace RC.EntityFramework.Api.Core.Response
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
    }
}
