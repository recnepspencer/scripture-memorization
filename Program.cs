using System;
using System.Collections.Generic;

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
            DisplayFormattedWords(randomScripture.FormatContent());

            // Ask if the user wants to continue
            Console.WriteLine("Do you want to continue? (press enter or type no)");
            string userChoice = Console.ReadLine().ToLower();

            // Main loop for memorization
            bool isRedacting = true;
            while (isRedacting)
            {
                Console.Clear();
                List<Word> redactedWords = wordFilter.RedactContent();

                // Display the updated content
                Console.WriteLine($"Here is the updated content: {randomScripture.ScriptureHeading()}");
                DisplayFormattedWords(redactedWords);

                // Ask if the user wants to continue
                Console.WriteLine("Do you want to continue? (press enter or type /no)");
                userChoice = Console.ReadLine();

                // If the user types no or there are no more words to redact, exit the loop.
                if (userChoice.ToLower() == "no" || wordFilter.redactableIndices.Count == 0)
                {
                    isRedacting = false;
                }
            }

            Console.WriteLine("Good job on your scripture memorization practice!");
        }

        // Display method for Word objects
        static void DisplayFormattedWords(List<Word> words)
        {
            if (words.Count == 0) return;

            string currentReference = words[0].Reference;
            int currentVerseNumber = words[0].VerseNumber;

            Console.Write($"{currentVerseNumber} ");

            foreach (var word in words)
            {
                if (currentVerseNumber != word.VerseNumber)
                {
                    Console.WriteLine();  // Start a new line for a new verse
                    currentVerseNumber = word.VerseNumber;
                    Console.Write($"{word.VerseNumber} ");
                }
                Console.Write($"{word.Content} ");
            }
            Console.WriteLine();
        }
    }
}
