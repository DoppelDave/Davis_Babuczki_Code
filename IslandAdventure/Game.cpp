#include "Game.h"
#include "TextController.h"
#include "Player.h"
#include <iostream>


void CGame::TitleMenu()
{
	//Create TextController
	if (m_pTC == nullptr) m_pTC = new CTextController();
	cout << m_pTC->GetTitle() << endl;
	cout << m_pTC->GetContinueText() << endl;
	cin.get();
}

void CGame::CreatePlayer(void)
{
	//Create Player
	if (m_pPlayer == nullptr) m_pPlayer = new CPlayer();
}

ErrorState CGame::Initialize(void)
{
	auto result = ErrorState::ES_SUCCESS;
	TitleMenu();
	CreatePlayer();
	m_bIsRunning = true;
	return result;
}

ErrorState CGame::Run(void)
{
	auto result = ErrorState::ES_SUCCESS;
	while (m_bIsRunning) 
	{
		system("cls");
		Update();
		Draw();
	}
	return result;
}

ErrorState CGame::Finalize(void)
{
	auto result = ErrorState::ES_SUCCESS;
	m_bIsRunning = false;

	//Delete Player
	if (m_pPlayer != nullptr)
	{
		delete(m_pPlayer);
		m_pPlayer = nullptr;
	}

	//Delete TextController
	if (m_pTC != nullptr)
	{
		delete(m_pTC);
		m_pTC = nullptr;
	}

	return result;
}

ErrorState CGame::Update(void)
{
	auto result = ErrorState::ES_SUCCESS;
	return result;
}

ErrorState CGame::Draw(void)
{
	auto result = ErrorState::ES_SUCCESS;
	m_pPlayer->ShowPlayerStats();
	
	//Get AreaName
	cout << m_pTC->GetAreaName(1) << endl;
	cout << m_pTC->GetContinueText() << endl;
	cin.get();
	return result;
}


