#include "Engine.h"

int main(int a_iArgV, const char* a_argsC[])
{
	CEngine* pEngine = new CEngine();

	if (pEngine != nullptr) PROVE_RESULT(pEngine->Initialize());
	if (pEngine != nullptr) PROVE_RESULT(pEngine->Run());
	FINALIZE_DELETE(pEngine);
	
	return 0;
}