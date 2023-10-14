namespace ScriptureMemorization
{
    public class Scripture
    {
        // Properties
        public string Book { get; }
        public int Chapter { get;}
        public int StartingVerse { get; }
        public int EndingVerse { get; }
        public string Content { get; set;}
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

            RedactedWords = new Dictionary<string, bool>();
            foreach (var word in Words)
            {
                RedactedWords[word] = false;
            }
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
        public string FormatContent()
        {
            // Update Content based on the Words list.
            Content = string.Join(" ", Words);

            // Split the Content string into individual verses based on your separator.
            string[] verses = Content.Split('|');

            // Initialize an empty StringBuilder to hold the formatted content.
            System.Text.StringBuilder formattedContent = new System.Text.StringBuilder();

            // Loop through the verses and append verse numbers.
            for (int i = 0; i < verses.Length; i++)
            {
                // Calculate the current verse number based on StartingVerse.
                int currentVerseNumber = StartingVerse + i;

                // Append the verse number and the verse content to the StringBuilder.
                formattedContent.AppendLine($"{currentVerseNumber} {verses[i].Trim()}");
            }

            return formattedContent.ToString();
        }


    }
}