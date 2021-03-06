﻿using System;

namespace SchoolPrj.Models
{
    public class Goods
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ImageName { get; set; }
        public byte[] Image { get; set; }
        public GoodsTypes GoodsTypes { get; set; }
    }
}