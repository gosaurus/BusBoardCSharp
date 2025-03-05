namespace BusBoard
{
    public class StopPoint
    {
        public required string NaptanId { get; set; }
        public required string CommonName {get; set; }
        public override string ToString()
        {
            return $"StopPoint id: {NaptanId} StopPoint Name: {CommonName}";
        }
    }

    public class StopPointAPIResponse
    {
        public required List<StopPoint> StopPoints { get; set; }
    }
}