namespace WebExpertSystem.UI;

public static class InputMachine
{
    public static int GetNumberFromConsole()
    {
        var message = Console.ReadLine();
        if (int.TryParse(message, out var number))
        {
            return number;
        }

        throw new ArgumentException("Input correct number");
    }
}