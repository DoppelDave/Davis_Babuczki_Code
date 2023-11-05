#ifndef OBJECT_H
#define OBJECT_H

class IObject
{
public:

	//virtual da nur ableitung
	// = 0 damit nur headerdatei ohne body , wie bei c# abstract

	virtual const int Initialize(void) = 0;
	virtual void Finalize(void) = 0;
	virtual const int Update(void)  = 0;
	virtual const int Draw(void) = 0;
};



#endif // !OBJECT_H
