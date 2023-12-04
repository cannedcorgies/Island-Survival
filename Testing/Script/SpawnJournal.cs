using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnJournal : MonoBehaviour
{
    public GameObject journalPrefab; // Assign your journal prefab in the Inspector
    public int numberOfJournals = 10;
    public Terrain terrain;
    public float aboveGroundOffset = 1.5f; // Adjust this value to set the height above the terrain

    void Start()
    {
        if (journalPrefab == null || terrain == null)
        {
            Debug.LogError("Prefab or Terrain not assigned!");
            return;
        }

        SpawnJournals();
    }

    void SpawnJournals()
    {
        TerrainData terrainData = terrain.terrainData;

        for (int i = 0; i < numberOfJournals; i++)
        {
            float randX = Random.Range(0f, terrainData.size.x);
            float randZ = Random.Range(0f, terrainData.size.z);
            Vector3 randPos = new Vector3(randX, 0f, randZ);

            // Get the terrain height at the random position
            float terrainHeight = terrain.SampleHeight(randPos);

            // Adjust Y position to place the journal above the terrain
            Vector3 spawnPos = new Vector3(randPos.x, terrainHeight + aboveGroundOffset, randPos.z);

            Instantiate(journalPrefab, spawnPos, Quaternion.identity);
        }
    }
}
