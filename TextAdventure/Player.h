#include <string>
using namespace std;


class CPlayer
{
public:
    //Getter/Setter
    string GetName(void);
    void SetName(string a_sName);

    int GetHealth(void);
    void SetHealth(int a_iHealth);
    
    int GetStamina(void);
    void SetStamina(int a_iStamina);

    int GetAttack(void);
    void SetAttack(int a_iAttack);


private:
    // Membervariablen
    string m_sName = "";
    int m_iHealth = 0;
    int m_iStamina = 0;
    int m_iAttack = 0;
};