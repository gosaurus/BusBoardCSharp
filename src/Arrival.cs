namespace BusBoard {
    class Arrival {
        public required string naptanId { get; set; }
        public required string lineId { get; set; }
        public required string destinationName { get; set; }
        public required int timeToStation { get; set; }
        public override string ToString()
        {
            return $"Bus {lineId} towards {destinationName} arriving in {TimeHelpers.SecondsToMinutes(timeToStation)} mins.";
        } 

        public static List<Arrival> SortListOfArrivals(List<Arrival> arrivalsList)
        {
            return arrivalsList.OrderBy(arrival => arrival.timeToStation).ToList();
        }
    }
}