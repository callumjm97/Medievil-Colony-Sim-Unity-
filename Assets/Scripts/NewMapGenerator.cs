using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMapGenerator : MonoBehaviour
{
    public int width;
    public int height;
    public float scale;
    public GameObject treePrefab;
    public float treeDensity;

    public GameObject[] terrainTiles;

    private bool[,] grassTiles;

    void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xCoord = (float)x / width * scale;
                float yCoord = (float)y / height * scale;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);

                // Adjust the threshold values to prioritize grass
                if (sample < 0.2f) // Water threshold
                {
                    Instantiate(terrainTiles[0], new Vector3(x, y, 0), Quaternion.identity); // Water
                }
                else if (sample < 0.3f) // Sand threshold
                {
                    Instantiate(terrainTiles[1], new Vector3(x, y, 0), Quaternion.identity); // Sand
                }
                else // Grass (higher priority)
                {
                    grassTiles[x, y] = true;

                    Instantiate(terrainTiles[2], new Vector3(x, y, 0), Quaternion.identity); // Grass

                    // Place trees on grass tiles based on density
                    if (Random.value < treeDensity)
                    {
                        // Adjust Z position to place trees above grass tiles
                        Instantiate(treePrefab, new Vector3(x, y, -1), Quaternion.identity);
                    }
                }
            }
        }
    }

    // Method to check if a tile is grassy
    public bool IsGrassTile(int x, int y)
    {
        return grassTiles[x, y];
    }
}
