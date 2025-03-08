using System.Diagnostics;
using System.Text.Json;
using RestSharp;
using NLog;

namespace BusBoard
{
    class PostcodeClient
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        private static readonly RestClient postcodeClient = 
            new RestClient(new RestClientOptions("http://api.postcodes.io/postcodes/"));
        public static async Task<PostcodeAPIResponse> GetPostcodeData(string userPostcode)
        {
            var request = new RestRequest(userPostcode);
            var response = await postcodeClient.GetAsync<PostcodeAPIResponse>(request);

            if (response == null)
                {
                    Logger.Error("No API response. Exception thrown.");
                    throw new Exception($"No API response {response} from Postcode.io. Contact the API provider.");
                }
            else if (response.Status != 200)
                {
                    return response;
                }
            else
                return response;
        }
    }
}