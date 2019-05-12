using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
   public class WordFile : MyFile , IWordCounter
    {
        public override void PrintFile()
        {
            string[] Allwords = AllFileText.Split(' ');
            foreach (string word in Allwords)
            {
                Console.WriteLine(word);
            }
        }
        Dictionary<string, int> words = new Dictionary<string, int>();

        public string AllFileText { get; set; }

        public WordFile(string text, string filePath, int fileSize, bool isReadOnly, bool IsArchive) : base(filePath, fileSize, isReadOnly,IsArchive)
        {
            AllFileText = text;
            int value;
            string[]Allwords = AllFileText.Split(' ');
            foreach (string word in Allwords)
            {
                words.TryGetValue(word, out value);
                if (value == 0)
                {
                    words.Add(word, 1);
                }
                else
                {
                    value++;
                    words[word] = value;
                }
                value = 0;
            }
        }

        //IWordCounter implement
       public int NumberOfWords
        {
            get
            {
                string[] Allwords = AllFileText.Split(' ');
                return Allwords.Length;
            }
        }
       public string this[int index]
        {
            get
            {
                string[] Allwords = AllFileText.Split(' ');
                return Allwords[index];
            }
        }
       public int NumberOfPages
        {
            get
            {
                return (NumberOfWords / 10);
            }
        } 
    }



}
