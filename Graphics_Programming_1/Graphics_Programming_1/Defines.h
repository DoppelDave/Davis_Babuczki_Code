#ifndef DEFINES_H
#define DEFINES_H

#define SAFE_DELETE(x)	\
	if (x != nullptr)	\
	{					\
		delete x;		\
		x = nullptr;	\
	};					

#define FINALIZE_DELETE(x)	\
	if(x != nullptr)		\
	{						\
		x->Finalize();		\
		delete x;			\
		x = nullptr;		\
	};

#define PROVE_RESULT(x)	\
{						\
	if(x != 0) return x; \
}

#endif // !DEFINES_H

