using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SortierAlgorythmus
{
    internal class Algorythmus
    {
        #region Text
        string welcomeText = "Willkommen zum Sortieralgorythmus!";
        string continueText = "Bitte drücke eine Taste um fortzufahren";
        string PressKeyText = "Gib eine Zahl ein um sie der Liste hinzuzufügen.";
        string PressEText = "Drücke [E] um eine Zahl manuell einzugeben";
        string PressEnterText = "Drücke [Enter] wenn du mit der Liste zufrieden bist,";
        string PressSpaceText = "Drücke [Leertaste] um der Liste eine zufällige Zahl hinzuzufügen.";
        string ErrorText = "Die Liste muss mindestens zwei Zahlen beinhalten";
        string PressNumberText = "Gib eine Zahl für folgende Optionen:";
        string PressOneText = "1: Die Liste aufsteigend sortieren";
        string PressTwoText = "2: Die Liste absteigend sortieren";
        string PressThreeText = "3: Die Liste im Zick-Zack sortieren";
        string PressEscText = "Drücke [Esc] um das Spiel zu verlassen";
        #endregion
        Stopwatch s = new Stopwatch();
        bool runProgramm = true;
        int minRandomNumber = -1000;
        int maxRandomNumber = 1000;
        int newInt = 0;
        List<int> numbers = new List<int>();

        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine(welcomeText);
            Console.WriteLine(continueText);
            Console.ReadKey();
            Console.Clear();
            CreateList();
            Console.Clear();
            ShowList();
            SortListOption();
            Continue();
        }

        public void Continue()
        {
            Console.Clear();
            Console.WriteLine("Drücke [E] um eine neue Liste zu erstellen");
            Console.WriteLine("Drücke [Enter] um die Liste anders zu sortieren");
            Console.WriteLine();
            ShowList();
            Console.WriteLine();
            Console.WriteLine($"Das Sortieren hat {s.ElapsedMilliseconds}ms gedauert.");

            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.E:
                    numbers.Clear();
                    MainMenu();
                    break;
                case ConsoleKey.Enter:
                    SortListOption();
                    Continue();
                    break;
            }
        }
        public void ShowList()
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
        public void CreateList()
        {
            runProgramm = true;

            while (runProgramm)
            {
                Console.Clear();
                Console.WriteLine(PressEText);
                Console.WriteLine(PressSpaceText);
                Console.WriteLine(PressEnterText);
                Console.WriteLine();
                ShowList();

                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        break;
                    case ConsoleKey.Spacebar:
                        Random random = new Random();
                        newInt = random.Next(minRandomNumber, maxRandomNumber);
                        numbers.Add(newInt);
                        break;
                    case ConsoleKey.Enter:
                        if (numbers.Count < 2)
                        {
                            Console.WriteLine(ErrorText);
                            Console.WriteLine(continueText);
                            Console.ReadKey();
                        }
                        else
                        {
                            runProgramm = false;
                        }
                        break;
                    case ConsoleKey.E:
                        Console.Clear();
                        Console.WriteLine(PressKeyText);
                        bool tryParse = false;
                        while (!tryParse)
                        {
                            tryParse = int.TryParse(Console.ReadLine(), out newInt);
                        }
                        numbers.Add(newInt);
                        break;
                }
            }
        }
        public void SortListOption()
        {
            Console.Clear();
            ShowList();
            Console.WriteLine();
            Console.WriteLine("Wähle eine Sortiermöglichkeit");
            Console.WriteLine("1: Bubblesort");
            Console.WriteLine("2: Insertionsort");
            Console.WriteLine("3: Selectionsort");

            int key = 0;
            int.TryParse(Console.ReadLine(), out key);
            Console.Clear();

            switch (key)
            {
                case 1:
                    BubbleSort bubblesort = new BubbleSort(numbers);
                    SortOptionsBubbleSort(bubblesort);
                    break;

                case 2:
                    InsertionSort insertionsort = new InsertionSort(numbers);
                    SortOptionsInsertionSort(insertionsort);
                    break;

                case 3:
                    SelectionSort selectionSort = new SelectionSort(numbers);
                    SortOptionsSelectionSort(selectionSort);
                    break;
            }
        }
        public void SortOptionsBubbleSort(BubbleSort bubblesort)
        {
            Console.Clear();
            ShowList();
            Console.WriteLine();
            Console.WriteLine(PressNumberText);
            Console.WriteLine(PressOneText);
            Console.WriteLine(PressTwoText);
            Console.WriteLine(PressThreeText);

            int key = 0;
            int.TryParse(Console.ReadLine(), out key);
            Console.Clear();

            switch (key)
            {
                case 1:
                    s.Restart();
                    bubblesort.SortDown(numbers);
                    s.Stop();
                    break;

                case 2:
                    s.Restart();
                    bubblesort.SortUp(numbers);
                    s.Stop();
                    break;

                case 3:
                    s.Restart();
                    bubblesort.SortZickZack(numbers);
                    s.Stop();
                    break;
            }
        }
        public void SortOptionsInsertionSort(InsertionSort insertionsort)
        {
            Console.Clear();
            ShowList();
            Console.WriteLine();
            Console.WriteLine(PressNumberText);
            Console.WriteLine(PressOneText);
            Console.WriteLine(PressTwoText);
            Console.WriteLine(PressThreeText);

            int key = 0;
            int.TryParse(Console.ReadLine(), out key);
            Console.Clear();

            switch (key)
            {
                case 1:
                    s.Restart();
                    insertionsort.SortDown(numbers);
                    s.Stop();
                    break;

                case 2:
                    s.Restart();
                    insertionsort.SortUp(numbers);
                    s.Stop();
                    break;

                case 3:
                    s.Restart();
                    insertionsort.SortZickZack(numbers);
                    s.Stop();
                    break;
            }
        }
        public void SortOptionsSelectionSort(SelectionSort selectionsort)
        {
            Console.Clear();
            ShowList();
            Console.WriteLine();
            Console.WriteLine(PressNumberText);
            Console.WriteLine(PressOneText);
            Console.WriteLine(PressTwoText);
            Console.WriteLine(PressThreeText);

            int key = 0;
            int.TryParse(Console.ReadLine(), out key);
            Console.Clear();

            switch (key)
            {
                case 1:
                    s.Restart();
                    selectionsort.SortDown(numbers);
                    s.Stop();
                    break;

                case 2:
                    s.Restart();
                    selectionsort.SortUp(numbers);
                    s.Stop();
                    break;

                case 3:
                    s.Restart();
                    selectionsort.SortZickZack(numbers);
                    s.Stop();
                    break;
            }
        }
    }
}
