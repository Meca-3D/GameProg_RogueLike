using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawnIndicatorPrefab;
    
    public GameObject[] enmiesToSpawn;

    public float spawnSpeed;
    public int spawnAmount;

    private float defaultSizeX = 14;
    private float defaultSizeY = 14;

    private float sizeX;
    private float sizeY;

    public int enemyMapSize;

    private void Start()
    {
        SetMapSize();
        StartCoroutine(EnemySpawnLoop());
    }

    private IEnumerator EnemySpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnSpeed);
            int randEnmy = Random.Range(0, enmiesToSpawn.Length - 1);
            for (int i = 0; i < spawnAmount; i++)
            {
                GameObject spawnedIndicator = Instantiate(spawnIndicatorPrefab, new Vector3(Random.Range(-sizeX, sizeX), Random.Range(-sizeY, sizeY), 0), transform.rotation);
                spawnedIndicator.GetComponent<EnemySpawnerIndicator>().enemyToSpawn = enmiesToSpawn[randEnmy];
            }
        }
    }

    public void SetMapSize()
    {
        sizeX = defaultSizeY * enemyMapSize;
        sizeY = defaultSizeY * enemyMapSize;
    }
}
