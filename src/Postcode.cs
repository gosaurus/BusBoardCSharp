using System.Text.Json.Serialization;
namespace BusBoard
{
    class Postcode
    {
        [JsonPropertyName("longitude")]
        public required double Longitude { get; set; }
        [JsonPropertyName("latitude")]
        public required double Latitude { get; set; }

    }

    class PostcodeAPIResponse
    {
        [JsonPropertyName("result")]
        public Postcode? Result { get; set; }
    }

    class PostcodeHelpers
    {
        
    }
}