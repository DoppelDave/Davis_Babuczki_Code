using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using static new_MonsterkampfSimulator.Monster;

namespace new_MonsterkampfSimulator
{
    class Game
    {
        bool goblinSelected = false;
        bool orkSelected = false;
        bool trollSelected = false;
        bool itemsOn = false;

        string race = null;
        float hp;
        float ap;
        float dp;
        float attackSpeed;

        int roundCounter;


        #region textStrings
        string healthValue = "Gib den Wert der Lebenspunkte ein(HP)\nGib bitte eine Zahl von 10-100 ein.";
        string attackPointsValue = "Gib die Angriffsstärke ein(AP)\nGib bitte eine Zahl von 10-20 ein.";
        string defensePointsValue = "Gib die Verteidigungsstärke ein(DP)\nGib bitte eine Zahl von 1-9 ein";
        string attackSpeedValue = "Gib die Angriffsgeschwindigkeit ein(AS)\nGib bitte eine Zahl von 1-10 ein";
        string anotherMonster = "Es können keine zwei gleichen Monster gegeneinander antreten. Drücke eine Taste um es erneut zu versuchen";
        string welcomeText = "Herzlich Willkommen zum Monsterkampf-Simulator";        
        string pickMonsterText = "Bitte wähle dein Monster aus!";
        string continueText = "Drücke eine Taste um fortzufahren.";
        string backToMenuText = "Drücke eine Taste um zurück zum Menü zu gelangen";
        string buttonInstruction = "[Drücke Leertaste] um eine Runde zu simulieren. Drücke [Enter] um den Kampf zu überspringen";
        string itemsOnText = "Wähle eine Zahl um auszusuchen:\n 1: Spiel mit Items\n 2: Spiel ohne Items";
        string gameModeText = "Wähle einen Spielmodus aus.\n 1: Wähle Rasse und Attribute der Monster selber.\n 2: Lasse zwei zufällige Monster gegeneinander antreten.";
        string errorText = "Bitte überprüfe deine Eingabe";

            
        string RoundText
        {
            get { return $"Der Kampf hat {roundCounter} Runden gedauert"; }
        }   
        #endregion 
                           

        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine(welcomeText);
            Console.WriteLine(continueText);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(itemsOnText);

            //Itemoption
            bool didDoValidInput = false;
            int output = 0;

            while (!didDoValidInput)
            {
                didDoValidInput = int.TryParse(Console.ReadLine(), out output);
                if (output > 2 || output < 1)
                {
                    didDoValidInput = false;
                    Console.Clear();
                    Console.WriteLine(itemsOnText);
                    Console.WriteLine(errorText);
                }
            }

            switch (output)
            {
                case 1:
                    itemsOn = true;
                    break;
                case 2:
                    itemsOn = false;
                    break;
            }

            //Spielmodus auswählen

            Console.Clear();
            Console.WriteLine(gameModeText);
            didDoValidInput = false;
            output = 0;

            while (!didDoValidInput)
            {
                didDoValidInput = int.TryParse(Console.ReadLine(), out output);
                if (output > 2 || output < 1)
                {
                    didDoValidInput = false;
                    Console.Clear();
                    Console.WriteLine(gameModeText);
                    Console.WriteLine(errorText);
                }
            }           

            switch (output)
            {
                case 1:
                    CreateMonster();
                    break;
                case 2:
                    CreateRandomMonster();
                    break;
            }            
        }

        public void CreateMonster()
        {
            Console.Clear();
            //Setzte die Rassen zurück
            ResetValues();
            //Monster auswählen
            SelectRace();
            //Werte eingeben
            InputValues();
            //Monster erstellen
            Monster Monster1 = new Monster(race, hp, ap, dp, attackSpeed);
            Console.Clear();
            SelectRace();
            InputValues();

            Monster Monster2 = new Monster(race, hp, ap, dp, attackSpeed);
            //Kampf beginnen
            Fight(Monster1, Monster2);
            Console.WriteLine(backToMenuText);
            Console.ReadKey(true);
            MainMenu();
        }

        public void CreateRandomMonster()
        {
            GetRandomValues();
            Monster Monster1 = new Monster(race, hp, ap, dp, attackSpeed);

            GetRandomValues();
            Monster Monster2 = new Monster(race, hp, ap, dp, attackSpeed);

            Fight(Monster1, Monster2);
        }

        public void SelectRace()
        {
            bool didDoValidInput = false;
            int output = 0;

            //Monster auswählen
            while (!didDoValidInput)
            {
                Console.Clear();
                Console.WriteLine(pickMonsterText);

                //Gewähltes Monster rot anzeigen
                if (goblinSelected)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("1:Goblin");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("2:Ork");
                    Console.WriteLine("3:Troll");
                } 
                else if (orkSelected)
                {
                    Console.WriteLine("1:Goblin");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("2:Ork");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("3:Troll");
                }
                else if (trollSelected)
                {
                    Console.WriteLine("1:Goblin");
                    Console.WriteLine("2:Ork");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("3:Troll");
                    Console.ForegroundColor = ConsoleColor.White;
                } 
                else
                {
                    Console.WriteLine("1:Goblin");
                    Console.WriteLine("2:Ork");
                    Console.WriteLine("3:Troll");
                }
                //Monster nicht doppelt wählen
                didDoValidInput = int.TryParse(Console.ReadLine(), out output);
                if (output > 3 || output < 1)
                {
                    didDoValidInput = false;                    
                }
                else if (goblinSelected && output == 1)
                {
                    didDoValidInput = false;
                    Console.WriteLine(anotherMonster);
                    Console.ReadKey();
                }
                else if (orkSelected && output == 2)
                {
                    didDoValidInput = false;
                    Console.WriteLine(anotherMonster);
                    Console.ReadKey();
                }
                else if (trollSelected && output == 3)
                {
                    didDoValidInput = false;
                    Console.WriteLine(anotherMonster);
                    Console.ReadKey();
                }
            }

