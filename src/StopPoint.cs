using System.Text.Json.Serialization;
namespace BusBoard
{
    public class StopPoint
    {
        [JsonPropertyName("naptanId")]
        public required string NaptanId { get; set; }
        [JsonPropertyName("commonName")]
        public required string CommonName {get; set; }
        public override string ToString()
        {
            return $"StopPoint id: {NaptanId} StopPoint Name: {CommonName}";
        }
    }

    public class StopPointAPIResponse
    {
        [JsonPropertyName("stopPoints")]
        public required List<StopPoint> StopPoints { get; set; }
    }
}