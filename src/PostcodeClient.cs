using RestSharp;

namespace BusBoard
{
    class PostcodeClient
    {
        private static readonly RestClient postcodeClient = 
            new RestClient(new RestClientOptions("http://api.postcodes.io/postcodes/"));
        public static async Task<PostcodeAPIResponse> GetPostcodeData()
        {
            var request = new RestRequest("NW51TL");
            var response = await postcodeClient.GetAsync<PostcodeAPIResponse>(request);
            if (response == null)
            {
                throw new Exception("Postcodes.io API error");
            }
            return response; 
        }
    }
}