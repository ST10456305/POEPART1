using System.Media;
using System.Text;

namespace CyberBot;

public class CyberBot
{
    private readonly string _resourcesDirectory;

    public CyberBot()
    {
        _resourcesDirectory = Path.Combine(AppContext.BaseDirectory, "Resources");
    }

    public void PlayGreeting()
    {
        string audioPath = Path.Combine(_resourcesDirectory, "greeting.wav");

        try
        {
            if (!File.Exists(audioPath))
            {
                TypeText("Audio greeting file not found in Resources\\greeting.wav.", ConsoleColor.DarkYellow, 10);
                return;
            }

            using SoundPlayer player = new(audioPath);
            player.Play();
        }
        catch (Exception ex)
        {
            TypeText($"Audio could not be played: {ex.Message}", ConsoleColor.Red, 10);
        }
    }

    public void DisplayLogo()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(GetLogoText());
        Console.ResetColor();
    }

    public void TypeText(string text, ConsoleColor color = ConsoleColor.White, int delay = 30)
    {
        Console.ForegroundColor = color;

        foreach (char character in text)
        {
            Console.Write(character);
            Thread.Sleep(delay);
        }

        Console.WriteLine();
        Console.ResetColor();
    }

    public string GetResponse(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return "I didn't quite catch that. Could you please say something?";
        }

        string lowerInput = input.ToLowerInvariant();

        if (lowerInput.Contains("how are you"))
        {
            return "I'm doing great, thank you for asking! I'm ready to help you stay safe online.";
        }

        if (lowerInput.Contains("password"))
        {
            return "Always use a mix of letters, numbers, and symbols. Never reuse passwords across sites!";
        }

        if (lowerInput.Contains("phishing"))
        {
            return "Phishing is when scammers send fake emails to steal your info. Check the sender's address carefully!";
        }

        if (lowerInput.Contains("purpose"))
        {
            return "I am here to help South African citizens stay safe from cyber threats.";
        }

        if (lowerInput.Contains("what can i ask")
            || lowerInput.Contains("what can i ask you about")
            || lowerInput.Contains("help"))
        {
            return "You can ask me about password safety, phishing scams, and my purpose.";
        }

        return "I'm not sure about that topic yet. You can ask me about passwords, phishing, or my purpose!";
    }

    private string GetLogoText()
    {
        string logoPath = Path.Combine(_resourcesDirectory, "logo.txt");

        if (File.Exists(logoPath))
        {
            return File.ReadAllText(logoPath, Encoding.UTF8);
        }

        return """
                  ______      __             ____        __
                 / ____/_  __/ /_  ___  ____/ / /_____  / /_
                / /   / / / / __ \/ _ \/ __  / __/ __ \/ __/
               / /___/ /_/ / /_/ /  __/ /_/ / /_/ /_/ / /_
               \____/\__, /_.___/\___/\__,_/\__/\____/\__/
                    /____/  AWARENESS ASSISTANT
               """;
    }
}
