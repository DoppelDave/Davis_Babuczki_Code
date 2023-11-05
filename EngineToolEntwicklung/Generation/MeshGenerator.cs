using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

namespace Generation
{
    public class MeshGenerator
    {
        #region Components
        private MeshRenderer meshRenderer;
        private MeshFilter meshFilter;
        private Mesh mesh;
        #endregion
        #region Arrays
        private float[,] border;
        private float[,] noiseMap;
        #endregion
        private GameObject terrainObject;
        private TerrainData terrainData;
        //public async void GenerateTerrain(TerrainData data)
        //{
        //    terrainData = data;
        //    DeleteTerrain();
        //    GenerateGameObject();
        //    GenerateMesh();
        //    GeneratePlane();
        //    await GenerateNoiseAsync();
        //}

        public void GenerateTerrain(TerrainData data)
        {
            terrainData = data;
            DeleteTerrain();
            GenerateGameObject();
            GenerateMesh();
            GeneratePlane();
            GenerateNoise();
        }
        public void DeleteTerrain()
        {
            GameObject.DestroyImmediate(terrainObject);
        }
        private void GenerateGameObject()
        {
            if (terrainObject == null)
            {
                terrainObject = new GameObject("Terrain");
                terrainObject.transform.position = new Vector3(0, 0, 0);
                meshFilter = terrainObject.AddComponent<MeshFilter>();
                meshRenderer = terrainObject.AddComponent<MeshRenderer>();
                terrainObject.AddComponent<MeshCollider>();
            }
            return;
        }
        private void GenerateMesh()
        {
            if (mesh == null)
            {
                mesh = new Mesh();
                mesh.name = "Plane";
            }
            meshFilter.sharedMesh = mesh;
            meshRenderer.material = terrainData.terrainMaterial;
        }
        private void GeneratePlane()
        {
            PlaneGenerator.InstantiatePlane(mesh,terrainData.MapWidth, terrainData.MapHeight);
            meshRenderer.transform.localScale = new Vector3(terrainData.MapWidth, 1, terrainData.MapHeight);
        }
        private async Task GenerateNoiseAsync()
        {
            noiseMap = await NoiseGenerator.GenerateNoiseMapAsync(terrainData.MapWidth, terrainData.MapHeight, terrainData.Seed, terrainData.NoiseScale, terrainData.Octaves, terrainData.Persistance, terrainData.Lacunarity, terrainData.Offset);
            


            if (terrainData.UseBorder)
            {
                if (border == null)
                {
                    border = await BorderGenerator.GenerateBorderAsync(terrainData.MapWidth, terrainData.MapHeight);
                }

                if (terrainData.UseInvertBorder)
                {
                    for (int y = 0, i = 0; y < terrainData.MapHeight; y++)
                    {
                        for (int x = 0; x < terrainData.MapWidth; x++, i++)
                        {
                            noiseMap[x, y] = Mathf.Clamp01(noiseMap[x, y] + (border[x, y] * terrainData.BorderMultiplikator));
                        }
                    }
                }
                else if (!terrainData.UseInvertBorder)
                {
                    for (int y = 0, i = 0; y < terrainData.MapHeight; y++)
                    {
                        for (int x = 0; x < terrainData.MapWidth; x++, i++)
                        {
                            noiseMap[x, y] = Mathf.Clamp01(noiseMap[x, y] - (border[x, y] * terrainData.BorderMultiplikator));
                        }
                    }
                }
            }

            GeneratePlane();


            DrawColorMap();
            //DrawNoiseMap();
            UpdateHeight();
        }

        private void GenerateNoise()
        {
          
            noiseMap = NoiseGenerator.GenerateNoiseMap(terrainData.MapWidth, terrainData.MapHeight, terrainData.Seed, terrainData.NoiseScale, terrainData.Octaves, terrainData.Persistance, terrainData.Lacunarity, terrainData.Offset);

            if (terrainData.UseBorder)
            {
                if (border == null)
                {
                    border = BorderGenerator.GenerateBorder(terrainData.MapWidth, terrainData.MapHeight);
                }

                if (terrainData.UseInvertBorder)
                {
                    for (int y = 0, i = 0; y < terrainData.MapHeight; y++)
                    {
                        for (int x = 0; x < terrainData.MapWidth; x++, i++)
                        {
                            noiseMap[x, y] = Mathf.Clamp01(noiseMap[x, y] + (border[x, y] * terrainData.BorderMultiplikator));
                        }
                    }
                }
                else if (!terrainData.UseInvertBorder)
                {
                    for (int y = 0, i = 0; y < terrainData.MapHeight; y++)
                    {
                        for (int x = 0; x < terrainData.MapWidth; x++, i++)
                        {
                            noiseMap[x, y] = Mathf.Clamp01(noiseMap[x, y] - (border[x, y] * terrainData.BorderMultiplikator));
                        }
                    }
                }
            }

            GeneratePlane();


            DrawColorMap();
            //DrawNoiseMap();
            UpdateHeight();
        }
        private void DrawNoiseMap()
        {
            //Setzen der Größe anhand der NoiseMap
            int width = noiseMap.GetLength(0);
            int height = noiseMap.GetLength(1);

            Texture2D texture = new Texture2D(width, height);

            texture.wrapMode = TextureWrapMode.Clamp;
            texture.filterMode = FilterMode.Point;

            Color[] colorMap = new Color
                [width * height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
                }
            }

            texture.SetPixels(colorMap);
            texture.Apply();
            meshRenderer.sharedMaterial.mainTexture = texture;
        }
        private void DrawColorMap()
        {
            int width = noiseMap.GetLength(0);
            int height = noiseMap.GetLength(1);

            Texture2D texture = new Texture2D(width, height);


            Color[] colorMap = new Color[terrainData.MapWidth * terrainData.MapHeight];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float currentHeight = noiseMap[x, y];
                    for (int i = 0; i < terrainData.Regions.Length; i++)
                    {
                        if (currentHeight <= terrainData.Regions[i].height)
                        {
                            colorMap[y * width + x] = terrainData.Regions[i].color;
                            break;
                        }
                    }
                }
            }

            texture.SetPixels(colorMap);
            texture.Apply();
            meshRenderer.sharedMaterial.mainTexture = texture;
        }
        private void UpdateHeight()
        {
            if (mesh == null) return;

            Vector3[] verts = mesh.vertices;

            for (int y = 0, i = 0; y < terrainData.MapHeight; y++)
            {
                for (int x = 0; x < terrainData.MapWidth; x++, i++)
                {
                    float height = noiseMap[x, y];

                    verts[i].y = height * terrainData.HeightMultiplier * terrainData.HeightCurve.Evaluate(noiseMap[x, y]);
                }
            }

            mesh.vertices = verts;
            mesh.RecalculateNormals();
        }
    }
}

