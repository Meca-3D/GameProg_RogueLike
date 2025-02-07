using System;
using UnityEngine;

public class EnemySpawnerIndicator : MonoBehaviour
{
    public float indicatorLenght;
    private Animator anim;

    public GameObject enemyToSpawn;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = indicatorLenght;
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyToSpawn, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
