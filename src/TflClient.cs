using RestSharp;

namespace BusBoard
{
    class TflClient
    {
        private static readonly RestClientOptions options = 
            new RestClientOptions("https://api.tfl.gov.uk/StopPoint/");
        private static readonly RestClient stopPointClient =
            new RestClient(options);
        public static async Task<List<Arrival>> GetArrivalsToStopPoint
        (
            string userStopPoint
        )
        {
            var request = new RestRequest(userStopPoint+"/Arrivals");
            var response = await stopPointClient.GetAsync<List<Arrival>>
            (
                request
            );
            if (response == null)
                {
                    throw new Exception("TFL API error: null response");
                }
            return response;
        }
    }
}