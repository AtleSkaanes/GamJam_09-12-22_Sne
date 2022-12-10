using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [HideInInspector]
    public bool canMove = true;
    public float speed = 1.5f;
    public float attackSpeed = 2f;

    Transform playerTrans;
    [SerializeField]
    GameObject bullet;
    public Rigidbody2D rb2D;

    Vector2 direction;

    private float rSpeed;
    private float time = 0f;

    void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        rSpeed = speed * Random.Range(0.95f, 1.05f);
    }

    // Update is called once per frame
    void Update()
    {
        direction = (playerTrans.position - this.transform.position).normalized;
        if (Mathf.Abs(playerTrans.position.x - this.transform.position.x) > 4f || Mathf.Abs(playerTrans.position.y - this.transform.position.y) > 4f)
            rb2D.AddForce(direction * rSpeed);
        
        time += Time.deltaTime;

        if (time > attackSpeed)
        {
            Instantiate(bullet, this.transform.position, new Quaternion());
            time = 0;
        }
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //do damage to player here
            Destroy(this.gameObject);
        }
    }
}
