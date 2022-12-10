using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
<<<<<<< Updated upstream
=======
    Animator anim;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
<<<<<<< Updated upstream
=======
        anim = GetComponent<Animator>();
>>>>>>> Stashed changes
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 relMousePos = new Vector2(mousePos.x-transform.position.x,mousePos.y-transform.position.y);
        float hypotenuse = Mathf.Sqrt(Mathf.Pow(relMousePos.x, 2)+Mathf.Pow(relMousePos.y, 2));
        float relMouseRad = Mathf.Asin(relMousePos.y/hypotenuse);
        float relMouseDeg = relMouseRad*Mathf.Rad2Deg;
        if (mousePos.x <0 && mousePos.y <0)
        {
            relMouseDeg = 180+(relMouseDeg * -1);
        }else if (mousePos.x<0)
        {
            relMouseDeg = 180-relMouseDeg;
        }else if (mousePos.y<0)
        {
            relMouseDeg = 360-(relMouseDeg*-1);
        }

        if (relMouseDeg >=0 && relMouseDeg <45)
        {
            Debug.Log("Q0.5");
<<<<<<< Updated upstream
        }else if (relMouseDeg >= 45 && relMouseDeg < 90)
        {
            Debug.Log("Q1");
=======
            anim.SetInteger("Dir", 1);
        }else if (relMouseDeg >= 45 && relMouseDeg < 90)
        {
            Debug.Log("Q1");
            anim.SetInteger("Dir", 4);
>>>>>>> Stashed changes
        }
        else if (relMouseDeg >= 90 && relMouseDeg < 135)
        {
            Debug.Log("Q1.5");
<<<<<<< Updated upstream
=======
            anim.SetInteger("Dir", 4);
>>>>>>> Stashed changes
        }
        else if (relMouseDeg >= 135 && relMouseDeg < 180)
        {
            Debug.Log("Q2");
<<<<<<< Updated upstream
        }else if (relMouseDeg >= 180 && relMouseDeg < 225)
        {
            Debug.Log("Q2.5");
=======
            anim.SetInteger("Dir", 3);
        }
        else if (relMouseDeg >= 180 && relMouseDeg < 225)
        {
            Debug.Log("Q2.5");
            anim.SetInteger("Dir", 3);
>>>>>>> Stashed changes
        }
        else if (relMouseDeg >= 225 && relMouseDeg < 270)
        {
            Debug.Log("Q3");
<<<<<<< Updated upstream
=======
            anim.SetInteger("Dir", 2);
>>>>>>> Stashed changes
        }
        else if (relMouseDeg >= 270 && relMouseDeg < 315)
        {
            Debug.Log("Q3.5");
<<<<<<< Updated upstream
=======
            anim.SetInteger("Dir", 2);
>>>>>>> Stashed changes
        }
        else if (relMouseDeg >= 315 && relMouseDeg < 360)
        {
            Debug.Log("Q4");
<<<<<<< Updated upstream
=======
            anim.SetInteger("Dir", 1);
>>>>>>> Stashed changes
        }

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))*speed);
    }
}
