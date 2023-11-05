#include "Engine.h"
#include <iostream>
#include <glad/glad.h>
#include <GLFW/glfw3.h>
using namespace std;

const char* szVertexShader = "#version 330 core\n"
"layout (location = 0) in vec3 aPos;\n"
"void main()\n"
"{\n"
"   gl_Position = vec4(aPos.x, aPos.y, aPos.z, 1.0);\n"
"}\0";

const char* szFragmentShader = "#version 330 core\n"
"out vec4 FragColor;\n"
"void main()\n"
"{\n"
"   FragColor = vec4(1.0f, 0.5f, 5.2f, 0.1f);\n"
"}\n\0";

unsigned int iShaderProgram = 0;

unsigned int iVBO = 0; //-> VertexBufferObject: Vertexdaten wie Position, Farbe und Texturkoordinate an Grafikspeicherübertragen
unsigned int iVAO = 0; //-> IndexBuffer: //VertexArrayObject : Indexdaten zu speichern. Indizes zeigen auf im VBO gespeicherten Vertices um Primitives zu esrtllen

int CEngine::Initialize(void)
{
	if (m_pViewport == nullptr) m_pViewport = new CViewport(M_I_GLFW_VERSION_MAJOR, M_I_GLFW_VERSION_MINOR,
		M_I_WIDTH, M_I_HEIGHT, M_S_TITLE, M_F_RED, M_F_GREEN, M_F_BLUE, M_F_ALPHA);
	if (m_pMaterial == nullptr) m_pMaterial = new CMaterial();
	if (m_pMesh == nullptr) m_pMesh = new CMesh();


	if (m_pViewport != nullptr) PROVE_RESULT(m_pViewport->Initialize());
	if (m_pMaterial != nullptr) PROVE_RESULT(m_pMaterial->Initialize());
	if (m_pMesh != nullptr) PROVE_RESULT(m_pMesh->Initialize());

	//Erstellung eines VertexShaders
		//VertexShader = Position von Eckpunkte in einem 3D-Modell
		unsigned int iVertexShader = 0; //glCreateShader(vertex) = erstellt ein leeres vertexshader object
		iVertexShader = glCreateShader(GL_VERTEX_SHADER);
	//-> eigenen angelegten Shader in das Objekt laden /1 = Wieviele Shader hab ich gebaut /&sz Zeiger auf eigenen Shader /nullptr da opengl die länge automatisch bestimmt
	glShaderSource(iVertexShader, 1, &szVertexShader, nullptr);
	//-> Shader kompilieren um sicherzustellen dass der Code korrekt ist
	glCompileShader(iVertexShader);
	//Überprüfung nach Fehler
	int iSuccess = 0;
	char sInfoLog[512];
	glGetShaderiv(iVertexShader, GL_COMPILE_STATUS, &iSuccess);
	//Fehlercode ausgeben
	if (!iSuccess)
	{
		//Infolog länge max 512 und speicherung des Fehlerberichts darin
		glGetShaderInfoLog(iVertexShader, 512, nullptr, sInfoLog);
		cout << "Error: Vertex Shader Compilation failed" << endl;
		return static_cast<int>(ErrorType::ET_VERTEX_SHADER_COMPILATION_FAILED);
	}
	//Fragment Shader
	//Fragment Shader wird für Farben benutzt
	unsigned int iFragmentShader = 0;
		iFragmentShader = glCreateShader(GL_FRAGMENT_SHADER);
	glShaderSource(iFragmentShader, 1, &szFragmentShader, nullptr);
	glCompileShader(iFragmentShader);
	glGetShaderiv(iFragmentShader, GL_COMPILE_STATUS, &iSuccess);

	if (!iSuccess)
	{
		glGetShaderInfoLog(iFragmentShader, 512, nullptr, sInfoLog);
		cout << "Error: Fragment Shader Compilation failed" << endl;
		return static_cast<int>(ErrorType::ET_FRAGMENT_SHADER_COMPILATION_FAILED);
	}

	//// Link Shaders
	iShaderProgram = 0;
	////=Buffer ///ShaderProgramm = Verwaltet die Shader
	iShaderProgram = glCreateProgram();
	glAttachShader(iShaderProgram, iVertexShader); //->Verbinden des VertexShader
	glAttachShader(iShaderProgram, iFragmentShader); //->Verbinden des FragmentShader
	glLinkProgram(iShaderProgram); //->Verknüpfen der Hinzugefügten Shader mit OpenGL

	glGetProgramiv(iShaderProgram, GL_LINK_STATUS, &iSuccess);
	if (!iSuccess)
	{
		glGetProgramInfoLog(iShaderProgram, 512, nullptr, sInfoLog);
		cout << "Error: Shader Program Link failed" << endl;
		return static_cast<int>(ErrorType::ET_SHADER_PROG_LINK_FAILED);
	}

	//->Aufräumen der Shader
	glDeleteShader(iVertexShader);
	glDeleteShader(iFragmentShader);

	float verticesArr[] = {
		// x	y		z    //Erstes Dreieck
		-0.9f, -0.5f, 0.0f, // links
		0.0f, -0.5f, 0.0f, // rechts
		-0.45f, 0.5f, 0.0f, //oben


		// x	y		z         //Zweiter Dreieck
		0.0f, -0.5f, 0.0f, // links
		+0.9f, -0.5f, 0.0f, // rechts
		+0.45f, 0.5f, 0.0f //oben
	};

	glGenVertexArrays(1, &iVAO); //-> Erstellt das VertexArrayObject und speichert auf der angegeben ADRESSE(&)
	glGenBuffers(1, &iVBO); //-> Erstellt das VertexBufferObject 

	glBindVertexArray(iVAO); //-> Object an opengl übergeben
	glBindBuffer(GL_ARRAY_BUFFER, iVBO); //-> Angabe dass es ein Array Buffer ist und an BufferObject übergeben
	glBufferData(GL_ARRAY_BUFFER, sizeof(verticesArr), verticesArr, GL_STATIC_DRAW);      //-> Größe des Buffers angeben, welche Daten haben wir //->Static Draw wenn sich daten selten änjdern

	//Attribute eines VertexPointer definieren // 0-> Anfang der Position /3-> 3 Koordinaten /gl float ->Datentyp/gl -> werte werden nicht normalisiert
	// 3 * sizeof(float) Werte folgen direkt aufeinander //void* ->Zeiger an den Anfang des Arrays um da zu beginnen
	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 3 * sizeof(float), (void*)0);
	glEnableVertexAttribArray(0); //->Attribut mit dem index 0 aktivieren

	//Bindungen wieder aufheben um sicherzustellen dass es nicht zur Laufzeit geändert wird
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	glBindVertexArray(0);
	return 0;
}

