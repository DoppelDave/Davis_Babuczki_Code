using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;


internal class Program
{
    #region Variablen
    static readonly char roomTile = '░';
    static readonly char player = 'O';
    static readonly char key = 'ƪ';
    static readonly char door = 'X';
    static readonly char wallver = '║';
    static readonly char wallhor = '═';
    static readonly char cornerNW = '╔';
    static readonly char cornerNE = '╗';
    static readonly char cornerSE = '╝';
    static readonly char cornerSW = '╚';
    static readonly int minRandom = 1;   
    static char[,] room = null;
    static Timer _timer = null;
    static int counter = 10;
    static int width = -1;   
    static int height = -1;
    static int keyPositionX = -1;
    static int keyPositionY = -1;
    static int playerPosX = -1;
    static int playerPosY = -1;
    static int doorPositionX = -1;
    static int doorPositionY = -1;
    static int minRoom = 5;
    static int maxRoom = 10;
    static bool gameEnd = false;
    static bool keyCollected = false;
    static bool tryParseHeight = false;
    static bool tryParseWidth = false;
    static bool gameLost = false;
    static bool hardMode = true;
    static string welcomeText = "Willkommen zum Escaperoom!";
    static string welcomeText2 = "Wähle bitte einen Spielmodus aus";
    static string welcomeText3 = "Drücke Enter um zu bestätigen";
    static string gameMode = "<   Easy   >";
    static string gameMode2 = "<   Hard   >";
    static string movementText = "Benutze die Pfeiltasten um dich zu bewegen";
    static string exitText = "Drücke Escape um das Spiel zu beenden";
    static string foundKeyText = "Super, du hast den Schlüssel gefunden.";
    static string needKeyText = "Hebe den Schlüssel auf um zu entkommen";
    static string pressSpaceBarText = "Drücke Leertaste um das Spiel erneut zu starten.";
    static string lostText = "Schade, du hast leider verloren";
    static string winText = "Herzlichen Glückwunsch, du hast gewonnen!";
    static string writeWith = "Gib bitte die Breite deines Raumens ein.";
    static string writeHight = "Gib bitte die Höhe deines Raumes ein";
    static string errorNumberText = "Bitte gib eine Zahl ein";
    static string wrongNumberText = $"Bitte gib eine Zahl zwischen {minRoom} und {maxRoom} ein";
    #endregion

