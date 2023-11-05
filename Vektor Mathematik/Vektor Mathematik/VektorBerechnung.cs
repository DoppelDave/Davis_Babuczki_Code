using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektor_Mathematik
{
    class VektorBerechnung
    {
        #region Variablen
        string welcomeText = "Willkommen zur Vektor-Mathematik!";
        string continueText = "Bitte drücke [Enter] um fortzufahren";
        string createText = "Wir beginnen mit der Erstellung eines Vektors. Dieser besteht aus 3 Werten.";
        string createText2 = "Wir erstellen nun den zweiten Vektor. Schon aufgeregt?";
        string createTextX = "Gib den ersten Wert(X) ein.(-10 bis 10)";
        string createTextY = "Gib den zweiten Wert(Y) ein. (-10 bis 10)";
        string createTextZ = "Gib den dritten Wert(Z) ein. (-10 bis 10)";
        string showText = "Gut gemacht. Hier siehst du deinen ersten Vektor:";
        string showText2 = "Hier siehst du deine beiden Vektoren: ";
        string askAction = "Was möchtest du tun? Drücke eine Zahl um dir was auszusuchen";
        string doAdditionText = "1: Vektoraddition";
        string doSubtractionText = "2: Vektorsubtraktion";
        string doMultiplikationText = "3: Skalare Multiplikation";
        string askForSkalarText = "Bitte gib den Skalar ein:";
        string doLengthBetweenText = "4: Die Länge zwischen beiden Vektoren ausgeben.";
        string doLengthBetweenTextStatic = "5: Die Länge zwischen beiden Vektoren ausgeben(Statisch)";
        string doLengthText = "6: Länge des ersten Vektors ausgeben";
        string doSquareLengthText = "7: Quadratlänge des ersten Vektors ausgeben";
        string errorText = "Bitte halte dich an die Anweisungen!";
        string additionText = "Es wurden beide Vektoren miteinander addiert.";
        string subtractionText = "Es wurde Vektor 2 von Vektor 1 subtrahiert";
        
        string resultText = "Hier ist das Ergebnis:";
        string endText = "Drücke [Esc] um das Programm zu beenden.\n Drücke [Enter] um mit deinen erstellten Vektoren etwas anderes zu machen.\n Drücke [Leertaste] um neue Vektoren zu erstellen.";
        float minValue = -10f;
        float maxValue = +10f;
        float x;
        float y;
        float z;

        Vector Vector1 = null;       
        Vector Vector2 = null;
        Vector ResultVec = null;
        float result;
        #endregion

        public void MainMenu()
        {
            Start();
            Loop();
            Continue(Vector1,Vector2);
            
        }
        public void Start()
        {
            Console.Clear();
            Console.WriteLine(welcomeText);
            Console.WriteLine(continueText);
            Console.ReadKey();
            Console.Clear();                    
        }
        public void Loop()
        {
            Console.Clear();
            Console.WriteLine(createText);
            CreateVektor();

            Vector1 = new Vector(x, y, z);

            Console.WriteLine(showText);

            Vector1.ShowVector();

            Console.WriteLine(continueText);
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(createText2);
            CreateVektor();

            Vector2 = new Vector(x, y, z);
                   
        }
        public void Continue(Vector Vector1, Vector Vector2)
        {
            Console.Clear();
            Console.WriteLine(showText2);

            Vector1.ShowVector();
            Console.WriteLine();
            Vector2.ShowVector();

            Console.WriteLine();
            Console.WriteLine(askAction);
            Console.WriteLine(doAdditionText);
            Console.WriteLine(doSubtractionText);
            Console.WriteLine(doMultiplikationText);
            Console.WriteLine(doLengthBetweenText);
            Console.WriteLine(doLengthBetweenTextStatic);
            Console.WriteLine(doLengthText);
            Console.WriteLine(doSquareLengthText);

            int output;
            int.TryParse(Console.ReadLine(), out output);

            switch (output)
            {
                //Addition
                case 1:
                    {
                        Vector resultVek = new Vector(0, 0, 0);
                        resultVek = Vector1 + Vector2;                       
                        Console.Clear();
                        Console.WriteLine(showText2);
                        Console.WriteLine();
                        Vector1.ShowVector();
                        Console.WriteLine();
                        Vector2.ShowVector();
                        Console.WriteLine();
                        Console.WriteLine(additionText);
                        Console.WriteLine(resultText);
                        Console.WriteLine();                       
                        resultVek.ShowVector();
                        Console.WriteLine();
                        Console.WriteLine(continueText);
                        Console.ReadLine();
                    }
                    break;
                //Subtraktion
                case 2:
                    {
                        Vector resultVek = new Vector(0, 0, 0);
                        resultVek = Vector1 - Vector2;
                        Console.Clear();
                        Console.WriteLine(showText2);
                        Console.WriteLine();
                        Vector1.ShowVector();
                        Console.WriteLine();
                        Vector2.ShowVector();
                        Console.WriteLine();
                        Console.WriteLine(subtractionText);
                        Console.WriteLine(resultText);
                        Console.WriteLine();
                        resultVek.ShowVector();
                        Console.WriteLine();
                        Console.WriteLine(continueText);
                        Console.ReadLine();
                    }
                    break;
                //Multiplikation mit Skalar
                case 3:
                    {
                        Console.WriteLine(askForSkalarText);
                        int skalar;
                        int.TryParse(Console.ReadLine(), out skalar);
                        Vector resultVek = new Vector(0, 0, 0);
                        resultVek = Vector1 * skalar;
                        Console.Clear();
                        Console.WriteLine(showText);
                        Console.WriteLine();
                        Vector1.ShowVector();                       
                        Console.WriteLine();
                        Console.WriteLine($"Dein Vektor wurde mit {skalar} multipliziert");
                        Console.WriteLine();
                        Console.WriteLine(resultText);
                        Console.WriteLine();
                        resultVek.ShowVector();
                        Console.WriteLine();
                        Console.WriteLine(continueText);
                        Console.ReadLine();
                    }
                    break;
                //Länge zwischen 2 Vektoren
                case 4:
                    {
                        result = Vector1.Distance(Vector2);
                        Console.Clear();
                        Console.WriteLine();
                        Vector1.ShowVector();
                        Console.WriteLine();
                        Vector2.ShowVector();
                        Console.WriteLine();
                        Console.WriteLine($"Die Länge zwischen den Vektoren ist {result}.");
                        Console.WriteLine();
                        Console.WriteLine(continueText);
                        Console.ReadLine();
                    }
                    break;
                //Länge zwischen 2 Vektoren (Statisch)
                case 5:
                    {
                        result = Vector.DistanceStatic(Vector1, Vector2);
                        Console.Clear();
                        Console.WriteLine();
                        Vector1.ShowVector();
                        Console.WriteLine();
                        Vector2.ShowVector();
                        Console.WriteLine();
                        Console.WriteLine($"Die Länge zwischen den Vektoren ist {result}.");
                        Console.WriteLine();
                        Console.WriteLine(continueText);
                        Console.ReadLine();
                    }
                    break;
                    
                //Länge eines Vektors berechnen
                case 6:
                    {
                        result = Vector1.Length();
                        Console.Clear();
                        Console.WriteLine();
                        Vector1.ShowVector();
                        Console.WriteLine();
                        Console.WriteLine($"Die Länge des Vektors ist {result}.");
                        Console.WriteLine();
                        Console.WriteLine(continueText);
                        Console.ReadLine();
                    }
                    break;
                //Quadratlänge eines Vektors berechnen
                case 7:
                    {
                        
                        result = Vector1.SquareLength();
                        Console.Clear();
                        Console.WriteLine();
                        Vector1.ShowVector();
                        Console.WriteLine();
                        Console.WriteLine($"Die Quadratlänge des Vektors ist {result}.");
                        Console.WriteLine();
                        Console.WriteLine(continueText);
                        Console.ReadLine();                       
                    }
                    break;

                    
            }

            End();
        }
        public void CreateVektor()
        {           
            Console.WriteLine(createTextX);

            bool tryParse = false;
            while (!tryParse)
            {
                tryParse = float.TryParse(Console.ReadLine(), out x);
                if (x < minValue || x > maxValue || !tryParse)
                {
                    Console.Clear();
                    Console.WriteLine(createTextX);
                    Console.WriteLine(errorText);
                    tryParse = false;
                }
            }

            Console.Clear();
            Console.WriteLine(createTextY);

            tryParse = false;
            while (!tryParse)
            {
                tryParse = float.TryParse(Console.ReadLine(), out y);
                if (y < minValue || y > maxValue || !tryParse)
                {
                    Console.Clear();
                    Console.WriteLine(createTextY);
                    Console.WriteLine(errorText);
                    tryParse = false;
                }
            }

            Console.Clear();
            Console.WriteLine(createTextZ);

            tryParse = false;
            while (!tryParse)
            {
                tryParse = float.TryParse(Console.ReadLine(), out z);
                if (z < minValue || z > maxValue || !tryParse)
                {
                    Console.Clear();
                    Console.WriteLine(createTextZ);
                    Console.WriteLine(errorText);
                    tryParse = false;
                }
            }

            Console.Clear();
        }
        public void End()
        {
            Console.Clear();
            Console.WriteLine(endText);

            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    {

                    }
                    break;
                case ConsoleKey.Enter:
                    {
                        Continue(Vector1, Vector2);
                    }
                    break;
                case ConsoleKey.Spacebar:
                    {
                        MainMenu();
                    }
                    break;
            }
        }
    }
}
