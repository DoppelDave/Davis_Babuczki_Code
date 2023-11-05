#ifndef ENGINE_H
#define ENGINE_H
#include "Viewport.h"
#include "Material.h"
#include "Defines.h"
#include "Mesh.h"
#include <iostream>



//Konstanten
const int M_I_GLFW_VERSION_MAJOR = 3;
const int M_I_GLFW_VERSION_MINOR = 3;
const int M_I_WIDTH = 2560;
const int M_I_HEIGHT = 1440;
const string M_S_TITLE = "Nuke Engine";
const int M_I_OFFSET_X = 0;
const int M_I_OFFSET_Y = 0;
const float M_F_RED = 0.0f;
const float M_F_GREEN = 1.0f;
const float M_F_BLUE = 0.0f;
const float M_F_ALPHA = 0.5f;


class CEngine
{
public: 
	int Initialize(void);
	int Run(void);
	void Finalize(void);

private:
	CViewport* m_pViewport = nullptr;
	CMaterial* m_pMaterial = nullptr;
	CMesh* m_pMesh = nullptr;
	
};

#endif // !ENGINE_H


