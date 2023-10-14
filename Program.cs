using System;

namespace ScriptureMemorization
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize a new ScriptureCollection and WordFilter
            ScriptureCollection scriptureCollection = new ScriptureCollection();
            WordFilter wordFilter = new WordFilter();

            // Get a random scripture
            Scripture randomScripture = scriptureCollection.GetRandomScripture();
            wordFilter.InitializeMutableWords(randomScripture);

            // Print the original content
            Console.WriteLine($"Memorize this scripture from {randomScripture.ScriptureHeading()}");
            Console.WriteLine(randomScripture.FormatContent());

            // Ask if the user wants to continue
            Console.WriteLine("Do you want to continue? (press enter or type no)");
            string userChoice = Console.ReadLine().ToLower();

            // Main loop for memorization
            while (userChoice == "")
            {
                Console.Clear();
                string redactedContent = wordFilter.RedactContent();

                // Display the updated content
                Console.WriteLine("Here is the updated content:");
                Console.WriteLine(redactedContent);

                // Ask if the user wants to continue
                Console.WriteLine("Do you want to continue? (yes/no)");
                userChoice = Console.ReadLine();
            }

            Console.WriteLine("Good job on your scripture memorization practice!");
        }
    }
}
