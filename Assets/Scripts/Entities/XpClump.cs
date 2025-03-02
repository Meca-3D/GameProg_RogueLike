using System;
using UnityEngine;

public class XpClump : MonoBehaviour
{
    public float heldXp;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerStats>().transform;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, 10 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
        {
            playerStats.GainXp(heldXp);
            Destroy(gameObject);
        }
    }
}
