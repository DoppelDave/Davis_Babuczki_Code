using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorythmus
{
    internal class SelectionSort
    {
        //Lege eine Liste an
        List<int> numbers = new List<int>();
        //Erzeuge eine Instanz der Klasse mit der Liste
        public SelectionSort(List<int> numbers)
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
            //Such nach der kleinsten Zahl und setzte sie nach vorne
            for (int i = 0; i < numbers.Count; i++)
            {
                int smallest = i;
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[j] < numbers[smallest])
                    {
                        smallest = j;
                    }
                }
                var temp = numbers[smallest];
                temp = numbers[smallest];
                numbers[smallest] = numbers[i];
                numbers[i] = temp;
            }
            return numbers;
        }
        //Sortiere die Liste absteigend und gib sie zurück
        public List<int> SortDown(List<int> numbers)
        {
            //Such nach der größten Zahl und setzte sie nach vorne
            for (int i = 0; i < numbers.Count; i++)
            {
                int biggest = i;
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[j] > numbers[biggest])
                    {
                        biggest = j;
                    }
                }
                var temp = numbers[biggest];
                temp = numbers[biggest];
                numbers[biggest] = numbers[i];
                numbers[i] = temp;
            }
            return numbers;
        }
        //Sortier die Liste im Zick Zack und gib sie zurück
        public List<int> SortZickZack(List<int> numbers)
        {           
            int temp;

            for (int i = 0; i < numbers.Count; i++)
            {
                int minMaxIndex = i;

                for (int j = i + 1; j < numbers.Count; j++)
                {   
                    //Suche abwechselt nach der größten und der kleinsten Zahl
                    if (i % 2 == 0)
                    {
                        if (numbers[j] > numbers[minMaxIndex])
                        {
                            minMaxIndex = j;
                        }
                    }
                    else
                    {
                        if (numbers[j] < numbers[minMaxIndex])
                        {
                            minMaxIndex = j;
                        }
                    }
                }

                //Setzte sie nach vorne
                temp = numbers[i];
                numbers[i] = numbers[minMaxIndex];
                numbers[minMaxIndex] = temp;             
            }
            return numbers;
        }
    }
}

