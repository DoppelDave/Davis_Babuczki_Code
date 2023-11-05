#include "Material.h"

#include <glad/glad.h>
#include <GLFW/glfw3.h>
#include <iostream>
#include "ErrorTypes.h"

using namespace std;

//const char* szVertexShader = "#version 330 core\n"
//"layout (location = 0) in vec3 aPos;\n"
//"void main()\n"
//"{\n"
//"   gl_Position = vec4(aPos.x, aPos.y, aPos.z, 1.0);\n"
//"}\0";
//
//const char* szFragmentShader = "#version 330 core\n"
//"out vec4 FragColor;\n"
//"void main()\n"
//"{\n"
//"   FragColor = vec4(1.0f, 0.5f, 5.2f, 0.1f);\n"
//"}\n\0";
//
//unsigned int iShaderProgram = 0;

const int CMaterial::Initialize(void)
{
	////Erstellung eines VertexShaders
	////VertexShader = Position von Eckpunkte in einem 3D-Modell
	//unsigned int iVertexShader = glCreateShader(GL_VERTEX_SHADER); //glCreateShader(vertex) = erstellt ein leeres vertexshader object
	////-> eigenen angelegten Shader in das Objekt laden /1 = Wieviele Shader hab ich gebaut /&sz Zeiger auf eigenen Shader /nullptr da opengl die länge automatisch bestimmt
	//glShaderSource(iVertexShader, 1, &szVertexShader, nullptr);
	////-> Shader kompilieren um sicherzustellen dass der Code korrekt ist
	//glCompileShader(iVertexShader);
	////Überprüfung nach Fehler
	//int iSuccess = 0;
	//char sInfoLog[512];
	//glGetShaderiv(iVertexShader, GL_COMPILE_STATUS, &iSuccess);
	////Fehlercode ausgeben
	//if (!iSuccess)
	//{
	//	//Infolog länge max 512 und speicherung des Fehlerberichts darin
	//	glGetShaderInfoLog(iVertexShader, 512, nullptr, sInfoLog);
	//	cout << "Error: Vertex Shader Compilation failed" << endl;
	//	return static_cast<int>(ErrorType::ET_VERTEX_SHADER_COMPILATION_FAILED);
	//}
	////Fragment Shader
	////Fragment Shader wird für Farben benutzt
	//unsigned int iFragmentShader = glCreateShader(GL_FRAGMENT_SHADER);
	//glShaderSource(iFragmentShader, 1, &szFragmentShader, nullptr);
	//glCompileShader(iFragmentShader);
	//glGetShaderiv(iFragmentShader, GL_COMPILE_STATUS, &iSuccess);

	//if (!iSuccess)
	//{
	//	glGetShaderInfoLog(iFragmentShader, 512, nullptr, sInfoLog);
	//	cout << "Error: Fragment Shader Compilation failed" << endl;
	//	return static_cast<int>(ErrorType::ET_FRAGMENT_SHADER_COMPILATION_FAILED);
	//}

	////// Link Shaders

	//////=Buffer ///ShaderProgramm = Verwaltet die Shader
	//iShaderProgram = glCreateProgram();
	//glAttachShader(iShaderProgram, iVertexShader); //->Verbinden des VertexShader
	//glAttachShader(iShaderProgram, iFragmentShader); //->Verbinden des FragmentShader
	//glLinkProgram(iShaderProgram); //->Verknüpfen der Hinzugefügten Shader mit OpenGL

	//glGetProgramiv(iShaderProgram, GL_LINK_STATUS, &iSuccess);
	//if (!iSuccess)
	//{
	//	glGetProgramInfoLog(iShaderProgram, 512, nullptr, sInfoLog);
	//	cout << "Error: Shader Program Link failed" << endl;
	//	return static_cast<int>(ErrorType::ET_SHADER_PROG_LINK_FAILED);
	//}

	////->Aufräumen der Shader
	//glDeleteShader(iVertexShader);
	//glDeleteShader(iFragmentShader);

    return 0;
}

void CMaterial::Finalize(void)
{
	/*glDeleteProgram(iShaderProgram);*/
}

const int CMaterial::Update(void)
{
    return 0;
}

const int CMaterial::Draw(void)
{
//	glUseProgram(iShaderProgram); //->Programm starten
    return 0;
}
