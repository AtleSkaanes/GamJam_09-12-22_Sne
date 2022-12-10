using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;

    EnemyObjectPool objectPool;

    private void OnEnable ()
    {
        health = maxHealth;
    }

    void Start()
    {
        objectPool = GameObject.FindGameObjectWithTag("ObjectPool").GetComponent<EnemyObjectPool>();
    }


    void Update()
    {

    }

    public void Damage (float dmg)
    {
        health -= dmg;
        if (health <= Mathf.Epsilon)
        {
            EnemyDie();
        }
    }

    public void EnemyDie()
    {
        this.gameObject.SetActive(false);
        objectPool.inactiveRangedEnemyPool.Add(this.gameObject);
        objectPool.activeRangedEnemyPool.Remove(this.gameObject);
    }
}
