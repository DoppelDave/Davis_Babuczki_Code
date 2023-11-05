using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

namespace Generation
{
    public static class NoiseGenerator
    {
        public static async Task<float[,]> GenerateNoiseMapAsync(int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset)
        {
            float[,] noiseMap = new float[mapWidth, mapHeight];

            await Task.Run(() =>
            {
                noiseMap = GenerateNoiseMap(mapWidth, mapHeight, seed, scale, octaves, persistance, lacunarity, offset);
            });

            return noiseMap;
        }
        /// <summary>
        /// Erstellung eines 2D-Arrays mit NoiseValues
        /// </summary>
        /// <param name="mapWidth">Breite der Map</param>
        /// <param name="mapHeight">H�he der Map</param>
        /// <param name="scale">Skalierung der Noisest�rke</param>
        /// <param name="octaves">Steuert wieviele Schichten kombiniert werden f�r komplexere Muster(4-8)</param>
        /// <param name="persistance">Abschw�chungsfaktor: kontrolliert wie stark die Intensit�t der Noisewerte zwischen Oktaven abnimmt(0.2-0.5 f�r sanfte �berg�nge/ 0.6-0.9 f�r raue �berg�nge)</param>
        /// <param name="lacunarity">kontrolliert wie stark die Frequenz von Oktave zu Oktave erh�ht wird(2-4)</param>
        /// <returns></returns>
        public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset)        
        {
            //2D Array mit H�he und Breite erstellt
            float[,] noiseMap = new float[mapWidth, mapHeight];

#pragma warning disable SecurityIntelliSenseCS // MS Security rules violation
            System.Random rnd = new System.Random(seed);
#pragma warning restore SecurityIntelliSenseCS // MS Security rules violation

            Vector2[] octaveOffsets = new Vector2[octaves];
            for (int i = 0; i < octaves; i++)
            {
                //Eingrenzen des Bereichs da PerlinNoise dar�berhinaus gleiche Werte zur�ckgibt
                float offsetX = rnd.Next(-100000, 100000);
                float offsetY = rnd.Next(-100000, 100000);
                octaveOffsets[i] = new Vector2(offsetX, offsetY);
            }

            //Setzen des Skalars um Division mit 0 zu verhindern
            if (scale <= 0)
                scale = 0.0001f;

            //Initialisieren der min/max Werte, in dem Bereich, dass sie sicher �berschrieben werden
            float maxNoiseHeight = float.MinValue;
            float minNoiseHeight = float.MaxValue;

            //Zentrieren der NoiseMap in die Mitte
            float halfWidth = mapWidth / 2f;
            float halfHeight = mapHeight / 2f;


            //Erstellen des NoiseValues f�r jeden Punkt im Array durch die PerlinNoise Methode
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    float amplitude = 1;
                    float frequency = 1;
                    float noiseHeight = 0;

                    //Einstellung durch Oktaven, mehr Berechnungen durchzuf�hren
                    for (int i = 0; i < octaves; i++)
                    {
                        //Teilen durch den Skalar um Noise beeinflussen zu k�nnen und einf�gen des Offsets
                        float sampleX = (x - halfWidth + offset.x) / scale * frequency + octaveOffsets[i].x;
                        float sampleY = (y - halfHeight + offset.y) / scale * frequency + octaveOffsets[i].y;

                        //2-1 to gain more randomness
                        float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;

                        //R�ckgabe des NoiseValues f�r den jeweiligen Punkt im 2D Array
                        noiseMap[x, y] = perlinValue;
                        noiseHeight += perlinValue * amplitude;

                        //Intensit�t der Oktaven abschw�chen
                        amplitude *= persistance;
                        //Frequenz der Oktaven erh�hen
                        frequency *= lacunarity;
                    }

                    //gr��ten NoiseValue erhalten
                    if (noiseHeight > maxNoiseHeight)
                    {
                        maxNoiseHeight = noiseHeight;
                    }
                    //niedrigsten NoiseValue erhalten
                    else if (noiseHeight < minNoiseHeight)
                    {
                        minNoiseHeight = noiseHeight;
                    }
                    //Setzen der NoiseMap mit berechneter NoiseValue
                    noiseMap[x, y] = noiseHeight;
                }
            }

            //Normalisieren der Werte auf 0-1 
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {

                    noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
                }
            }
            return noiseMap;
        }
    }
}
