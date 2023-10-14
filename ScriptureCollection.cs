using System;
using System.Collections.Generic;
namespace ScriptureMemorization
{
    public class ScriptureCollection
    {
        // List to hold Scripture objects
        private List<Scripture> Scriptures { get; set; }

        private Random random = new Random();


        // Constructor
        public ScriptureCollection()
        {
            // List of Scripture objects
            Scriptures = new List<Scripture>
        {
            new Scripture("2 Nephi", 9, 28, 29, "O that cunning plan of the evil one! O the vainness, and the frailties, and the foolishness of men! When they are learned they think they are wise, and they hearken not unto the counsel of God, for they set it aside, supposing they know of themselves, wherefore, their wisdom is foolishness and it profiteth them not. And they shall perish. | But to be learned is good if they hearken unto the counsels of God."),
            new Scripture("1 Nephi", 3, 7, 7, "I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.")
        };
        }

        // Method to get a random Scripture object for memorization
        public Scripture GetRandomScripture()
        {
            int randomIndex = random.Next(0, Scriptures.Count);
            return Scriptures[randomIndex];

        }
    }
}