using Dapper;
using RoyalEstateDapperProject.Context;
using RoyalEstateDapperProject.Dtos.PropertyDtos;

namespace RoyalEstateDapperProject.Services.Property
{
    public class PropertyService : IProperyService
    {
        private readonly DapperContext _dapperContext;

        public PropertyService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreatePropertyAsync(CreatePropertyDto createPropertyDto)
        {
            string query = "insert into Properties (Title,Description,VideoUrl,Sqft,Bathroom,Bedroom,Price,CategoryId,LocationId,ImageUrl1,ImageUrl2,ImageUrl3,Address,Status,IsRecent) values (@title,@description,@videourl,@sqft,@bathroom,@bedroom,@price,@categoryid,@locationid,@imageurl1,@imageurl2,@imageurl3,@address,@status,@recent)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createPropertyDto.Title);
            parameters.Add("@description", createPropertyDto.Description);
            parameters.Add("@videourl", createPropertyDto.VideoUrl);
            parameters.Add("@sqft", createPropertyDto.Sqft);
            parameters.Add("@bathroom", createPropertyDto.Bathroom);
            parameters.Add("@bedroom", createPropertyDto.Bedroom);
            parameters.Add("@price", createPropertyDto.Price);
            parameters.Add("@categoryid", createPropertyDto.CategoryId);
            parameters.Add("@locationid", createPropertyDto.LocationId);
            parameters.Add("@imageurl1", createPropertyDto.ImageUrl1);
            parameters.Add("@imageurl2", createPropertyDto.ImageUrl2);
            parameters.Add("@imageurl3", createPropertyDto.ImageUrl3);
            parameters.Add("@address", createPropertyDto.Address);
            parameters.Add("@status", createPropertyDto.Status);
            parameters.Add("@recent", createPropertyDto.IsRecent);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeletePropertyAsync(int id)
        {
            string query = "delete from Properties where PropertyId=@propertyid";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyid", id);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task FeaturePropertiesTrue(int id)
        {
            string query = "update Properties set IsRecent=1 where PropertyId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }
        public async Task FeaturePropertiesFalse(int id)
        {
            string query = "update Properties set IsRecent=0 where PropertyId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultPropertyWithCategoryAndLocationDto>> GetAllPropertyCategoryAndLocationAsync()
        {
            string query = "select * from Properties inner join Categories on Properties.CategoryId = Categories.CategoryId inner join Locations on Properties.LocationId = Locations.LocationId";
            var connection = _dapperContext.SqlConnection();
            var values =await connection.QueryAsync<ResultPropertyWithCategoryAndLocationDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdPropertyDto> GetByIdPropertyAsync(int id)
        {
            string query = "select * from Properties where PropertyId=@propertyid";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyid", id);
            var connection = _dapperContext.SqlConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdPropertyDto>(query, parameters);
            return values;
        }

        public async Task<List<ResultLast5PropertyDto>> GetLast5PropertyListAsync()
        {
            string query = "select top 5 * from Last5Property";
            var connection = _dapperContext.SqlConnection();
            var values = await connection.QueryAsync<ResultLast5PropertyDto>(query);
            return values.ToList();
        }

        public async Task UpdatePropertyAsync(UpdatePropertyDto updatePropertyDto)
        {
            string query = "update Properties set Title=@title,Description=@description,VideoUrl=@videourl,Sqft=@sqft,Bathroom=@bathroom,Bedroom=@bedroom,Price=@price,CategoryId=@categoryid,LocationId=@locationid,ImageUrl1=@imageurl1,ImageUrl2=@imageurl2,ImageUrl3=@imageurl3,Address=@address,Status=@status,IsRecent=@recent where PropertyId=@propertyid";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updatePropertyDto.Title);
            parameters.Add("@description", updatePropertyDto.Description);
            parameters.Add("@videourl", updatePropertyDto.VideoUrl);
            parameters.Add("@sqft", updatePropertyDto.Sqft);
            parameters.Add("@bathroom", updatePropertyDto.Bathroom);
            parameters.Add("@bedroom", updatePropertyDto.Bedroom);
            parameters.Add("@price", updatePropertyDto.Price);
            parameters.Add("@categoryid", updatePropertyDto.CategoryId);
            parameters.Add("@locationid", updatePropertyDto.LocationId);
            parameters.Add("@imageurl1", updatePropertyDto.ImageUrl1);
            parameters.Add("@imageurl2", updatePropertyDto.ImageUrl2);
            parameters.Add("@imageurl3", updatePropertyDto.ImageUrl3);
            parameters.Add("@address", updatePropertyDto.Address);
            parameters.Add("@status", updatePropertyDto.Status);
            parameters.Add("@propertyid", updatePropertyDto.PropertyId);
            parameters.Add("@recent", updatePropertyDto.IsRecent);
            var connection = _dapperContext.SqlConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultRecentPropertiesDto>> GetRecentPropertiesList()
        {
            string query = "select * from RecentProperty";
            var connection = _dapperContext.SqlConnection();
            var values = await connection.QueryAsync<ResultRecentPropertiesDto>(query);
            return values.ToList();
        }

		public async Task<List<ResultSpecialOfferPropertyDto>> GetSpecialOfferPropertiesList()
		{
            string query = "select top 4 * from SpecialOfferProperty order by PropertyId desc";
            var connection = _dapperContext.SqlConnection();
            var values = await connection.QueryAsync<ResultSpecialOfferPropertyDto>(query);
            return values.ToList();
		}

        public async Task<int> GetTestimonialCount()
        {
            string query = "select count(*) from Testimonial";
            var connnection = _dapperContext.SqlConnection();
            var value = await connnection.QueryAsync<int>(query);
            return value.FirstOrDefault();
        }

        public async Task<int> GetPropertyCount()
        {
            string query = "select count(*) from Properties";
            var connnection = _dapperContext.SqlConnection();
            var value = await connnection.QueryAsync<int>(query);
            return value.FirstOrDefault();
        }

        public async Task<int> GetAgentCount()
        {
			string query = "select count(*) from Agent";
			var connnection = _dapperContext.SqlConnection();
			var value = await connnection.QueryAsync<int>(query);
			return value.FirstOrDefault();
		}

        public async Task<GetMaxCategoryNameDto> GetMaxProperyCategory()
        {
			string query = "select top 1 count(*) as 'CategoryCount',Categories.CategoryName from Properties inner join Categories on Properties.CategoryId=Categories.CategoryId group by Properties.CategoryId,CategoryName order by 'CategoryCount' desc";
			var connnection = _dapperContext.SqlConnection();
			var value = await connnection.QueryAsync<GetMaxCategoryNameDto>(query);
			return value.FirstOrDefault();
		}
    }
}
