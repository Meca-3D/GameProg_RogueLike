using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float moveSpeedStat;
    public float maxHealthStat;
    
    public float fireRate;
    public float damage;

    public float bulletSpeed;
    public float bulletSpread;
    public int bulletAmount;

    public float bulletLifeTime;

    public float xpMultiplier;

    public float xp;
    public float lvlUpRequirement;
    public float level;

    public float requirementIncrease;

    public void GainXp(float gainedXp)
    {
        xp += gainedXp * (1 + xpMultiplier);

        if (xp >= lvlUpRequirement)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        xp = 0;
        level += 1;
        lvlUpRequirement += requirementIncrease;

        requirementIncrease += level * 5;
    }
}
