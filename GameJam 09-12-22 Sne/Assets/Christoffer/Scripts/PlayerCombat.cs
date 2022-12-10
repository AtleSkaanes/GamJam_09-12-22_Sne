using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float maxHealth = 100f;
    float health;

    void Start()
    {
        health = maxHealth;
    }

    public void Damage (float dmg)
    {
        health = -dmg;
        if (health >= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
