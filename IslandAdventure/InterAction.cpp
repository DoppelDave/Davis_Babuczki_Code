#include "InterAction.h"

void CInterAction::Execute()
{
	cout << m_sDescription << endl;
}

string CInterAction::GetAreaName()
{
	return m_sDescription;
}
