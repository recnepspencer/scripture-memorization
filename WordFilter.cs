using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorization
{
    // Class responsible for handling word redaction in a scripture text.
    public class WordFilter
    {
        private Random random;  // Random number generator for selecting words.
        private List<Word> mutableWords;  // List of words in the scripture text.
        public List<int> redactableIndices;  // Indices of words that can be redacted.

        // Constructor initializes the Random object.
        public WordFilter()
        {
            random = new Random();
        }

        // Initializes the mutableWords list based on provided scripture.
        public void InitializeMutableWords(Scripture scripture)
        {
            mutableWords = new List<Word>(scripture.FormatContent());  // Clone scripture words.
            // Populate the redactableIndices list with the indices of all mutableWords.
            redactableIndices = Enumerable.Range(0, mutableWords.Count).ToList();
        }

        // Redacts random words from the mutableWords list.
        public List<Word> RedactContent()
        {
            int numberOfWordsToRedact = 5;  // Number of words to redact.
            int redactedCount = 0;  // Counter for number of words redacted so far.

            // Loop until the desired number of words are redacted.
            while (redactedCount < numberOfWordsToRedact && redactableIndices.Count > 0)
            {
                // Select a random index from the list of indices that can be redacted.
                int randomIndexPosition = random.Next(0, redactableIndices.Count);
                int actualIndex = redactableIndices[randomIndexPosition];

                // Identify the word to redact based on the randomly selected index.
                Word wordToRedact = mutableWords[actualIndex];

                // Generate a string of underscores to replace the redacted word.
                int wordLength = wordToRedact.Content.Length;
                string underscoreReplacement = new string('_', wordLength);
                wordToRedact.Content = underscoreReplacement;

                // Remove the redacted index from the list of redactable indices.
                redactableIndices.RemoveAt(randomIndexPosition);

                redactedCount++;
            }

            // Return the redacted list of Word objects.
            return mutableWords;
        }
    }
}