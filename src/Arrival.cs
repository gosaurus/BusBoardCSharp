using System.Runtime.CompilerServices;

namespace BusBoard {
    class Arrival {
        public required string naptanId { get; set; }
        public required string lineId { get; set; }
        public required string destinationName { get; set; }
        public required int timeToStation { get; set; }
        public override string ToString()
        {
            return $"Bus {lineId} towards {destinationName} arriving in {timeToStation} mins.";
        } 
    }
}