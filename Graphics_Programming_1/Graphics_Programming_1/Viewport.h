#ifndef VIEWPORT_H
#define VIEWPORT_H

#include <glad/glad.h>
#include <GLFW/glfw3.h>
#include "Object.h"
#include "ErrorTypes.h"
#include <string>
#include <iostream>
using namespace std;

class CViewport : public IObject
{
public:
    inline CViewport(int a_iVersionMajor, int a_iVersionMinor, int a_iWidth, int a_iHeight, string a_sTitle,
        float a_fRed, float a_fGreen, float a_fBlue, float a_fAlpha)
        : m_iGlfwVersionMajor(a_iVersionMajor), m_iGlfwVersionMinor(a_iVersionMinor),
        m_iWindowHeight(a_iHeight), m_iWindowWidth(a_iWidth), m_sWindowTitle(a_sTitle),
        m_fRed(a_fRed),m_fGreen(a_fGreen), m_fBlue(a_fBlue), m_fAlpha(a_fAlpha)
    {
    }

    inline GLFWwindow* GetWindow(void) { return m_pWindow; }

    // Inherited via IObject
    const int Initialize(void) override;
    void Finalize(void) override;
    const int Update(void) override;
    const int Draw(void) override;
    const int LateDraw(void);

private:

    //Membervariablen
    GLFWwindow* m_pWindow = nullptr;
    ErrorType m_error = ErrorType::ET_SUCCESS;

    int m_iGlfwVersionMajor = 0;
    int m_iGlfwVersionMinor = 0;
    int m_iWindowWidth = 0;
    int m_iWindowHeight = 0;
    float m_fRed = 1.0f;
    float m_fGreen = 0.0f;
    float m_fBlue = 0.0f;
    float m_fAlpha = 1.0f;
    string m_sWindowTitle = "Nuke Engine";
};

#endif // !VIEWPORT_H
