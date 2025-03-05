namespace BusBoard {
    class Arrival {
        public required string NaptanId { get; set; }
        public required string LineId { get; set; }
        public required string DestinationName { get; set; }
        public required int TimeToStation { get; set; }
        public override string ToString()
        {
            return $"Bus {LineId} towards {DestinationName} arriving in {TimeHelpers.SecondsToMinutes(TimeToStation)} mins.";
        } 

        public static List<Arrival> SortListOfArrivals(List<Arrival> arrivalsList)
        {
            return arrivalsList.OrderBy(arrival => arrival.TimeToStation).ToList();
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