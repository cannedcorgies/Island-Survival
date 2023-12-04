using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRandom : MonoBehaviour
{
    public GameObject objectPrefab; // Assign your prefab in the Inspector
    public int numberOfObjects = 10;
    public Terrain terrain;

    void Start()
    {
        if (objectPrefab == null || terrain == null)
        {
            Debug.LogError("Prefab or Terrain not assigned!");
            return;
        }

        SpawnObjects();
    }

    void SpawnObjects()
    {
        TerrainData terrainData = terrain.terrainData;

        for (int i = 0; i < numberOfObjects; i++)
        {
            float randX = Random.Range(0f, terrainData.size.x);
            float randZ = Random.Range(0f, terrainData.size.z);
            Vector3 randPos = new Vector3(randX, 0f, randZ);

            // Get the terrain height at the random position
            float terrainHeight = terrain.SampleHeight(randPos);

            // Adjust Y position to place the object on the terrain
            randPos.y = terrainHeight;

            Instantiate(objectPrefab, randPos, Quaternion.identity);
        }
    }
}
