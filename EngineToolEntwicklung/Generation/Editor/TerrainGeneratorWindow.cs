using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEditor.PackageManager.UI;
using System;
using System.Drawing;

namespace Generation
{
    public class TerrainGeneratorWindow : EditorWindow
    {
        private static TerrainGeneratorWindow window;
        private TerrainGeneratorController controller;
        private TabDrawer tab;
        private Vector2 scrollPosition;
        private bool autoGenerate = true;


        #region PresetTerrain
        private bool islandToggle = false;
        private bool desertToggle = false;
        private bool arcticToggle = false;
        #endregion
        #region CustomTerrain
        private int mapWith;
        private int mapHeight;
        private float heightMultiplier;
        private float noiseScale;
        private int octaves;
        private float persistance;
        private float lacunarity;
        private Vector2 offset;
        private int seed;
        private int regionsAmount;
        private TerrainRegion[] regions;
        private AnimationCurve heightCurve;
        #endregion

        [MenuItem("Tools/TerrainGenerator")]
        private static void ShowWindow()
        {
            window = (TerrainGeneratorWindow)EditorWindow.GetWindow(typeof(TerrainGeneratorWindow)); ;
            window.titleContent = new GUIContent("Terrain Generator");

            window.minSize = new Vector2(500, 500);
            window.maxSize = new Vector2(1000, 1000);
        }
        private void OnGUI()
        {

            tab.DrawTabs();

            

            switch (tab.CurrentlySelectedTab)
            {
                case Tabs.CustomTerrain:

                    EditorGUILayout.Space(20);
                    autoGenerate = EditorGUILayout.Toggle("Auto Generate Terrain", autoGenerate);
                    EditorGUILayout.Space(20);

                    scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
                    CustomEditor();
                    
                    EditorGUILayout.EndScrollView();

                    if (GUI.Button(new Rect((window.position.width / 2) - 60, window.position.height - 50, 120, 40), "Generate Terrain"))
                    {
                        controller.GenerateCustomTerrain(mapHeight, mapWith, heightMultiplier, noiseScale, octaves, persistance, lacunarity, seed, regions, heightCurve);
                    }

                    if(autoGenerate && GUI.changed)
                    {
                        controller.GenerateCustomTerrain(mapHeight, mapWith, heightMultiplier, noiseScale, octaves, persistance, lacunarity, seed, regions, heightCurve);
                    }
                    break;
                case Tabs.PresetTerrain:
                    

                    islandToggle = (EditorGUILayout.Toggle("Island", islandToggle));
                    desertToggle = (EditorGUILayout.Toggle("Desert", desertToggle));
                    arcticToggle = (EditorGUILayout.Toggle("Arctic", arcticToggle));
                    UpdateToggles();

                    if (GUI.Button(new Rect((window.position.width / 2) - 60, window.position.height - 50, 120, 40), "Generate Terrain"))
                    {
                        if (islandToggle)
                        {
                            controller.GenerateTerrain(0);
                        }
                        else if (desertToggle)
                        {
                            controller.GenerateTerrain(1);
                        }
                        else if (arcticToggle)
                        {
                            controller.GenerateTerrain(2);
                        }                       
                    }

                    break;
            }            
        }
        private void OnEnable()
        {
            controller = new TerrainGeneratorController();
            tab = new TabDrawer();
            heightCurve = new AnimationCurve();
            regionsAmount = 1;
            regions = new TerrainRegion[regionsAmount];
            regions[0] = new TerrainRegion();
        }
        private void UpdateToggles()
        {
            if (islandToggle)
            {
                desertToggle = false;
                arcticToggle = false;
            }

            if (desertToggle)
            {
                islandToggle = false;
                arcticToggle = false;
            }

            if (arcticToggle)
            {
                islandToggle = false;
                desertToggle = false;
            }
        }
        private void CustomEditor()
        {
            mapWith = EditorGUILayout.IntSlider("Map Width", mapWith,10,200);
            mapHeight = EditorGUILayout.IntSlider("Map Width", mapHeight, 10, 200);
            heightMultiplier = EditorGUILayout.FloatField("Height Multiplier", heightMultiplier);
            EditorGUILayout.HelpBox("How high should the terrain be?", MessageType.Info);
            noiseScale = EditorGUILayout.FloatField("Noise Scale", noiseScale);
            EditorGUILayout.HelpBox("How much Bumbs should the terrain have?", MessageType.Info);
            octaves = EditorGUILayout.IntSlider("Octaves", octaves,1,6);
            EditorGUILayout.HelpBox("How much Detail should the terrain have", MessageType.Info);
            persistance = EditorGUILayout.Slider("Persitance", persistance,0.2f,0.6f);
            lacunarity = EditorGUILayout.Slider("Lacunatiry", lacunarity, 2,4);
            seed = EditorGUILayout.IntField("Seed", seed);
            heightCurve = EditorGUILayout.CurveField("HeightCurve", heightCurve);

            EditorGUILayout.Space(50);
            regionsAmount = EditorGUILayout.IntSlider("Regions", regions.Length, 1, 20);
            

            if(regionsAmount!= regions.Length)
            {
                Array.Resize(ref regions, regionsAmount);
            }

            for (int i = 0; i < regions.Length; i++)
            {               
                GUILayout.Label("Terrain Region " + i, EditorStyles.boldLabel);

                regions[i].name = EditorGUILayout.TextField("Name", regions[i].name);
                regions[i].height = EditorGUILayout.FloatField("Height", regions[i].height);
                regions[i].color = EditorGUILayout.ColorField("Color", regions[i].color);

                EditorGUILayout.Space(20);
            }

          
        }
    }
}

