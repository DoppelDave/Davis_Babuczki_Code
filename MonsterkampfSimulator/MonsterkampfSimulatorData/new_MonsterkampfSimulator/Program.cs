using new_MonsterkampfSimulator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using static new_MonsterkampfSimulator.Monster;

internal class Program
{    
     public static void Main(string[] args)
     {
        Game game = new Game();
        game.MainMenu();
    }
}