using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform playerTrans;

    public float bulletSpeed = 2f;

    public float damage = 5f;

    Vector3 direction;

    float time = 0f;

    private void Awake ()
    {
        playerTrans = GameObject.FindWithTag("Player").transform;
        direction = (playerTrans.position - this.transform.position).normalized;
    }

    void Update()
    {
        this.transform.position += direction * bulletSpeed * Time.deltaTime;

        time += Time.deltaTime;
        if (time > 10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerCombat>().Damage(damage);
            Destroy(this.gameObject);
        }
    }
}
