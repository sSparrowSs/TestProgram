using System;

class Program
{
    static void Main(string[] args)
    {
        string sentence = "Съешь ещё этих мягких французских булок, да выпей же чаю.";

        WordFinder wordFinder = new WordFinder();

        while (true)
        {
            Console.WriteLine("Введите слово для поиска (для выхода введите 'exit'):");
            string searchWord = Console.ReadLine();

            if (searchWord.ToLower() == "exit")
            {
                break;
            }

            bool wordFound = wordFinder.FindWord(sentence, searchWord);

            if (wordFound)
            {
                Console.WriteLine($"Слово '{searchWord}' найдено в предложении.\n");
            }
            else
            {
                Console.WriteLine($"Слово '{searchWord}' не найдено в предложении.\n");
            }
        }
    }
}

public class WordFinder
{
    public bool FindWord(string sentence, string searchWord)
    {
        string[] words = sentence.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            if (word.Equals(searchWord, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }
}
