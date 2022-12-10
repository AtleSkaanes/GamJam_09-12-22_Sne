using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    [Range(20, 1000)]
    public float torque;


    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 objectPos = transform.position;

        Vector2 diffrence = mousePos - objectPos;

        float angle = Mathf.Atan2(diffrence.x, diffrence.y) * Mathf.Rad2Deg;

        float deltaAngle = rb.rotation - angle;

        //deltaAngle = (deltaAngle - 360 * Mathf.Floor(deltaAngle / 360)) * deltaAngle/Mathf.Abs(deltaAngle);

        deltaAngle = Mathf.Abs(deltaAngle) % 360 - 180;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(deltaAngle);
        }

        rb.AddTorque(deltaAngle / 2 * Time.deltaTime);
    }
}
