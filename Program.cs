using RestSharp;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace BusBoard
{
    class BusBoard {
        public static async Task Main()
        {
            // Logger config
            var config = new LoggingConfiguration();
            var target = new FileTarget 
                { 
                    FileName = @"./Logger.log",
                    Layout = @"${longdate} ${level} - ${logger}: ${message}"
                };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;

            bool continueProgram = true;

            while (continueProgram)
                {
                string userPostcode = UserInput.GetUserInput();

                var postcodeData = await PostcodeClient.GetPostcodeData(userPostcode);
                if (postcodeData.Status != 200)
                {
                    Console.WriteLine($"{postcodeData}");
                    continue;
                }

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