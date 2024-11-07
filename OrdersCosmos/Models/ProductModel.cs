
using Newtonsoft.Json;
namespace Product_API.Models
{

   
            public class ProductModel
    {

        [JsonProperty("id")]
        public string? Id { get; set; }
        [JsonProperty("title")]
        public string? Title { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}