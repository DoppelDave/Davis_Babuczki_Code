#include "Player.h"

string CPlayer::GetName(void)
{
    return m_sName;
}

void CPlayer::SetName(string a_sName)
{
    m_sName = a_sName;
}

int CPlayer::GetHealth(void)
{
    return m_iHealth;
}

void CPlayer::SetHealth(int a_iHealth)
{
    m_iHealth = a_iHealth;
}

int CPlayer::GetStamina(void)
{
    return m_iStamina;
}

void CPlayer::SetStamina(int a_iStamina)
{
    m_iStamina = a_iStamina;
}

int CPlayer::GetAttack(void)
{
    return m_iAttack;
}

void CPlayer::SetAttack(int a_iAttack)
{
    m_iAttack = a_iAttack;
}


