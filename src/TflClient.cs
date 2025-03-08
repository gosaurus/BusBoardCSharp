using RestSharp;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace BusBoard
{
    class TflClient
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
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
                Logger.Error("No response from TFL API.");
                throw new Exception("No response from TfL API. Contact the API provider.");
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
                Logger.Error("No response from TFL API.");
                throw new Exception("No response from TfL API. Contact the API provider.");
            }
            return response;
        }
    }
}