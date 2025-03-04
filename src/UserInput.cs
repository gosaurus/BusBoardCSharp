namespace BusBoard
{
    class UserInput
    {
        public static string GetUserInput()
        {   
            Console.WriteLine("Enter postcode: ");
            string rawInput = Console.ReadLine()!;
            string userInput = rawInput.Trim([' ']);
            if (userInput == null)
            {
                return GetUserInput();
            }
            return userInput;
        }
    }
}