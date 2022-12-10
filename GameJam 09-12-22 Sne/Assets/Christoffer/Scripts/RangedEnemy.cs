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

    [SerializeField]
    EnemyHealth healthScript;

    private void OnEnable()
    {
        transform.position = new Vector2(Random.Range(-10, 10), -6);
    }

    void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        rSpeed = speed * Random.Range(0.95f, 1.05f);

        healthScript = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = (playerTrans.position - this.transform.position).normalized;
        if (Mathf.Abs(playerTrans.position.x - this.transform.position.x) > 4f || Mathf.Abs(playerTrans.position.y - this.transform.position.y) > 4f)
            rb2D.AddForce(direction * rSpeed);

        else if (Mathf.Abs(playerTrans.position.x - this.transform.position.x) < 2.5f && Mathf.Abs(playerTrans.position.y - this.transform.position.y) < 2.5f)
            rb2D.AddForce(-direction * rSpeed / 1.5f);

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
            healthScript.EnemyDie();
        }
    }
}
