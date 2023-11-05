#include "Mesh.h"
#include <glad/glad.h>
#include <GLFW/glfw3.h>
#include <iostream>
#include "ErrorTypes.h"

using namespace std;

//Buffer
//unsigned int iVBO = 0; //-> VertexBufferObject: Vertexdaten wie Position, Farbe und Texturkoordinate an Grafikspeicherübertragen
//unsigned int iVAO = 0; //-> IndexBuffer: //VertexArrayObject : Indexdaten zu speichern. Indizes zeigen auf im VBO gespeicherten Vertices um Primitives zu esrtllen

const int CMesh::Initialize(void)
{
	////Mesh 
	//->Koordinaten des Meshes
	//float verticesArr[] = {
	//	// x	y		z    //Erstes Dreieck
	//	-0.9f, -0.5f, 0.0f, // links
	//	0.0f, -0.5f, 0.0f, // rechts
	//	-0.45f, 0.5f, 0.0f, //oben


	//	// x	y		z         //Zweiter Dreieck
	//	0.0f, -0.5f, 0.0f, // links
	//	+0.9f, -0.5f, 0.0f, // rechts
	//	+0.45f, 0.5f, 0.0f //oben
	//};

	//glGenVertexArrays(1, &iVAO); //-> Erstellt das VertexArrayObject und speichert auf der angegeben ADRESSE(&)
	//glGenBuffers(1, &iVBO); //-> Erstellt das VertexBufferObject 

	//glBindVertexArray(iVAO); //-> Object an opengl übergeben
	//glBindBuffer(GL_ARRAY_BUFFER, iVBO); //-> Angabe dass es ein Array Buffer ist und an BufferObject übergeben
	//glBufferData(GL_ARRAY_BUFFER, sizeof(verticesArr), verticesArr, GL_STATIC_DRAW);      //-> Größe des Buffers angeben, welche Daten haben wir //->Static Draw wenn sich daten selten änjdern

	////Attribute eines VertexPointer definieren // 0-> Anfang der Position /3-> 3 Koordinaten /gl float ->Datentyp/gl -> werte werden nicht normalisiert
	//// 3 * sizeof(float) Werte folgen direkt aufeinander //void* ->Zeiger an den Anfang des Arrays um da zu beginnen
	//glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 3 * sizeof(float), (void*)0);
	//glEnableVertexAttribArray(0); //->Attribut mit dem index 0 aktivieren

	////Bindungen wieder aufheben um sicherzustellen dass es nicht zur Laufzeit geändert wird
	//glBindBuffer(GL_ARRAY_BUFFER, 0);
	//glBindVertexArray(0);

    return 0;
}

void CMesh::Finalize(void)
{
	/*glDeleteVertexArrays(1, &iVAO);
	glDeleteBuffers(1, &iVBO);*/
}

const int CMesh::Update(void)
{
	//glBindVertexArray(iVAO); //->Übertragen des ArrayObjects an OpenGL
	//glDrawArrays(GL_TRIANGLES, 0, 6); //->Objekt besteht aus Dreiecken, bei 0 starten und es gibt insgesamt 6

    return 0;
}

const int CMesh::Draw(void)
{
    return 0;
}
