using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    [Range(20, 1000)]
    public float torque;

    public float velocity;
    [SerializeField] float prevRotation;
    [SerializeField] float currentRotation;
    [SerializeField] float damage = 10f;


    Rigidbody2D rb;
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CalculateRotation();

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log(damage);
        //}
    }

    private void FixedUpdate()
    {
        CalculateVelocity();
    }

    void CalculateRotation()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 objectPos = transform.position;

        Vector2 diffrence = mousePos - objectPos;

        float angle = Mathf.Atan2(diffrence.y, diffrence.x) * Mathf.Rad2Deg - 90;

        transform.rotation = Quaternion.Euler(0, 0, angle);


        //float deltaAngle = rb.rotation - angle;

        //deltaAngle = (deltaAngle - 360 * Mathf.Floor(deltaAngle / 360)) * deltaAngle / Mathf.Abs(deltaAngle);

        //deltaAngle = Mathf.Abs(deltaAngle) % 360 - 180;

        

        //rb.AddTorque(deltaAngle / 2 * Time.deltaTime);
    }

    void CalculateVelocity()
    {
        currentRotation = transform.rotation.z;
        velocity = Mathf.Abs(currentRotation - prevRotation);
        prevRotation = transform.rotation.z;

        if (velocity >= 0.05)
        {
            damage = 5 + velocity * 2;
        }
        else { damage = 0; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().Damage(damage);
            //Debug.Log(collision.gameObject.GetComponent<EnemyHealth>().health);

        }
    }
}
