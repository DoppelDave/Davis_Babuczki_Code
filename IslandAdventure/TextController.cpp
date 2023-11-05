#include "TextController.h"

string CTextController::GetTitle(void)
{
	return m_sTitle;
}

string CTextController::GetContinueText(void)
{
	return m_sContinueText;
}

string CTextController::GetAreaName(int ind)
{
	switch (ind)
	{
	case 1: return m_sAreaName_1;
	case 2: return m_sAreaName_2;
	case 3: return m_sAreaName_3;


	default:
		break;
	}
}


