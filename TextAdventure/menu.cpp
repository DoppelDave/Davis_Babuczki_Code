#include <iostream>
#include <string>
#include "Player.h"
#include <windows.h>

using namespace std;
 

CPlayer StartIntroduction(void); //Forward Declaration
void CheckInput(void);



int playerHealth = 100;
int playerStamina = 20;
int playerAttack = 10;
int easyModeMultiplikator = 2;

CPlayer StartIntroduction(void)
{
    cout << "Who are you?" <<endl;

    string sInput = "";
    cin >> sInput;

    CPlayer player = {};
    player = CPlayer();
    player.SetName(sInput);

    player = CreatePlayerStats(player)
    
    return player;
}

CPlayer CreatePlayerStats(CPlayer player)
{
    bool wrongInput = false;

    while(true)
    {
        system("cls");
        cout << "Hello " << player.GetName() << ", do u want to play the game in easy (better stats)?" << endl;
        cout << "[1] = yes" << endl << "[2] = no" << endl;

        if(wrongInput) cout << "Invalid input. Please try again.." << endl;


        sInput = "";  
        cin >> sInput;

        if(sInput == "1")
        {
            cout << "You selelected yes(easy)";
            player.SetHealth(playerHealth * easyModeMultiplikator);
            player.SetStamina(playerStamina * easyModeMultiplikator);
            player.SetAttack(playerAttack * easyModeMultiplikator);
            break;
        }
        else if(sInput == "2")
        {
            player.SetHealth(playerHealth);
            player.SetStamina(playerStamina);
            player.SetAttack(playerAttack);

            break;
        }
        else
        {
            wrongInput = true;
        }    
    }
}

void ShowPlayerStats(CPlayer player)
{
    cout << "Health: " << player.GetHealth() << endl;
    cout << "Stamina: " << player.GetStamina() << endl;
    cout << "Attackdamage: " << player.GetAttack() << endl;
}

int main() 
{
    string userInput = "";

    CPlayer player = {};
    player = StartIntroduction();
    system("cls");
    ShowPlayerStats(player);

    cin >> userInput;

    return 0;
}




