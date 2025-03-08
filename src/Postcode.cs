using RestSharp;

namespace BusBoard
{
    public class Postcode
    {
        public required double Longitude { get; set; }
        public required double Latitude { get; set; }

    }

    public class PostcodeAPIResponse
    {
        public Postcode? Result { get; set; }
        public int? Status { get; set;}
        public string? Error { get; set;}

        public string? ResponseStatus { get; set; }

        public override string ToString()
        {
            return $"{Result} - status {Status} - Error {Error} - responsestatus {ResponseStatus}";
        }
    }

}