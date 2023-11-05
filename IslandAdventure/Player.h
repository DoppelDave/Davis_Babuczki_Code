#ifndef PLAYER_H
#define PLAYER_H
#include <string>
#include <iostream>
using namespace std;

class CPlayer
{
public:

	string GetName(void);
	int GetHealth(void);
	int GetStamina(void);
	int GetAttackDamage(void);

	void SetHealth(int a_iHealth);
	void SetStamina(int a_iStamina);
	void SetAttackDamage(int a_iAttackDamage);

	void SetPlayerStats( int a_iPlayerHealth, int a_iPlayerStamina, int a_iPlayerAttack);
	void ShowPlayerStats();

private:
	string m_sPlayerName = "";
	string m_sHealthText = "Health: ";
	string m_sStaminaText = "Stamina: ";
	string m_sAttackText = "Attackpoints: ";
	int m_iPlayerHealth = 100;
	int m_iPlayerStamina = 50;
	int m_iPlayerAttack = 10;
};

#endif // !PLAYER_H



