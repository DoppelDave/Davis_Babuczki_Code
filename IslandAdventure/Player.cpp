#include "Player.h"
#include <string>

string CPlayer::GetName(void)
{
	return m_sPlayerName;
}

int CPlayer::GetHealth(void)
{
	return m_iPlayerHealth;
}

int CPlayer::GetStamina(void)
{
	return m_iPlayerStamina;
}

int CPlayer::GetAttackDamage(void)
{
	return m_iPlayerAttack;
}

void CPlayer::SetHealth(int a_iHealth)
{
	m_iPlayerHealth = a_iHealth;
}

void CPlayer::SetStamina(int a_iStamina)
{
	m_sPlayerName = a_iStamina;
}

void CPlayer::SetAttackDamage(int a_iAttackDamage)
{
	a_iAttackDamage = a_iAttackDamage;
}

void CPlayer::SetPlayerStats(int a_iPlayerHealth, int a_iPlayerStamina, int a_iPlayerAttack)
{	
	m_iPlayerHealth = a_iPlayerHealth;
	m_iPlayerStamina = a_iPlayerStamina;
	m_iPlayerAttack = a_iPlayerAttack;
}

void CPlayer::ShowPlayerStats()
{
	cout << m_sHealthText << m_iPlayerHealth << endl;
	cout << m_sStaminaText << m_iPlayerStamina << endl;
	cout << m_sAttackText << m_iPlayerAttack << endl;
}


