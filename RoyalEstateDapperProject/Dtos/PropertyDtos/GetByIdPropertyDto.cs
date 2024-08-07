﻿namespace RoyalEstateDapperProject.Dtos.PropertyDtos
{
    public class GetByIdPropertyDto
    {
        public int PropertyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public int Sqft { get; set; }
        public int Bathroom { get; set; }
        public int Bedroom { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
        public int CategoryId { get; set; }
        public int LocationId { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public bool IsRecent { get; set; }
    }
}
