using RestSharp;

namespace BusBoard
{
    class BusBoard {
        public static async Task Main()
        {
            bool continueProgram = true;

            while (continueProgram)
                {
                string userPostcode = UserInput.GetUserInput();

                var postcodeData = await PostcodeClient.GetPostcodeData(userPostcode);
                var stopPointList = await TflClient.GetStopPointsNearPostcode(
                    latitude: postcodeData.Result.Latitude,
                    longitude: postcodeData.Result.Longitude
                );
                
                if (stopPointList.StopPoints.Count == 0)
                {
                    Console.WriteLine($"No bus stops within 200m of {userPostcode}. Enter another postcode."); //
                    continue; 
                }
                
                foreach (var stopPoint in stopPointList.StopPoints)
                {
                    Console.WriteLine($"\n{stopPoint}");
                    var arrivalsList = await TflClient.GetArrivalsToStopPoint(stopPoint.NaptanId);
                    var sortedArrivalsList = Arrival.SortListOfArrivals(arrivalsList);
                    Arrival.displaySortedArrivalsList(sortedArrivalsList);
                }

                continueProgram = false;
            }
        } 
    }
}