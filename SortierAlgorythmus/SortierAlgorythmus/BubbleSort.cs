using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorythmus
{
    internal class BubbleSort
    {
        //Leg eine Liste an
        List<int> numbers = new List<int>();
        //Erzeuge eine Instanz der Klasse mit der Liste
        public BubbleSort(List<int> numbers)
        {
            this.numbers = numbers;
        }
        //Zeige die Liste an
        public void ShowList(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }       
        //Sortiere die Liste aufsteigend und gib sie zurück
        public List<int> SortUp(List<int> numbers)
        {
            //Vergleiche jede Zahl mit der nachfolgenden Zahl und vertausche sie, falls sie größer ist 
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < numbers.Count - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        var tempVar = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = tempVar;
                    }
                }
            } return numbers;
        }
        //Sortiere die Liste absteigend und gib sie zurück
        public List<int> SortDown(List<int> numbers)
        {
            //Vergleiche jede Zahl mit der nachfolgenden Zahl und vertausche sie, falls sie kleiner ist
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < numbers.Count - i - 1; j++)
                {
                    if (numbers[j] < numbers[j + 1])
                    {
                        var tempVar = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = tempVar;
                    }
                }
            }
            return numbers;
        }
        //Sortiere die Liste im Zick-Zack und gib sie zurück
        public List<int> SortZickZack(List<int> numbers)
        {
            numbers = SortUp(numbers);

            List<int> tempNumbers = new List<int>(numbers.Count);

            int numbersIndex = 0;


            for (int i = 0, j = numbers.Count - 1; i <= numbers.Count / 2 || j > numbers.Count / 2; i++, j--)
            {
                if (numbersIndex < numbers.Count)
                {
                    tempNumbers.Add(numbers[j]);
                    numbersIndex++;
                }
                if (numbersIndex < numbers.Count)
                {
                    tempNumbers.Add(numbers[i]);
                    numbersIndex++;
                }

            }
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] = tempNumbers[i];
            }
            return numbers;
        }

    }
}
