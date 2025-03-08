namespace BusBoard
{
   class TimeHelpers
   { 
        public static int SecondsToMinutes(int timeToStation) {
            var timeToStationMinutes = timeToStation / 60;
            return timeToStationMinutes;
        }
   }
}