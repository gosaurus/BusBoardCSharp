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
        public int? status { get; set;}
    }

}