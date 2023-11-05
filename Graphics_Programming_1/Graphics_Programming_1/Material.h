#ifndef MATERIAL_H
#define MATERIAL_H
#include "Object.h"

class CMaterial : public IObject
{
public:
	// Execution Order
	virtual const int Initialize(void) override;
	void Finalize(void) override;
	virtual const int Update(void) override;
	virtual const int Draw(void) override;
};

#endif // !MATERIAL_H



