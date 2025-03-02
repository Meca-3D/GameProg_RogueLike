using System;
using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    public GameObject xpClump;
    public float xpAmount;

    public void DropXp()
    {
        GameObject xpDropped = Instantiate(xpClump, transform.position,transform.rotation);
        xpDropped.GetComponent<XpClump>().heldXp = xpAmount;
    }
    
}
