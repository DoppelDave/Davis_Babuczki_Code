#include "Game.h"
#include <iostream>
#include <windows.h>
using namespace std;

/*************************************************************************/
//Variablen
/*************************************************************************/
CGame* pGame = nullptr;
/*************************************************************************/

ErrorState Initialize(void) 
{
    auto result = ErrorState::ES_SUCCESS;
    if (pGame == nullptr) pGame = new CGame();
    else result = ErrorState::ES_GAME_PTR_FAILED_NULLCHECK;

    if (pGame != nullptr) return result;

    if (pGame == nullptr) result = ErrorState::ES_GAME_PTR_FAILED_INSTANTIATE;

    return result;
}

ErrorState Run(void)
{
    auto result = ErrorState::ES_SUCCESS;
    if (pGame != nullptr) pGame->Initialize();
    if (pGame != nullptr) pGame->Run();
    if (pGame != nullptr) pGame->Finalize();
    return result;
}

ErrorState Finalize(void)
{
    auto result = ErrorState::ES_SUCCESS;
    if(pGame != nullptr)
    {
        delete(pGame);
        pGame = nullptr;
    }
    return result;
}

int main()
{
    auto result = ErrorState::ES_SUCCESS;
    //Fullscreen
    /*HWND hwnd = GetConsoleWindow();
    ShowWindow(hwnd, SW_MAXIMIZE);*/

    result = Initialize();
    result = Run();
    result = Finalize();

    return static_cast<int>(result);
}


