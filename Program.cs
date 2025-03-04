using System.Runtime.InteropServices;
using RestSharp;

namespace BusBoard
{
    class BusBoard {
        public static async Task Main()
        {
            // var options = new JsonSerializerOptions
            // {
            //     PropertyNameCaseInsensitive = true
            // };

            string userPostcode = UserInput.GetUserInput();

            var postcodeData = await PostcodeClient.GetPostcodeData(userPostcode);
            var longitude = postcodeData.Result.Longitude; 
            var latitude = postcodeData.Result.Latitude; 
            var stopPointList = await TflClient.GetStopPointsNearPostcode(
                latitude: latitude,
                longitude: longitude
            );
            foreach (var stopPoint in stopPointList.StopPoints)
            {
                Console.WriteLine($"\n{stopPoint}");
                var arrivalsList = await TflClient.GetArrivalsToStopPoint(stopPoint.NaptanId);
                var sortedArrivalsList = Arrival.SortListOfArrivals(arrivalsList);
                Console.WriteLine("Next buses to arrive:");
                for (int count = 0; count < sortedArrivalsList.Slice(0,5).Count; count++)
                {
                    Console.WriteLine($"{count+1}. {sortedArrivalsList[count]}");
                }
            }

        }
    }
}