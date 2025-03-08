using System.Text.RegularExpressions;

namespace BusBoard
{
    class UserInput
    {
        public static string GetUserInput()
        {   
            Console.WriteLine("Enter a valid postcode (case insensitive): ");
            string userInput = Console.ReadLine()!.Trim([' ']);
            string pattern = @"[A-Z]{1,2}\d{1,2}[A-Z]?\s?\d[A-Z]{1,2}";
            Regex postcodeRegex = new Regex(pattern, RegexOptions.IgnoreCase); 
            Match validPostcode = postcodeRegex.Match(userInput);
            if (!validPostcode.Success)
            {
                Console.WriteLine($"Invalid postcode. Please try again or first verify your postcode at https://www.ukpostcode.co.uk/validate-postcode.htm.");
                return GetUserInput();
            }
            return validPostcode.ToString();
        }
    }
}