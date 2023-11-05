#include "Viewport.h"

const int I_OFFSET_X = 0;
const int I_OFFSET_Y = 0;

// Functions
void HandleFramebufferSize(GLFWwindow* a_pWindow, int a_iWidth, int a_iHeight)
{
	glViewport(I_OFFSET_X, I_OFFSET_Y, a_iWidth, a_iHeight);
}


void ProcessInput(GLFWwindow* a_pWindow)
{
	if (glfwGetKey(a_pWindow, GLFW_KEY_ESCAPE) == GLFW_PRESS)
	{
		glfwSetWindowShouldClose(a_pWindow, true);
	}
}
 const int CViewport::Initialize(void)
{
	//Config
	glfwInit();
	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, m_iGlfwVersionMajor);
	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, m_iGlfwVersionMinor);
	glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);

	//Window
	m_pWindow = glfwCreateWindow(m_iWindowWidth, m_iWindowHeight, m_sWindowTitle.c_str(), nullptr, nullptr);


	if (m_pWindow == nullptr)
	{
		m_error = ErrorType::ET_WINDOW_CREATION_FAILED;
		cout << "ERROR: GLFW Window Creation failed!" << endl;
		glfwTerminate();
		return static_cast<int>(m_error);
	}

	glfwMakeContextCurrent(m_pWindow);
	glfwSetFramebufferSizeCallback(m_pWindow, HandleFramebufferSize);

	//GLAD
	if (!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress))
	{
		m_error = ErrorType::ET_GLAD_INITIALISATION_FAILED;
		cout << "ERROR: GLAD Initialisation failed" << endl;
		return static_cast<int>(m_error);
	}

    return 0;
}

void CViewport::Finalize(void)
{
	glfwTerminate();
}

const int CViewport::Update(void)
{
	ProcessInput(m_pWindow);
    return 0;
}

const int CViewport::Draw(void)
{
	glClearColor(m_fRed, m_fGreen, m_fBlue, m_fAlpha);
	glClear(GL_COLOR_BUFFER_BIT);

    return 0;
}

const int CViewport::LateDraw(void)
{
	glfwSwapBuffers(m_pWindow);
	glfwPollEvents();
	return 0;
}
