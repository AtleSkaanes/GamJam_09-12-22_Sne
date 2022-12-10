using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{

    public int numOfSucicideEnemies;
    public int numOfRangedEnemies;

    public GameObject suicideEnemy;
    public GameObject rangedEnemy;

    List<GameObject> activeSuicideEnemyPool;
    List<GameObject> inactiveSuicideEnemyPool;

    List<GameObject> activeRangedEnemyPool;
    List<GameObject> inactiveRangedEnemyPool;


    void Start()
    {
        activeSuicideEnemyPool = new List<GameObject>();
        inactiveSuicideEnemyPool = new List<GameObject>();

        activeRangedEnemyPool = new List<GameObject>();
        inactiveRangedEnemyPool = new List<GameObject>();



        PopulateSuicideEnemies(numOfSucicideEnemies);
        PopulateRangedEnemies(numOfRangedEnemies);
    }

    void Update()
    {

    }

    void PopulateSuicideEnemies(int num)
    {
        for (int i = 0; i < num; i++)
        {
            inactiveSuicideEnemyPool.Add(Instantiate(suicideEnemy, transform));
            inactiveSuicideEnemyPool[i].SetActive(false);
        }
    }

    void PopulateRangedEnemies(int num)
    {

        for (int i = 0; i < num; i++)
        {
            inactiveRangedEnemyPool.Add(Instantiate(rangedEnemy, transform));
            inactiveRangedEnemyPool[i].SetActive(false);
        }
    }

    public void EnableEnemies(int numOfSuicide, int numOfRanged)
    {
        for (int i = 0; i < numOfSuicide; i++)
        {
            inactiveSuicideEnemyPool[i].SetActive(true);
            activeSuicideEnemyPool.Add(inactiveSuicideEnemyPool[i]);
            inactiveSuicideEnemyPool.RemoveAt(i);
            Debug.Log("Enabled" + i);
        }

        for (int i = 0; i < numOfRanged; i++)
        {
            inactiveRangedEnemyPool[i].SetActive(true);
            activeRangedEnemyPool.Add(inactiveRangedEnemyPool[i]);
            inactiveRangedEnemyPool.RemoveAt(i);
        }
    }
}
