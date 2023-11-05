#include "Math.h"

void Add(int a_iLHS, int a_iRHS, int& a_iResult)
{
	a_iResult = a_iLHS + a_iRHS;
}

void Substract(int a_iLHS, int a_iRHS, int& a_iResult)
{
	a_iResult = a_iLHS - a_iRHS;
}

void Multiply(int a_iLHS, int a_iRHS, int& a_iResult)
{
	a_iResult = a_iLHS * a_iRHS;
}

void Divide(int a_iLHS, int a_iRHS, int& a_iResult)
{
	a_iResult = a_iLHS / a_iRHS;
}
