using System.Runtime.CompilerServices;

namespace BusBoard {
    class Arrival {
        public required string naptanId { get; set; }
        public required string lineId { get; set; }
        public required string destinationName { get; set; }
        public required int timeToStation { get; set; }
        public int? minutesToStation { 
            get {
                return convertSecondsToMinutes(timeToStation); 
            }
        
        }
        public int convertSecondsToMinutes(int timeToStation) {
            var timeToStationMinutes = timeToStation / 60;
            return timeToStationMinutes;
        }
        public override string ToString()
        {
            return $"Bus {lineId} towards {destinationName} arriving in {convertSecondsToMinutes(timeToStation)} mins.";
        } 

        public static List<Arrival> SortListOfArrivals(List<Arrival> arrivalsList)
        {
            return arrivalsList.OrderBy(arrival => arrival.timeToStation).ToList();
        }
    }
}