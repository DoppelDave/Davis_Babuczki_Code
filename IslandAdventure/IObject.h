#ifndef IOBJECT_H
#define IOBJECT_H
#include "ErrorState.h"

class IObject 
{
public:
	virtual ErrorState Initialize(void) = 0;
	virtual ErrorState Finalize(void) = 0;
	virtual ErrorState Update(void) = 0;
	virtual ErrorState Draw(void) = 0;
	
};
#endif // !IOBJECT_H

