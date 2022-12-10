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
    public float healthPoints = 50f;

    public Transform playerTrans;
    public Rigidbody2D rb2D;

    Vector2 direction;

    private float rSpeed;

    void Start()
    {
        rSpeed = speed * Random.Range(0.85f, 1.15f);
    }

    // Update is called once per frame
    void Update()
    {
        direction = (playerTrans.position - this.transform.position).normalized;
        rb2D.AddForce(direction * rSpeed);
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Destroy(this.gameObject);
    }

    void Damage (float dmg)
    {
        healthPoints =- dmg;
        if (healthPoints <= 0)
            Destroy(this.gameObject);
    }
}
