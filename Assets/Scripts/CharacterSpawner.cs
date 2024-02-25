using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject characterPrefab; // Reference to your character prefab
    public NewMapGenerator mapGenerator; // Reference to your map generator script

    void Start()
    {
        // Get reference to the map generator script
        mapGenerator = FindObjectOfType<NewMapGenerator>();

        // Ensure mapGenerator is not null
        if (mapGenerator == null)
        {
            Debug.LogError("MapGenerator script not found!");
            return;
        }



        // Spawn character on a grass tile
        SpawnCharacterOnGrassTile();
    }

    void SpawnCharacterOnGrassTile()
    {
        // Get the dimensions of the map
        int width = mapGenerator.width;
        int height = mapGenerator.height;

        // Find a random grass tile
        int x, y;
        do
        {
            x = Random.Range(0, width);
            y = Random.Range(0, height);
        } while (!mapGenerator.IsGrassTile(x, y));

        // Get the world position of the chosen grass tile
        Vector3 spawnPosition = new Vector3(x, y, 0);

        // Spawn the character at the chosen position
        Instantiate(characterPrefab, spawnPosition, Quaternion.identity);
    }
}
