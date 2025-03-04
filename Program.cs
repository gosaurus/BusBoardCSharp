using System.Runtime.InteropServices;
using System.Text.Json;
using RestSharp;

namespace BusBoard
{
    class BusBoard {
        public static async Task Main()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

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
                displaySortedArrivalsList(sortedArrivalsList);
            }
        }

        public static void displaySortedArrivalsList(List<Arrival> sortedArrivalsList) 
        {
            Console.WriteLine("Next buses to arrive:");
            if (sortedArrivalsList.Count == 0)
            {
                Console.WriteLine("No buses arriving to this stop point. Try another postcode.");
            }
            else
            {
                for (int count = 0; count < Math.Min(sortedArrivalsList.Count, 5); count++)
                {
                    Console.WriteLine($"{count+1}. {sortedArrivalsList[count]}");
                }
            }
        }
    }
}