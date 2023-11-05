using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generation
{
    public class TerrainGeneratorController
    {
        private MeshGenerator generator;
        private TerrainDataManager data;
        private TerrainData terrainData;

        public void GenerateTerrain(int index)
        {
            if (generator == null)
                generator = new MeshGenerator();
            if (data == null)
                data = new TerrainDataManager();


            data.LoadDataFromFolder();
            terrainData = data.GetDataAtIndex(index);
            generator.GenerateTerrain(terrainData);
        }

        public void GenerateCustomTerrain
            (int mapHeight, int mapWith, float heightMultiplier, float noiseScale, int octaves, float persistance, float lacunarity, int seed, TerrainRegion[] regions, AnimationCurve heightCurve)
        {
            if (generator == null)
                generator = new MeshGenerator();
            if (data == null)
                data = new TerrainDataManager();

            data.LoadDataFromFolder();
            terrainData = data.GetDataAtIndex(3);
            terrainData.MapHeight = mapHeight;
            terrainData.MapWidth = mapWith;
            terrainData.HeightMultiplier = heightMultiplier;
            terrainData.NoiseScale = noiseScale;
            terrainData.Octaves = octaves;
            terrainData.Seed = seed;
            terrainData.Persistance = persistance;
            terrainData.Lacunarity = lacunarity;
            terrainData.Seed = seed;
            terrainData.Regions = regions;
            terrainData.HeightCurve = heightCurve;
            generator.GenerateTerrain(terrainData);
        }

        
    }
}