    private static void Main(string[] args)
    {
        Menu();      
    }
    static void PrintRoom()
    {
        //Hol die Position vom Spieler und der Tür
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.BackgroundColor = ConsoleColor.Black;
        room[playerPosX, playerPosY] = player;
        room[doorPositionX, doorPositionY] = door;       

        //Zeige den Schlüssel an, wenn er noch nicht eingesammelt wurde
        if (keyCollected == false)
        {
            room[keyPositionX, keyPositionY] = key;            
            if(room[playerPosX, playerPosY] == room[keyPositionX, keyPositionY])
            {
                room[keyPositionX, keyPositionY] = player;
                keyCollected = true;
            }
            if (room[playerPosX, playerPosY] == room[doorPositionX, doorPositionY])
            {
                room[doorPositionX, doorPositionY] = player;
            }
        }
        
        //Gib den Raum aus abhängig von der Höhe und Breite
        for (int y = 0; y < height; y++)
        {
            Console.WriteLine();
            for (int x = 0; x < width; x++)
            {
                if (room[x, y] == room[playerPosX, playerPosY])
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (room[x, y] == room[keyPositionX, keyPositionY] && keyCollected == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (room[x, y] == room[doorPositionX, doorPositionY])
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (keyCollected == true && hardMode == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write($" {room[x, y]}");
            }
        }                

        //Steuerung Instruction
        Console.ResetColor();      
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine($"{movementText}");
        Console.WriteLine($"{exitText}");
        Console.WriteLine("");
        
        if (keyCollected == true)
        {
            Console.WriteLine(foundKeyText);
        }
        
        //Überprüfe ob der Player an der Tür steht
        if (room[playerPosX, playerPosY] == room[doorPositionX, doorPositionY])
        {
            if (keyCollected == false)
            {
                room[doorPositionX, doorPositionY] = player;
            }
            else
            {
                room[doorPositionX, doorPositionY] = player;
                EndGame();
            }
        }
    }   
    static void RoomTile()
    {
        //Weise den Rändern des Raumes die jeweiligen Wänden zu
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                room[x, y] = roomTile;
                if (x == 0)
                {                    
                    room[x, y] = wallver;                  
                }
                if (x == width-1)
                {
                    room[x, y] = wallver;
                }
                if (y == 0)
                {
                    room[x, y] = wallhor;
                }
                if (y == height-1)
                {
                    room[x, y] = wallhor;
                }
                if (x == 0 & y == 0)
                {
                    room[x, y] = cornerNW;
                }
                if (x == width -1 & y == 0)
                {
                    room[x, y] = cornerNE;
                }
                if (x == 0 & y == height - 1)
                {
                    room[x, y] = cornerSW;
                }
                if (x == width -1 & y == height -1)
                {
                    room[x, y] = cornerSE;
                }
            }
        }                
    }
    static void Menu()
    {
        //Hauptmenü
        Console.Clear();       
        Console.SetCursorPosition((Console.WindowWidth - welcomeText.Length) / 2, Console.CursorTop);
        Console.WriteLine(welcomeText);
        Console.SetCursorPosition((Console.WindowWidth - welcomeText2.Length) / 2, Console.CursorTop);
        Console.WriteLine(welcomeText2);
        Console.SetCursorPosition((Console.WindowWidth - welcomeText3.Length) / 2, Console.CursorTop);
        Console.WriteLine(welcomeText3);
        Console.SetCursorPosition((Console.WindowWidth - gameMode.Length) / 2, Console.CursorTop);
        Console.WriteLine(gameMode);

        bool readkeyend = false;
        bool displayEasy = true;
        gameEnd = false;
        keyCollected = false;
        gameLost = false;
        counter = 10;
        
        //Spielmodus auswahl
        while (readkeyend == false)
        {            
            var keyend = Console.ReadKey(true);
            switch (keyend.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (displayEasy == false)
                    {
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth - welcomeText.Length) / 2, Console.CursorTop);
                        Console.WriteLine(welcomeText);
                        Console.SetCursorPosition((Console.WindowWidth - welcomeText2.Length) / 2, Console.CursorTop);
                        Console.WriteLine(welcomeText2);
                        Console.SetCursorPosition((Console.WindowWidth - welcomeText3.Length) / 2, Console.CursorTop);
                        Console.WriteLine(welcomeText3);
                        Console.SetCursorPosition((Console.WindowWidth - gameMode.Length) / 2, Console.CursorTop);
                        Console.WriteLine(gameMode);
                        displayEasy = true;
                    } else
                    {
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth - welcomeText.Length) / 2, Console.CursorTop);
                        Console.WriteLine(welcomeText);
                        Console.SetCursorPosition((Console.WindowWidth - welcomeText2.Length) / 2, Console.CursorTop);
                        Console.WriteLine(welcomeText2);
                        Console.SetCursorPosition((Console.WindowWidth - welcomeText3.Length) / 2, Console.CursorTop);
                        Console.WriteLine(welcomeText3);
                        Console.SetCursorPosition((Console.WindowWidth - gameMode2.Length) / 2, Console.CursorTop);
                        Console.WriteLine(gameMode2);
                        displayEasy = false;
                    }
                   
                    break;
                case ConsoleKey.RightArrow:
                    if (displayEasy == false)
                    {
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth - welcomeText.Length) / 2, Console.CursorTop);
                        Console.WriteLine(welcomeText);
                        Console.SetCursorPosition((Console.WindowWidth - welcomeText2.Length) / 2, Console.CursorTop);
                        Console.WriteLine(welcomeText2);
                        Console.SetCursorPosition((Console.WindowWidth - welcomeText3.Length) / 2, Console.CursorTop);
                        Console.WriteLine(welcomeText3);
                        Console.SetCursorPosition((Console.WindowWidth - gameMode.Length) / 2, Console.CursorTop);
                        Console.WriteLine(gameMode);
                        displayEasy = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth - welcomeText.Length) / 2, Console.CursorTop);
                        Console.WriteLine(welcomeText);
                        Console.SetCursorPosition((Console.WindowWidth - welcomeText2.Length) / 2, Console.CursorTop);
                        Console.WriteLine(welcomeText2);
                        Console.SetCursorPosition((Console.WindowWidth - welcomeText3.Length) / 2, Console.CursorTop);
                        Console.WriteLine(welcomeText3);
                        Console.SetCursorPosition((Console.WindowWidth - gameMode2.Length) / 2, Console.CursorTop);
                        Console.WriteLine(gameMode2);
                        displayEasy = false;
                    }
                    break;
                case ConsoleKey.Enter:
                    readkeyend = true;
                    break;

            }
        }
        Console.Clear();
        if (displayEasy == true) 
        {
            hardMode = false;
        } 
        else
        {
            hardMode = true;
        }

        GameStart();
    }
    static void EndGame()
    {
        gameEnd = true;
        Console.Clear();

        //Auswahlmöglichkeiten bei Beendigung des Spiels
        if(gameLost == true)
        {
            Console.WriteLine(lostText);
            Console.WriteLine("");
            Console.WriteLine(pressSpaceBarText);
            Console.WriteLine(exitText);
        }
        else
        {
            Console.WriteLine(winText);
            Console.WriteLine("");
            Console.WriteLine(pressSpaceBarText);
            Console.WriteLine(exitText);
        }

        bool readkeyend = false;

        //Kehre bei Eingabe der Leertaste zurück zum Menü
        //Beende bei Eingabe von Esacape das Programm
        while (readkeyend == false) 
        {
            var keyend = Console.ReadKey(true);
            switch (keyend.Key)
            {             
                case ConsoleKey.Spacebar:
                    Menu();
                    break;
                case ConsoleKey.Escape:
                    readkeyend = true;
                    break;
            }
        }
    }
    static void GameStart()
    {
        Console.Clear();
        //Eingabe der Breite vom Raum
        Console.WriteLine(writeWith);
        do
        {
            string widthString = Console.ReadLine();
            tryParseWidth = int.TryParse(widthString, out width);
            if (tryParseWidth == false)
            {
                Console.Clear();
                Console.WriteLine(writeWith);
                Console.WriteLine(errorNumberText);
            }
            else if (width < minRoom)
            {
                tryParseWidth = false;
                Console.Clear();
                Console.WriteLine(writeWith);
                Console.WriteLine(wrongNumberText);
            }
            else if (width > maxRoom)
            {
                tryParseWidth = false;
                Console.Clear();
                Console.WriteLine(writeWith);
                Console.WriteLine(wrongNumberText);
            }
        } while (tryParseWidth == false);

        Console.Clear();
        Console.WriteLine(writeHight);
        //Eingabe der Höhe vom Raum
        do
        {
            string heightString = Console.ReadLine();
            tryParseHeight = int.TryParse(heightString, out height);
            if (tryParseHeight == false)
            {
                Console.Clear();
                Console.WriteLine(writeHight);
                Console.WriteLine(errorNumberText);
            }
            else if (height < minRoom )
            {
                tryParseHeight = false;
                Console.Clear();
                Console.WriteLine(writeHight);
                Console.WriteLine(wrongNumberText);
            }
            else if (height > maxRoom)
            {
                tryParseHeight = false;
                Console.Clear();
                Console.WriteLine(writeHight);
                Console.WriteLine(wrongNumberText);
            }
        } while (tryParseHeight == false);

        room = new char[width, height];
        keyCollected = false;
        gameEnd = false;

        //Erstelle den Raum
        RoomTile();

        //Platziere den Spieler zufällig im Raum innerhalb der Wände
        Random random = new Random();
        playerPosX = random.Next(minRandom, width-1);
        playerPosY = random.Next(minRandom, height-1);
        room[playerPosX, playerPosY] = player;

        //Platziere den Schlüssel zufällig im Raum innerhalb der Wände
        Random randomKey = new Random();
        keyPositionX = randomKey.Next(minRandom, width-1);
        keyPositionY = randomKey.Next(minRandom, height-1);
        room[keyPositionX, keyPositionY] = key;

        //Wenn Player die gleiche Position wie der Schlüssel hat positioniere den Schlüssel neu
        if (room[playerPosX, playerPosY] == room[keyPositionX, keyPositionY])
        {
            keyPositionX = randomKey.Next(minRandom, width - 1);
            keyPositionY = randomKey.Next(minRandom, height - 1);
        }
        
        //Platziere die Tür zufällig in eine der Wände
        int doorSide = random.Next(1, 5);
        doorSide = 1;
        switch(doorSide)
        {
            case 1:
                doorPositionX = 0;
                doorPositionY = random.Next(1, height-1);
                break;
            case 2:
                doorPositionX = width - 1; ;
                doorPositionY = random.Next(1, height-1);
                break;
            case 3:
                doorPositionX = random.Next(1, width - 1);
                doorPositionY = 0;
                break;
            case 4:
                doorPositionX = random.Next(1, width - 1);
                doorPositionY = height - 1;               
                break;
        }
        room[doorPositionX, doorPositionY] = door;

        //Setzte den Timer jede Sekunde
        _timer = new Timer(TimerCallback,null, 0, 1000);

        //Gib den erstellten Raum aus
        PrintRoom();

        //Spielersteuerung
        while (gameEnd == false)
        {
            Console.WriteLine("");
            var key = Console.ReadKey(true);

            //Setzte den Spieler bei Eingabe der Steuerungstasten in die jeweilige Position und schreibe den Raum neu
            //Wenn Spieler die Wand erreicht setzte ihn wieder zurück
            switch (key.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    RoomTile();
                    playerPosY--;
                    if (playerPosX == doorPositionX && playerPosY == doorPositionY)
                    {
                        if (keyCollected == false)
                        {
                            playerPosY++;
                            RoomTile();
                            PrintRoom();
                            Console.WriteLine(needKeyText);
                        }
                        else
                        {
                            RoomTile();
                            PrintRoom();
                        }
                    }
                    else if (playerPosY == height - height)
                    {
                        playerPosY++;
                        RoomTile();
                        Console.Beep();
                        PrintRoom();
                    }
                    else
                    {
                        RoomTile();
                        PrintRoom();
                    }                    
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    RoomTile();
                    playerPosY++;
                    if (playerPosX == doorPositionX && playerPosY == doorPositionY)
                    {
                        if (keyCollected == false)
                        {
                            playerPosY--;
                            RoomTile();
                            PrintRoom();
                            Console.WriteLine(needKeyText);
                        }
                        else
                        {
                            RoomTile();
                            PrintRoom();
                        }
                    }
                    else if (playerPosY == height-1)
                    {
                        playerPosY--;
                        RoomTile();
                        Console.Beep();
                        PrintRoom();
                    }
                    else
                    {
                        RoomTile();
                        PrintRoom();
                    }
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    RoomTile();
                    playerPosX--;
                    if (playerPosX == doorPositionX && playerPosY == doorPositionY)
                    {
                        if (keyCollected == false)
                        {
                            playerPosX++;
                            RoomTile();
                            PrintRoom();
                            Console.WriteLine(needKeyText);
                        }
                        else
                        {
                            RoomTile();
                            PrintRoom();
                        }
                    }
                    else if (playerPosX == width - width)
                    {
                        playerPosX++;
                        RoomTile();
                        Console.Beep();
                        PrintRoom();
                    }  else
                    {
                        RoomTile();
                        PrintRoom();
                    }                    
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    RoomTile();
                    playerPosX++;
                    if (playerPosX == doorPositionX && playerPosY == doorPositionY)
                    {
                        if(keyCollected == false)
                        {
                            playerPosX--;
                            RoomTile();
                            PrintRoom();
                            Console.WriteLine(needKeyText);
                        } else
                        {                                                     
                            RoomTile();
                            PrintRoom();                           
                        }
                        
                    }
                    else if (playerPosX == width-1)
                    {
                        playerPosX--;
                        RoomTile();
                        Console.Beep();
                        PrintRoom();
                    }
                    else
                    {
                        RoomTile();
                        PrintRoom();
                    }                       
                    break;
                case ConsoleKey.Escape:
                    return;

            }
        }
    }   
    private static void TimerCallback(Object o)
    {
        //Zähle den Counter runter sobald der Schlüssel eingesammelt wurde und der HardModus an ist
        if (keyCollected == true && hardMode == true && gameEnd == false)
        {
            counter--;

            Console.SetCursorPosition(0, 20);
            Console.Write($"Beeil dich! Du hast nur noch {counter}s Zeit zuentkommen!");

            //Beende das Spiel wenn der Counter bei 0 ist
            if (counter == 0)
            {
                gameLost = true;
                EndGame();
            }
        }       
    }
}