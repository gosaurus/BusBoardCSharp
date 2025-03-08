using System.Text.Json;
using RestSharp;

namespace BusBoard
{
    class PostcodeClient
    {
        private static readonly RestClient postcodeClient = 
            new RestClient(new RestClientOptions("http://api.postcodes.io/postcodes/"));
        public static async Task<PostcodeAPIResponse> GetPostcodeData(string userPostcode)
        {
            var request = new RestRequest(userPostcode);
            var response = await postcodeClient.GetAsync<PostcodeAPIResponse>(request);
            if (response == null)
            {
                throw new Exception("Postcodes.io API error");
            }
            else if (response.status == 404)
            {
                throw new Exception("Postcode not found.");
            }
            return response; 
        }
    }
}