using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Strings_task
{
    class Program
    {
        static int Menu()
        {
            Console.WriteLine("Input any key to continue the program...");
            Console.ReadKey();

            Console.Clear();

            Console.WriteLine("Menu: \n1.Input a string \n2.Show the string containig the most digits \n3.The longest word and number of its reiteration " +
            "\n4.Change numbers 1-9 to words one-nine \n5.Show interrogative and exclamative sentences \n6.Show sentences without commas \n7.Show words ending with the same letters \n8.Close the program ");

            int choice;

            do
            {
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    break;
                }
                else
                {
                    Console.Write("Error! Please retry your input: ");
                }

            } while (true);

            Console.Clear();

            return choice;
        }

        //This method show interogative sentences
        static void InterogativeSentences(string text)
        {
            int currentIndex = 0;

            int indexOfQuestion;
            int indexOfExclamation;
            int indexOfDot;

            int endSign = 0;

            string text1;

            while (true)
            {
                indexOfDot = text.IndexOf('.', currentIndex);
                indexOfExclamation = text.IndexOf('!', currentIndex);
                indexOfQuestion = text.IndexOf('?', currentIndex);

                //cycle break condition
                if ((indexOfDot == -1 && indexOfExclamation == -1 && indexOfQuestion == -1) || indexOfQuestion == -1) break;

                if (indexOfQuestion != -1)
                {
                    if (indexOfDot != -1 && indexOfExclamation != -1)
                    {
                        if (indexOfQuestion < indexOfExclamation && indexOfQuestion < indexOfDot)
                        {
                            endSign = indexOfQuestion;
                        }
                        else if (indexOfDot < indexOfExclamation)
                        {
                            currentIndex = indexOfDot + 1;
                        }
                        else
                        {
                            currentIndex = indexOfExclamation + 1;
                        }
                    }

                    else if (indexOfDot == -1)
                    {
                        if (indexOfQuestion < indexOfExclamation)
                        {
                            endSign = indexOfQuestion;
                        }
                        else
                        {
                            currentIndex = indexOfExclamation + 1;
                        }
                    }

                    else if (indexOfExclamation == -1)
                    {
                        if (indexOfQuestion < indexOfDot)
                        {
                            endSign = indexOfExclamation;
                        }
                        else
                        {
                            currentIndex = indexOfDot + 1;
                        }
                    }

                    else if (indexOfExclamation == -1 && indexOfDot == -1)
                    {
                        endSign = indexOfQuestion;
                    }

                    if (endSign != 0)
                    {
                        text1 = text.Substring(currentIndex, endSign - currentIndex + 1);

                        text1 = text1.Trim(' ');

                        Console.WriteLine(text1);

                        currentIndex = endSign + 1;
                    }
                }
            }
        }

        //This method show exclamative sentences
        static void ExclamativeSentences(string text)
        {
            int currentIndex = 0;

            //end sign indexes
            int indexOfQuestion;
            int indexOfExclamation;
            int indexOfDot;

            int endSign = 0;

            string text1;

            while(true)
            {
                indexOfDot = text.IndexOf('.', currentIndex);
                indexOfExclamation = text.IndexOf('!', currentIndex);
                indexOfQuestion = text.IndexOf('?', currentIndex);

                if ((indexOfDot == -1 && indexOfExclamation == -1 && indexOfQuestion == -1) || indexOfExclamation == -1) break;

                if (indexOfExclamation != -1)
                {
                    if (indexOfDot != -1 && indexOfQuestion != -1)
                    {
                        if (indexOfExclamation < indexOfQuestion && indexOfExclamation < indexOfDot)
                        {
                            endSign = indexOfExclamation;
                        }
                        else if (indexOfDot < indexOfQuestion)
                        {
                            currentIndex = indexOfDot + 1;
                        }
                        else
                        {
                            currentIndex = indexOfQuestion + 1;
                        }
                    }

                    else if (indexOfDot == -1)
                    {
                        if (indexOfExclamation < indexOfQuestion)
                        {
                            endSign = indexOfExclamation;
                        }
                        else
                        {
                            currentIndex = indexOfQuestion + 1;
                        }
                    }

                    else if (indexOfQuestion == -1)
                    {
                        if (indexOfExclamation < indexOfDot)
                        {
                            endSign = indexOfExclamation;
                        }
                        else
                        {
                            currentIndex = indexOfDot + 1;
                        }
                    }

                    else if (indexOfQuestion == -1 && indexOfDot == -1)
                    {
                        endSign = indexOfExclamation;
                    }

                    if (endSign != 0)
                    {
                        text1 = text.Substring(currentIndex, endSign - currentIndex + 1);

                        text1 = text1.Trim(' ');

                        Console.WriteLine(text1);

                        currentIndex = endSign + 1;
                    }
                }
            }
        }

        //This method show words which start and end with the same letter 
        static void StartAndEndWith(string text)
        {
            Console.WriteLine(text);

            Console.WriteLine("Words start with the same letter: ");

            string text1;

            int i = 0;

            while (true)
            {
                int index = text.IndexOf(' ', i);

                if (index == -1)
                {
                    if (text[i].Equals(text[text.Length - 1]))
                    {
                        text1 = text.Substring(i, text.Length - i);

                        Console.WriteLine(text1);
                    }

                    break;
                }
                else
                {
                    if (text[i].Equals(text[index - 1]))
                    {
                        text1 = text.Substring(i, index - i);

                        Console.WriteLine(text1);
                    }
                }

                i = index + 1;
            }
        }

        //This method show words containing the most digits
        static void MostDigits(string text)
        {
            string text1;

            int startOfWord;
            int currentIndex = 0;

            int length = text.Length;

            int MaxDiigits = 0;
            int counterOfDigits = 0;

            char currentSymbol;

            //searching for the words
            while (true)
            {
                int indexOfSpace = text.IndexOf(' ', currentIndex);

                if (indexOfSpace == -1)
                {
                    while (currentIndex < length)
                    {
                        currentSymbol = text[currentIndex];

                        if (Char.IsDigit(currentSymbol))
                        {
                            counterOfDigits++;
                        }

                        currentIndex++;
                    }

                    if (counterOfDigits > MaxDiigits)
                    {
                        MaxDiigits = counterOfDigits;
                    }
                }

                else
                {
                    while (currentIndex < indexOfSpace)
                    {
                        currentSymbol = text[currentIndex];

                        if (Char.IsDigit(currentSymbol))
                        {
                            counterOfDigits++;
                        }

                        currentIndex++;
                    }

                    if (counterOfDigits > MaxDiigits)
                    {
                        MaxDiigits = counterOfDigits;
                    }
                }

                counterOfDigits = 0;

                currentIndex = indexOfSpace + 1;

                if (currentIndex == 0) break;
            }

            currentIndex = 0;

            //showing the wrods
            while (currentIndex < length)
            {
                int indexOfSpace = text.IndexOf(' ', currentIndex);

                startOfWord = currentIndex;

                if (indexOfSpace == -1)
                {
                    while (currentIndex < length)
                    {
                        currentSymbol = text[currentIndex];

                        if (Char.IsDigit(currentSymbol))
                        {
                            counterOfDigits++;
                        }

                        currentIndex++;
                    }
                }
             
                else
                {
                    while (currentIndex < indexOfSpace)
                    {
                        currentSymbol = text[currentIndex];

                        if (Char.IsDigit(currentSymbol))
                        {
                            counterOfDigits++;
                        }

                        currentIndex++;
                    }
                }

                if (counterOfDigits == MaxDiigits)
                {
                    text1 = text.Substring(startOfWord, length - startOfWord);

                    Console.WriteLine(text1);
                }

                counterOfDigits = 0;

                currentIndex = indexOfSpace + 1;

                if (currentIndex == 0) break;
            }
        }

        //This method show words containing the most symbols
        static void WordsWithTheMostSymbols(string text)
        {
            int currentIndex = 0;
           
            int startOfWord;
            int indexOfSpace;

            int counterOfWordElements;
            int counterOfReiteration = 0;
            int maxSymbols = 0;

            string text1;

            int length = text.Length;

            text = text.Trim(' ');
          
            //searching for the words
            while (true)
            {
                startOfWord = currentIndex;

                indexOfSpace = text.IndexOf(' ', startOfWord);

                if (indexOfSpace == -1)
                {
                    counterOfWordElements = length - startOfWord;
                }

                else
                {
                    counterOfWordElements = indexOfSpace - startOfWord;
                }

                if (counterOfWordElements > maxSymbols)
                {
                    maxSymbols = counterOfWordElements;
                }

                currentIndex = indexOfSpace + 1;

                if (currentIndex == 0) break;
            }

            //showing the words
            while (true)
            {
                startOfWord = currentIndex;

                indexOfSpace = text.IndexOf(' ', startOfWord);

                if (indexOfSpace == -1)
                {
                    counterOfWordElements = length - startOfWord;
                }
                else
                {
                    counterOfWordElements = indexOfSpace - startOfWord;
                }

                if (counterOfWordElements == maxSymbols)
                {
                    text1 = text.Substring(startOfWord, counterOfWordElements);

                    counterOfReiteration++;

                    Console.Write($"{text1}\t");
                }

                currentIndex = indexOfSpace + 1;

                if (currentIndex == 0) break;
            }

            Console.WriteLine($"\nNumber of reitration: {counterOfReiteration}");
        }

        //This method change digits to words 
        static void ReplaceDigitsByWords(string text)
        {
            var sb = new StringBuilder();

            sb.Append(text);

            sb.Replace("1", " one ");

            sb.Replace("2", " two ");

            sb.Replace("3", " three ");

            sb.Replace("4", " four ");

            sb.Replace("5", " five ");

            sb.Replace("6", " six ");

            sb.Replace("7", " seven ");

            sb.Replace("8", " eight ");

            sb.Replace("9", " nine ");

            sb.Replace("0", " zero ");

            text = sb.ToString();

            Console.WriteLine(text);
        }

        //This method show sentences without commas
        static void SentencesWithoutCommas(string text)
        {
            string text1;

            int indexOfComma;
            int indexOfExclamation;
            int indexOfDot;
            int indexOfQuestion;

            int endSign = 0;

            int currentIndex = 0;

            Console.WriteLine(text);

            Console.WriteLine("\nSentences without commas:");

            while(true)
            {
                indexOfComma = text.IndexOf(',', currentIndex);
                indexOfDot = text.IndexOf('.', currentIndex);
                indexOfQuestion = text.IndexOf('?', currentIndex);
                indexOfExclamation = text.IndexOf('!', currentIndex);

                if (indexOfDot == -1 && indexOfQuestion == -1 && indexOfExclamation == -1)
                {
                    break;
                }
                else
                {
                    if(indexOfDot != -1)
                    {
                        if(indexOfExclamation != -1 && indexOfQuestion != -1)
                        {
                            if (indexOfDot < indexOfExclamation && indexOfDot < indexOfQuestion)
                            {
                                endSign = indexOfDot;
                            }
                        }

                        else if (indexOfQuestion == -1 && indexOfExclamation == -1)
                        {
                            endSign = indexOfDot;
                        }

                        else if(indexOfExclamation == -1)
                        {
                            if(indexOfDot < indexOfQuestion)
                            {
                                endSign = indexOfDot;
                            }
                        }

                        else if(indexOfQuestion == -1)
                        {
                            if(indexOfDot < indexOfExclamation)
                            {
                                endSign = indexOfDot;
                            }
                        }                      
                    }

                    if (indexOfExclamation != -1)
                    {
                        if (indexOfDot != -1 && indexOfQuestion != -1)
                        {
                            if (indexOfExclamation < indexOfDot && indexOfExclamation < indexOfQuestion)
                            {
                                endSign = indexOfExclamation;
                            }
                        }

                        else if (indexOfDot == -1 && indexOfQuestion == -1)
                        {
                            endSign = indexOfExclamation;
                        }

                        else if (indexOfDot == -1)
                        {
                            if (indexOfExclamation < indexOfQuestion)
                            {
                                endSign = indexOfExclamation;
                            }
                        }

                        else if (indexOfQuestion == -1)
                        {
                            if (indexOfExclamation < indexOfDot)
                            {
                                endSign = indexOfExclamation;
                            }
                        }
                    }

                    if (indexOfQuestion != -1)
                    {
                        if (indexOfDot != -1 && indexOfExclamation != -1)
                        {
                            if (indexOfQuestion < indexOfDot && indexOfQuestion < indexOfExclamation)
                            {
                                endSign = indexOfQuestion;
                            }
                        }

                        else if (indexOfExclamation == -1 && indexOfDot == -1)
                        {
                            endSign = indexOfQuestion;
                        }

                        else if (indexOfDot == -1)
                        {
                            if (indexOfQuestion < indexOfExclamation)
                            {
                                endSign = indexOfQuestion;
                            }
                        }

                        else if (indexOfExclamation == -1)
                        {
                            if (indexOfQuestion < indexOfDot)
                            {
                                endSign = indexOfQuestion;
                            }
                        }
                    }

                    if (indexOfComma < endSign && indexOfComma != -1)
                    {
                        currentIndex = endSign + 1;
                    }
                    else
                    {
                        text1 = text.Substring(currentIndex, endSign - currentIndex + 1);

                        text1 = text1.Trim(' ');

                        Console.WriteLine(text1);

                        currentIndex = endSign + 1;
                    }
                }
             
            }
        }

        //Through this method users can choose existing text or inpu their own
        static string StringInputVariation()
        {
            int choice;

            string text;

            Console.WriteLine("1 - Manual input \n2 - Existing text");

            do
            {
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice == 0) continue;

                    else break;
                }
                else
                {
                    Console.Write("Error! Please retry your input: ");
                }

            } while (true);

            switch(choice)
            {
                case 1:
                    {
                        Console.Write("\nInput a string: ");
                        text = Console.ReadLine();

                        break;
                    }
                case 2:
                    {
                        text = "My naked weapon is out. Quarrel, I will back thee. How? Turn thy back and run? Fear me not. No, marry. I fear thee! Let us take the law of our sides; let them.";

                        break;
                    }
                default:
                    {
                        Console.WriteLine("\nError! Unknown command!");

                        text = StringInputVariation();

                        break;
                    }
            }

            return text;
        }

        static void Main(string[] args)
        {
            string text = StringInputVariation();

             do
             {
                int choice = Menu();

                if (choice == 8) break;

                switch (choice)
                { 
                     case 1:
                         {
                            text = StringInputVariation();

                            break;
                         }

                    case 2:
                        {
                            MostDigits(text);

                            break;
                        }

                    case 3:
                        {
                            WordsWithTheMostSymbols(text);

                            break;
                        }
                
                    case 4:
                        {
                            ReplaceDigitsByWords(text);

                            break;
                        }
                    
                    case 5:
                        {
                            Console.WriteLine("Exclamative Sentences: ");
                            ExclamativeSentences(text);

                            Console.WriteLine("Interogative Sentences: ");
                            InterogativeSentences(text);

                            break;
                        }
                    
                    case 6:
                        {
                            SentencesWithoutCommas(text);

                            break;
                        }
                    
                    case 7:
                        {
                            StartAndEndWith(text);

                            break;
                        }
                    
                    default:
                        {
                            Console.Write("Unknown command! Please retry your input: ");

                            break;
                        }     
                }
             
             } while (true);
        }
    }
}