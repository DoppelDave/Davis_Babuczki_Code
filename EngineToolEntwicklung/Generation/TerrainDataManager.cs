using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TerrainDataManager
{
    private List<TerrainData> dataList = new List<TerrainData>();

    private void OnEnable()
    {
     
    }

    public void LoadDataFromFolder()
    {
        string[] guids = AssetDatabase.FindAssets("t: TerrainData", new[] { "Assets/Scripts/Generation/ScriptableObjects" });

        foreach (string assetGuid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(assetGuid);
            TerrainData data = AssetDatabase.LoadAssetAtPath<TerrainData>(assetPath);
            if(data != null)
            {
                dataList.Add(data);
            }
        }
    }

    public TerrainData GetDataAtIndex(int index)
    {
        if(index >= 0 && index < dataList.Count)
        {
            return dataList[index];
        }
        else
        {
            Debug.LogWarning("Invalid data index.");
            return null;
        }
    }
}
