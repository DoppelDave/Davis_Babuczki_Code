using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generation
{
    public static class PlaneGenerator
    {
        public static Mesh InstantiatePlane(Mesh mesh, int mapWidth, int mapHeight)
        {
            if (mesh == null) return null;

            Vector3[] verts = new Vector3[mapWidth * mapHeight];
            Vector2[] uvs = new Vector2[verts.Length];

            int[] tris = new int[(mapWidth - 1) * (mapHeight - 1) * 2 * 3];

            Vector3 startPos = (Vector3.left + Vector3.back) * 0.5f;


            int triIdx = 0;

            for (int y = 0, i = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++, i++)
                {
                    Vector2 percent = new Vector2((float)x / (mapWidth - 1), (float)y / (mapHeight - 1));

                    Vector3 vertPos = startPos + (Vector3.right * percent.x + Vector3.forward * percent.y);

                    verts[i] = vertPos;

                    uvs[i] = new Vector2(percent.x, percent.y);

                    if (x < mapWidth - 1 && y < mapHeight - 1)
                    {
                        //Vertex kann ein Quad generieren!
                        tris[triIdx + 0] = i;
                        tris[triIdx + 1] = i + mapWidth;
                        tris[triIdx + 2] = i + mapWidth + 1;

                        tris[triIdx + 3] = i;
                        tris[triIdx + 4] = i + mapWidth + 1;
                        tris[triIdx + 5] = i + 1;

                        //+6 weil wir 6 neue Indices hinzugefügt haben
                        triIdx += 6;
                    }

                }
            }

            mesh.Clear();
            mesh.vertices = verts;
            mesh.uv = uvs;
            mesh.triangles = tris;
            mesh.RecalculateNormals();

            return mesh;
        }
    }
}