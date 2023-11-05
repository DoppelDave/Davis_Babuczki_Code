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
        /// <param name="mapHeight">Höhe der Map</param>
        /// <param name="scale">Skalierung der Noisestärke</param>
        /// <param name="octaves">Steuert wieviele Schichten kombiniert werden für komplexere Muster(4-8)</param>
        /// <param name="persistance">Abschwächungsfaktor: kontrolliert wie stark die Intensität der Noisewerte zwischen Oktaven abnimmt(0.2-0.5 für sanfte Übergänge/ 0.6-0.9 für raue Übergänge)</param>
        /// <param name="lacunarity">kontrolliert wie stark die Frequenz von Oktave zu Oktave erhöht wird(2-4)</param>
        /// <returns></returns>
        public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset)        
        {
            //2D Array mit Höhe und Breite erstellt
            float[,] noiseMap = new float[mapWidth, mapHeight];

#pragma warning disable SecurityIntelliSenseCS // MS Security rules violation
            System.Random rnd = new System.Random(seed);
#pragma warning restore SecurityIntelliSenseCS // MS Security rules violation

            Vector2[] octaveOffsets = new Vector2[octaves];
            for (int i = 0; i < octaves; i++)
            {
                //Eingrenzen des Bereichs da PerlinNoise darüberhinaus gleiche Werte zurückgibt
                float offsetX = rnd.Next(-100000, 100000);
                float offsetY = rnd.Next(-100000, 100000);
                octaveOffsets[i] = new Vector2(offsetX, offsetY);
            }

            //Setzen des Skalars um Division mit 0 zu verhindern
            if (scale <= 0)
                scale = 0.0001f;

            //Initialisieren der min/max Werte, in dem Bereich, dass sie sicher überschrieben werden
            float maxNoiseHeight = float.MinValue;
            float minNoiseHeight = float.MaxValue;

            //Zentrieren der NoiseMap in die Mitte
            float halfWidth = mapWidth / 2f;
            float halfHeight = mapHeight / 2f;


            //Erstellen des NoiseValues für jeden Punkt im Array durch die PerlinNoise Methode
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    float amplitude = 1;
                    float frequency = 1;
                    float noiseHeight = 0;

                    //Einstellung durch Oktaven, mehr Berechnungen durchzuführen
                    for (int i = 0; i < octaves; i++)
                    {
                        //Teilen durch den Skalar um Noise beeinflussen zu können und einfügen des Offsets
                        float sampleX = (x - halfWidth + offset.x) / scale * frequency + octaveOffsets[i].x;
                        float sampleY = (y - halfHeight + offset.y) / scale * frequency + octaveOffsets[i].y;

                        //2-1 to gain more randomness
                        float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;

                        //Rückgabe des NoiseValues für den jeweiligen Punkt im 2D Array
                        noiseMap[x, y] = perlinValue;
                        noiseHeight += perlinValue * amplitude;

                        //Intensität der Oktaven abschwächen
                        amplitude *= persistance;
                        //Frequenz der Oktaven erhöhen
                        frequency *= lacunarity;
                    }

                    //größten NoiseValue erhalten
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
