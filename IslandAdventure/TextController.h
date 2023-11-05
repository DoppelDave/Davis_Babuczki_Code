#ifndef TEXTCONTROLLER_H
#define TEXTCONTROLLER_H
#include <string>
#include <iostream>
using namespace std;

class CTextController
{
public:	
    string GetTitle(void);
    string GetContinueText(void);
    string GetAreaName(int ind);
private:

    #pragma region Title
    const string m_sTitle =
        R"(
    .___       .__                     .___   _________                  .__                   
    |   | _____|  | _____    ____    __| _/  /   _____/__ ____________  _|__|__  _____________ 
    |   |/  ___/  | \__  \  /    \  / __ |   \_____  \|  |  \_  __ \  \/ /  \  \/ /  _ \_  __ \
    |   |\___ \|  |__/ __ \|   |  \/ /_/ |   /        \  |  /|  | \/\   /|  |\   (  <_> )  | \/
    |___/____  >____(____  /___|  /\____ |  /_______  /____/ |__|    \_/ |__| \_/ \____/|__|   
             \/          \/     \/      \/          \/                                         
        )";
    #pragma endregion

    string m_sContinueText = "Press [Enter] to continue";
    string m_sAreaName_1 = "Beach";
    string m_sAreaName_2 = "Beach East";
    string m_sAreaName_3 = "Beach West";
};




#endif // !TEXTCONTROLLER_H

