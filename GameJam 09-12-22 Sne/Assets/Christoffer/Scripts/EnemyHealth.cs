using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;

    void Start()
    {
        health = maxHealth;
    }


    void Update()
    {
        
    }

    public void Damage (float dmg)
    {
        health -= dmg;
        if (health <= Mathf.Epsilon)
        {
            this.gameObject.SetActive(false);
        }
    }
}
