using System;

class Program
{
    static void Main(string[] args)
    {
        string sentence = "Съешь ещё этих мягких французских булок, да выпей же чаю.";

        WordFinder wordFinder = new WordFinder();
        TextStatistics textStatistics = new TextStatistics();

        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Поиск слова");
            Console.WriteLine("2. Получение статистики текста");
            Console.WriteLine("3. Выход\n");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Введите слово для поиска:");
                    string searchWord = Console.ReadLine();
                    bool wordFound = wordFinder.FindWord(sentence, searchWord);
                    if (wordFound)
                    {
                        Console.WriteLine($"Слово '{searchWord}' найдено в предложении.\n");
                    }
                    else
                    {
                        Console.WriteLine($"Слово '{searchWord}' не найдено в предложении.\n");
                    }
                    break;
                case "2":
                    Console.WriteLine($"Количество слов: {textStatistics.CountWords(sentence)}");
                    Console.WriteLine($"Количество символов: {textStatistics.CountCharacters(sentence)}");
                    Console.WriteLine($"Количество предложений: {textStatistics.CountSentences(sentence)}");
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                    break;
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

public class TextStatistics
{
    public int CountWords(string text)
    {
        return text.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public int CountCharacters(string text)
    {
        return text.Length;
    }

    public int CountSentences(string text)
    {
        string[] sentences = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        return sentences.Length;
    }
}
