using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string fileName = PromptForNonEmptyInput("Enter the file name (without extension): ", "The file name cannot be empty.");
        int width = PromptForPositiveInt("Enter the SVG width: ", "The width must be a positive integer.");
        int height = PromptForPositiveInt("Enter the SVG height: ", "The height must be a positive integer.");
        string fillColor = PromptForNonEmptyInput("Enter the background color: ", "The background color cannot be empty.");

        string filePath = $"{fileName}.svg";
        string svgContent = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
        <svg width=""{width}"" height=""{height}"" xmlns=""http://www.w3.org/2000/svg"">
        <rect width=""100%"" height=""100%"" fill=""{fillColor}"" />
        </svg>";

        File.WriteAllText(filePath, svgContent, Encoding.UTF8);
        Console.WriteLine($"SVG file created: {filePath}");
    }

    static string PromptForNonEmptyInput(string prompt, string errorMessage)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                Console.WriteLine(errorMessage);
        } while (string.IsNullOrWhiteSpace(input));

        return input;
    }

    static int PromptForPositiveInt(string prompt, string errorMessage)
    {
        int value;
        do
        {
            Console.Write(prompt);
            if (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
                Console.WriteLine(errorMessage);
        } while (value <= 0);

        return value;
    }
}
