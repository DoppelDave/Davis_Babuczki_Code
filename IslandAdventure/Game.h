#ifndef GAME_H
#define GAME_H
#include "ErrorState.h"
#include "IObject.h"
#include <string>
using namespace std;

class CGame : IObject
{

public:
	// Execution Order
	virtual ErrorState Initialize(void) override;
	virtual ErrorState Finalize(void) override;
private:
	virtual ErrorState Update(void) override;
	virtual ErrorState Draw(void) override;

	void TitleMenu(void);
	void CreatePlayer(void);
public:
	ErrorState Run(void);

private:
	class CTextController* m_pTC = nullptr;
	class CPlayer* m_pPlayer = nullptr;	
	bool m_bIsRunning = false;  
};
#endif // !GAME_H