int CEngine::Run(void)
{
	while (!glfwWindowShouldClose(m_pViewport->GetWindow()))
	{
		if (m_pViewport != nullptr) PROVE_RESULT(m_pViewport->Update());
		if (m_pMaterial != nullptr) PROVE_RESULT(m_pMaterial->Update());
		if (m_pMesh != nullptr) PROVE_RESULT(m_pMesh->Update());

		glUseProgram(iShaderProgram); //->Programm starten
		glBindVertexArray(iVAO); //->Übertragen des ArrayObjects an OpenGL
		
		glDrawArrays(GL_TRIANGLES, 0, 6); //->Objekt besteht aus Dreiecken, bei 0 starten und es gibt insgesamt 6

		if (m_pViewport != nullptr) PROVE_RESULT(m_pViewport->Draw());
		if (m_pMaterial != nullptr) PROVE_RESULT(m_pMaterial->Draw());
		if (m_pMesh != nullptr) PROVE_RESULT(m_pMesh->Draw());
		
		if (m_pViewport != nullptr) PROVE_RESULT(m_pViewport->LateDraw());
	}
	return 0;
}

void CEngine::Finalize(void)
{

	glDeleteVertexArrays(1, &iVAO);
	glDeleteBuffers(1, &iVBO);
	FINALIZE_DELETE(m_pMesh);
	FINALIZE_DELETE(m_pMaterial);
	glDeleteProgram(iShaderProgram);
	FINALIZE_DELETE(m_pViewport);
}
