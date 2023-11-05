using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorythmus
{
    internal class InsertionSort
    {
        //Lege eine Liste an
        List<int> numbers = new List<int>();
        //Erzeuge eine Instanz der Klasse mit der Liste
        public InsertionSort(List<int> numbers)
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
            //Speicher die aktuelle Zahl
            for (int i = 1; i < numbers.Count; i++)
            {
                int tempVar = numbers[i];
                int j = i;

                //Verschiebe die Zahl nach hinten, solange die vorherige Zahl größer ist
                while(j > 0 && numbers[j-1] > tempVar)
                {
                    numbers[j] = numbers[j - 1];
                    j--;
                }
                numbers[j] = tempVar;
            }
            return numbers;
        }
        //Sortiere die Liste absteigend und gib sie zurück
        public List<int> SortDown(List<int> numbers)
        {
            //Speicher die aktuelle Zahl
            for (int i = 1; i < numbers.Count; i++)
            {
                int tempVar = numbers[i];
                int j = i;

                //Verschiebe die Zahl nach hinten, solange die vorherige Zahl kleiner ist
                while (j > 0 && numbers[j - 1] < tempVar)
                {
                    numbers[j] = numbers[j - 1];
                    j--;
                }
                numbers[j] = tempVar;
            }
            return numbers;
        }
        //Sortier die Liste im Zick Zack und gib sie zurück
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

