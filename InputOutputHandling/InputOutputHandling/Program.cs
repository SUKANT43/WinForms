using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InputOutputHandling
{
    class Program
    {
        static string filePath;

        static void Main(string[] args)
        {
            // Store file on Desktop
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filePath = Path.Combine(desktop, "ioFile.txt");

            while (true)
            {
                Console.WriteLine("\n--- WORD DATA CRUD ---");
                Console.WriteLine("1. Create (Add) Word");
                Console.WriteLine("2. Read (List) Words");
                Console.WriteLine("3. Update Word");
                Console.WriteLine("4. Delete Word");
                Console.WriteLine("5. Exit");
                Console.Write("Choose option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateWord();
                        break;
                    case "2":
                        ReadWords();
                        break;
                    case "3":
                        UpdateWord();
                        break;
                    case "4":
                        DeleteWord();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        // ---- CRUD METHODS ----

        static void CreateWord()
        {
            List<WordData> words = LoadAll();

            Console.Write("Enter new word: ");
            string content = Console.ReadLine();

            // Simple ID: W1, W2, W3...
            string newId = "W" + (words.Count + 1);

            words.Add(new WordData(content, newId));
            SaveAll(words);

            Console.WriteLine("Word added with ID: " + newId);
        }

        static void ReadWords()
        {
            List<WordData> words = LoadAll();

            if (words.Count == 0)
            {
                Console.WriteLine("No data found.");
                return;
            }

            Console.WriteLine("\n--- ALL WORDS ---");
            foreach (var w in words)
            {
                Console.WriteLine($"ID: {w.Id} | Word: {w.Content}");
            }
        }

        static void UpdateWord()
        {
            List<WordData> words = LoadAll();

            Console.Write("Enter ID to update (e.g., W1): ");
            string id = Console.ReadLine();

            var word = words.FirstOrDefault(w => w.Id == id);
            if (word == null)
            {
                Console.WriteLine("ID not found.");
                return;
            }

            Console.Write("Enter new content: ");
            string newContent = Console.ReadLine();

            word.Content = newContent;
            SaveAll(words);

            Console.WriteLine("Word updated.");
        }

        static void DeleteWord()
        {
            List<WordData> words = LoadAll();

            Console.Write("Enter ID to delete (e.g., W1): ");
            string id = Console.ReadLine();

            var word = words.FirstOrDefault(w => w.Id == id);
            if (word == null)
            {
                Console.WriteLine("ID not found.");
                return;
            }

            words.Remove(word);
            SaveAll(words);

            Console.WriteLine("Word deleted.");
        }

        // ---- FILE HELPERS ----

        static List<WordData> LoadAll()
        {
            List<WordData> list = new List<WordData>();

            if (!File.Exists(filePath))
                return list;

            foreach (var line in File.ReadAllLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    list.Add(new WordData(parts[1], parts[0]));
                }
            }

            return list;
        }

        static void SaveAll(List<WordData> words)
        {
            var lines = words.Select(w => $"{w.Id}|{w.Content}");
            File.WriteAllLines(filePath, lines);
        }
    }

    class WordData
    {
        public string Content;
        public string Id;

        public WordData(string c, string id)
        {
            Content = c;
            Id = id;
        }
    }
}
