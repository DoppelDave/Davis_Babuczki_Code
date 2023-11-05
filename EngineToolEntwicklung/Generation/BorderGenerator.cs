using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BorderGenerator : MonoBehaviour
{
    public static async Task<float[,]> GenerateBorderAsync(int mapWidth, int mapHeight)
    {
        float[,] borderMap = new float[mapHeight, mapHeight];

        await Task.Run(() =>
        {
            borderMap = GenerateBorder(mapWidth, mapHeight);
        });

        return borderMap;
    }

    public static float[,] GenerateBorder(int mapWidth, int mapHeight)
    {
        float[,] border = new float[mapWidth, mapHeight];

        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                float x = i / (float)mapWidth * 2 - 1;
                float y = j / (float)mapHeight * 2 - 1;

                float value = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y));
                border[i, j] = Evaluate(value);
            }
        }

        return border;
    }

    static float Evaluate(float value)
    {
        float a = 3;
        float b = 2.2f;

        return Mathf.Pow(value, a) / (Mathf.Pow(value, a) + Mathf.Pow(b - b * value, a));
    }
}
