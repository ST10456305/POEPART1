namespace CyberBot;

internal static class Program
{
    private static void Main()
    {
        CyberBot bot = new();

        bot.PlayGreeting();
        bot.DisplayLogo();

        bot.TypeText("Hello! Welcome to the Cybersecurity Awareness Bot. I`m here to help you stay safe online. What is your name?", ConsoleColor.Yellow);
        Console.Write("You: ");
        string userName = Console.ReadLine()?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(userName))
        {
            userName = "friend";
        }

        bot.TypeText($"Nice to meet you, {userName}! How can I help you stay safe online today?", ConsoleColor.Green);
        bot.TypeText("Ask about passwords, phishing, or type 'exit' to close.", ConsoleColor.DarkCyan, 15);

        while (true)
        {
            Console.Write("\nYou: ");
            string? input = Console.ReadLine();

            if (string.Equals(input?.Trim(), "exit", StringComparison.OrdinalIgnoreCase))
            {
                bot.TypeText("Stay safe online. Goodbye!", ConsoleColor.Yellow);
                break;
            }

            string response = bot.GetResponse(input);
            bot.TypeText($"Bot: {response}", ConsoleColor.Cyan);
        }
    }
}
