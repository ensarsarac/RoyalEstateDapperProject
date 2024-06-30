namespace RoyalEstateDapperProject.Dtos.PropertyDtos
{
	public class ResultSpecialOfferPropertyDto
	{
		public int PropertyId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl1 { get; set; }
		public string CategoryName { get; set; }
		public string Status { get; set; }
		public int Sqft { get; set; }
		public int Bathroom { get; set; }
		public int Bedroom { get; set; }
	}
}