            //Rasse setzen
            switch (output)
            {
                case 1:                                        
                    {
                        race = "Goblin";
                        goblinSelected = true;
                    }
                    break;
                case 2:                    
                    {
                        race = "Ork";
                        orkSelected = true;
                    }
                    break;
                case 3:                   
                    {
                        race = "Troll";
                        trollSelected = true;
                    }
                    break;
            }
        }

        public void InputValues()
        {
            //HP deklarieren
            bool tryParseHP = false;
            while (!tryParseHP)
            {
                Console.Clear();
                Console.WriteLine(healthValue);
                tryParseHP = float.TryParse(Console.ReadLine(), out hp);
                if(hp < 10 || hp > 100)
                {
                    tryParseHP = false;
                }
            }

            //AP deklarieren
            bool tryParseAP = false;
            while (!tryParseAP)
            {
                Console.Clear();
                Console.WriteLine(attackPointsValue);
                tryParseAP = float.TryParse(Console.ReadLine(), out ap);
                if (ap < 10 || ap > 20)
                {
                    tryParseAP = false;
                }
            }

            //DP deklarieren
            bool tryParseDP = false;
            while (!tryParseDP)
            {
                Console.Clear();
                Console.WriteLine(defensePointsValue);
                tryParseDP = float.TryParse(Console.ReadLine(), out dp);
                if (dp < 1 || dp > 9)
                {
                    tryParseDP = false;
                }
            }

            //AS deklarieren
            bool tryParseAS = false;
            while (!tryParseAS)
            {
                Console.Clear();
                Console.WriteLine(attackSpeedValue);
                tryParseAS = float.TryParse(Console.ReadLine(), out attackSpeed);
                if (attackSpeed < 1 || attackSpeed > 10)
                {
                    tryParseAS = false;
                }
            }
        }

        public void ResetValues()
        {
            orkSelected = false;
            trollSelected = false;
            goblinSelected = false;
        }

        public void Fight(Monster Monster1, Monster Monster2)
        {                               
            bool isDead = false;
            bool skipFight = false;
            Random rnd = new Random();

            while (!isDead)
            {
                Console.Clear();
                Monster1.ShowStats();
                Monster2.ShowStats();
                Console.WriteLine();
                Console.WriteLine("------------------------------------------");
                Console.WriteLine();
                Console.WriteLine(buttonInstruction);
                //Runde zählen
                roundCounter++;
                //Item einsammeln
                if (Monster1.AttackSpeed >= Monster2.AttackSpeed && itemsOn)
                {
                    int itemRate = rnd.Next(0, 4);
                    //Chance von 20% ein Item einzusammeln
                    if (itemRate == 1)
                    {
                        Monster1.FindItem();
                    }
                } else if(itemsOn)
                {
                    int itemRate = rnd.Next(0, 4);
                    //Chance von 20% ein Item einzusammeln
                    if (itemRate == 1)
                    {
                        Monster2.FindItem();
                    }
                }

                //Fight skippen
                if (skipFight == false)
                {
                    var key = Console.ReadKey(true);
                    switch (key.Key)
                    {                        
                        case ConsoleKey.Enter:
                            {
                                skipFight = true;
                            }
                            break;
                        case ConsoleKey.Spacebar:
                            {

                            }
                            break;
                    }
                }

                //Angriffsloop
                if (Monster1.AttackSpeed >= Monster2.AttackSpeed)
                {
                    Monster1.Attack(Monster2);
                    if(Monster2.Health > 0)
                    {
                        Monster2.Attack(Monster1);
                    }                     
                }
                else if (Monster2.AttackSpeed >= Monster1.AttackSpeed)
                {
                    Monster2.Attack(Monster1);
                    if(Monster1.Health > 0)
                    {
                        Monster1.Attack(Monster2);
                    }
                }

                //Ende
                if (Monster1.Health <= 0)
                {
                    isDead = true;
                    Console.Clear();
                    Console.WriteLine($"{Monster2.Race} hat gewonnen!");
                    Console.WriteLine(RoundText);
                }
                else if (Monster2.Health <= 0)
                {
                    isDead = true;
                    Console.Clear();
                    Console.WriteLine($"{Monster1.Race} hat gewonnen!");
                    Console.WriteLine(RoundText);
                }
            }

            //Kehre zurück zum Menü und starte ein neues Spiel
            Console.WriteLine(backToMenuText);
            Console.ReadKey();
            Game newGame = new Game();
            newGame.MainMenu();
        }

        private void GetRandomValues()
        {
            bool selectRace = true;
            Random rnd = new Random();

            //Weise zufällig eine Rasse zu die noch nicht vergeben wurde
            while(selectRace)
            {
                switch (rnd.Next(2))
                {
                    case 0:
                        if (goblinSelected == false)
                        {
                            race = "Goblin";
                            goblinSelected = true;
                            selectRace = false;
                        } 
                        break;
                    case 1:
                        if (orkSelected == false)
                        {
                            race = "Ork";
                            orkSelected = true;
                            selectRace = false;
                        }
                        break;
                    case 2:
                        if (trollSelected == false)
                        {
                            race = "Troll";
                            trollSelected = true;
                            selectRace = false;
                        }
                        break;
                } 
            }

            hp = rnd.Next(10, 201);
            ap = rnd.Next(10, 21);
            dp = rnd.Next(0, 10);
            attackSpeed = rnd.Next(2, 10);
        }
    }
}
