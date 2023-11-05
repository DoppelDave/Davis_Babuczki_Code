#ifndef INTERACTION_H
#define INTERACTION_H
#include <string>
#include <iostream>
using namespace std;


class CInterAction
{
public:
	CInterAction(const string& a_sInteractionName, const string& a_sDescription)
		: m_sInteractionName(a_sInteractionName), m_sDescription(m_sDescription) {}
	void Execute();
	string GetAreaName();

private:
	string m_sInteractionName;
	string m_sDescription;
};




#endif // !INTERACTION_H

