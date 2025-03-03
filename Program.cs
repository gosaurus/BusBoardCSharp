using RestSharp;

namespace BusBoard
{
    class BusBoard {
        public static async Task Main()
        {
            string userStopPoint = UserInput.GetUserInput();
            var arrivalsList = await TflClient.GetArrivalsToStopPoint(userStopPoint);
            Console.WriteLine("Next buses to arrive:");
            foreach (var arrival in arrivalsList.Slice(0,5))
            {
                Console.WriteLine(arrival);
            }
        }
    }
}