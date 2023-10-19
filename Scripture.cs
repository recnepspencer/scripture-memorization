namespace ScriptureMemorization
{
    public class Word
    {
        public string Reference { get; set; }
        public int VerseNumber { get; set; }
        public string Content { get; set; }

        public Word(string reference, int verseNumber, string content)
        {
            Reference = reference;
            VerseNumber = verseNumber;
            Content = content;
        }
    }

    public class Scripture
    {
        // Properties
        public string Book { get; }
        public int Chapter { get; }
        public int StartingVerse { get; }
        public int EndingVerse { get; }
        public string Content { get; set; }
        public List<string> Words { get; set; }

        private static Random random = new Random();
        // Add a new property to your Scripture class
        public Dictionary<string, bool> RedactedWords { get; set; }

        // Constructor
        public Scripture(string book, int chapter, int startingVerse, int endingVerse, string content)
        {
            Book = book;
            Chapter = chapter;
            StartingVerse = startingVerse;
            EndingVerse = endingVerse;
            Content = content;
            Words = content.Split(' ').ToList();

        }

        public string ScriptureHeading()
        {
            if (StartingVerse == EndingVerse)
            {
                return $"Memorize this scripture from {Book} {Chapter}:{StartingVerse}";
            }
            else
            {
                return $"Memorize this scripture from {Book} {Chapter}:{StartingVerse}-{EndingVerse}";
            }
        }




        // Method to return formatted Scripture
        public List<Word> FormatContent()
        {
            // Update Content based on the Words list.
            Content = string.Join(" ", Words);

            // Split the Content string into individual verses based on your separator.
            string[] verses = Content.Split('|');

            // Initialize a list to hold Word objects.
            List<Word> formattedContent = new List<Word>();

            // Loop through the verses and append verse numbers.
            for (int i = 0; i < verses.Length; i++)
            {
                // Calculate the current verse number based on StartingVerse.
                int currentVerseNumber = StartingVerse + i;

                // Get the reference for the current verse.
                string reference = $"{Book} {Chapter}:{currentVerseNumber}";

                // Split each verse into words.
                string[] wordsInVerse = verses[i].Trim().Split(' ');

                // Create a Word object for each word and add it to the list.
                foreach (string word in wordsInVerse)
                {
                    formattedContent.Add(new Word(reference, currentVerseNumber, word));
                }
            }

            return formattedContent;
        }



    }
}