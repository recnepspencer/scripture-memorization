namespace ScriptureMemorization
{
    // Class responsible for handling word redaction in a scripture text.
    public class WordFilter
    {
        private Random random;  // Random number generator for selecting words.
        private List<string> mutableWords;  // List of words in the scripture text.
        private List<int> redactableIndices;  // Indices of words that can be redacted.

        // Constructor initializes the Random object.
        public WordFilter()
        {
            random = new Random();
        }

        // Initializes the mutableWords list based on provided scripture.
        public void InitializeMutableWords(Scripture scripture)
        {
            mutableWords = new List<string>(scripture.Words);  // Clone scripture words.
            // Populate the redactableIndices list with the indices of all mutableWords.
            redactableIndices = Enumerable.Range(0, mutableWords.Count).ToList();
        }

        // Redacts random words from the mutableWords list.
        public string RedactContent()
        {
            int numberOfWordsToRedact = 5;  // Number of words to redact.
            int redactedCount = 0;  // Counter for number of words redacted so far.

            // Loop until the desired number of words are redacted.
            while (redactedCount < numberOfWordsToRedact && redactableIndices.Count > 0)
            {
                // Select a random index from the list of indices that can be redacted.
                int randomIndexPosition = random.Next(0, redactableIndices.Count);
                int actualIndex = redactableIndices[randomIndexPosition];

                // Debug output to trace the chosen index.
                Console.WriteLine($"Selected index position: {randomIndexPosition}, actual index: {actualIndex}");

                // Identify the word to redact based on the randomly selected index.
                string wordToRedact = mutableWords[actualIndex];

                // Generate a string of underscores to replace the redacted word.
                int wordLength = wordToRedact.Length;
                string underscoreReplacement = new string('_', wordLength);
                mutableWords[actualIndex] = underscoreReplacement;

                // Remove the redacted index from the list of redactable indices.
                redactableIndices.RemoveAt(randomIndexPosition);

                // Debug output to trace the remaining indices.
                Console.WriteLine($"After: {string.Join(", ", redactableIndices)}");

                redactedCount++;
            }

            // Return the redacted text as a string.
            return string.Join(" ", mutableWords);
        }
    }
}
