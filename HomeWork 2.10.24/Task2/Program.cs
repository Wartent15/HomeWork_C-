using System;
using System.Collections.Generic;

namespace MorseCodeTranslator
{
    class Program
    {
        // Словарь для перевода символов в азбуку Морзе
        private static readonly Dictionary<char, string> MorseCodeDictionary = new Dictionary<char, string>
        {
            {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."},
            {'F', "..-."}, {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"},
            {'K', "-.-"}, {'L', ".-.."}, {'M', "--"}, {'N', "-."}, {'O', "---"},
            {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
            {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"}, {'Y', "-.--"},
            {'Z', "--.."}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"},
            {'4', "....-"}, {'5', "....."}, {'6', "-...."}, {'7', "--..."},
            {'8', "---.."}, {'9', "----."}, {'0', "-----"}, {' ', "/"}
        };

        // Словарь для перевода азбуки Морзе в обычный текст
        private static readonly Dictionary<string, char> EnglishDictionary = new Dictionary<string, char>();

        static Program()
        {
            foreach (var pair in MorseCodeDictionary)
            {
                EnglishDictionary[pair.Value] = pair.Key;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст для перевода в азбуку Морзе:");
            string inputText = Console.ReadLine();
            string morseCode = TranslateToMorse(inputText.ToUpper());
            Console.WriteLine($"Азбука Морзе: {morseCode}");

            Console.WriteLine("Теперь введите текст на азбуке Морзе для перевода в обычный текст:");
            string morseInput = Console.ReadLine();
            string translatedText = TranslateFromMorse(morseInput);
            Console.WriteLine($"Обычный текст: {translatedText}");
        }

        private static string TranslateToMorse(string text)
        {
            var morseResult = string.Empty;

            foreach (var character in text)
            {
                if (MorseCodeDictionary.TryGetValue(character, out var morse))
                {
                    morseResult += morse + " ";
                }
            }

            return morseResult.Trim();
        }

        private static string TranslateFromMorse(string morse)
        {
            var textResult = string.Empty;
            var morseCharacters = morse.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var morseCharacter in morseCharacters)
            {
                if (EnglishDictionary.TryGetValue(morseCharacter, out var character))
                {
                    textResult += character;
                }
            }

            return textResult;
        }
    }
}