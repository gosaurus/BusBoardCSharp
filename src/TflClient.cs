using RestSharp;

namespace BusBoard
{
    class TflClient
    {
        private static readonly RestClientOptions options = 
            new RestClientOptions("https://api.tfl.gov.uk/StopPoint/");
        private static readonly RestClient stopPointClient =
            new RestClient(options);
        public static async Task<List<Arrival>> GetArrivalsToStopPoint(string userStopPoint)
        {
            var request = new RestRequest(userStopPoint+"/Arrivals");
            var response = await stopPointClient.GetAsync<List<Arrival>>(request);
            if (response == null)
            {
                throw new Exception("TFL API error");
            }
            return response;
        }
        public static async Task<StopPointAPIResponse> GetStopPointsNearPostcode(
            double longitude, double latitude
        )
        {
            var request = new RestRequest
            (
                "/?lat="+latitude+"&lon="+longitude+"&stopTypes=NaptanPublicBusCoachTram"
            );
            var response = await stopPointClient.GetAsync<StopPointAPIResponse>(request);
            if (response == null)
            {
                throw new Exception("TFL API error");
            }
            return response;
        }
    }
}