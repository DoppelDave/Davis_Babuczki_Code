using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

[CreateAssetMenu(fileName = "new TerrainData", menuName = "TerrainData")]
public class TerrainData : ScriptableObject
{
    #region Plane Settings
    [SerializeField]
    private int mapWidth = 1;
    [SerializeField]
    private int mapHeight = 1;
    [SerializeField]
    private float heightMultiplier = 100;

    public int MapWidth { get => mapWidth;  set => mapWidth = value; }
    public int MapHeight { get => mapHeight;  set => mapHeight = value; }
    public float HeightMultiplier { get => heightMultiplier;  set => heightMultiplier = value; }
    #endregion
    #region Noise Settings
    [SerializeField]
    private float noiseScale;
    [SerializeField]
    private int octaves;
    [SerializeField]
    private float persistance;
    [SerializeField]
    private float lacunarity;
    [SerializeField]
    private Vector2 offset;
    [SerializeField]
    private int seed;

    public float NoiseScale { get => noiseScale;  set => noiseScale = value; }
    public int Octaves { get => octaves;  set => octaves = value; }
    public float Persistance { get => persistance;  set => persistance = value; }
    public float Lacunarity { get => lacunarity;  set => lacunarity = value; }
    public Vector2 Offset { get => offset;  set => offset = value; }
    public int Seed { get => seed;  set => seed = value; }
    #endregion   
    #region Terrain Settings
    [SerializeField]
    private TerrainRegion[] regions;
    [SerializeField]
    private AnimationCurve heightCurve;
    [SerializeField]
    private bool useBorder;
    [SerializeField]
    private bool useInvertBorder;
    [SerializeField]
    private float borderMultiplikator = 0.2f;

    public TerrainRegion[] Regions { get => regions;  set => regions = value; }
    public AnimationCurve HeightCurve { get => heightCurve;  set => heightCurve = value; }
    public bool UseBorder { get => useBorder;  set => useBorder = value; }
    public bool UseInvertBorder { get => useInvertBorder;  set => useInvertBorder = value; }
    public float BorderMultiplikator { get => borderMultiplikator;  set => borderMultiplikator = value; }
    #endregion

    public Material terrainMaterial;
}
