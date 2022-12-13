using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SuicideEnemy : MonoBehaviour
{
    [HideInInspector]
    public bool canMove = true;
    public float speed = 2f;
    public float damage = 10f;

    GameObject player;
    Transform playerTrans;
    PlayerCombat playerCombat;

    public Rigidbody2D rb2D;

    Vector2 direction;

    private float rSpeed;

    EnemyHealth healthScript;

    private void OnEnable()
    {
        transform.position = new Vector2(Random.Range(-10, 10),-6);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.transform;
        //playerCombat = player.GetComponent<PlayerCombat>();

        rSpeed = speed * Random.Range(0.85f, 1.15f);

        healthScript = GetComponent<EnemyHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        direction = (playerTrans.position - this.transform.position).normalized;
        rb2D.AddForce(direction * rSpeed);
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerCombat>().Damage(damage);
            healthScript.EnemyDie();
            Debug.Log(collision.gameObject.name);
        }
    }
}
