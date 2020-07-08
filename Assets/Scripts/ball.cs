using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 10;

    public Transform paddle;

    public const float resetY = -11.4f;

    // Start is called before the first frame update
    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();

        paddle = GameObject.FindObjectOfType<paddle>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isPlaying)
        {
            Vector3 pos = transform.position;

            pos.x = paddle.transform.position.x;

            pos.y = resetY;

            transform.position = pos;

            GameManager.instance.onceOnly = true;

        }

        if (GameManager.instance.congradsShow)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !GameManager.instance.isPlaying)
        {
            //rb.velocity = new Vector3(1f, 1f, 0).normalized * speed;

            StartMove();

            GameManager.instance.isPlaying = true;
        }


    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.collider.gameObject.tag == "paddle")
    //    {
    //        isTouch = true;
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.collider.gameObject.tag == "brick")
        //{
        //    GameManager.instance.scoreOnce = true;
        //}
    }

    /// <summary>
    /// Reset Speed value
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        if (GameManager.instance.isPlaying)
        {
            Vector3 sp = rb.velocity.normalized;

            rb.velocity = sp * speed;
        }
    }

    public void StartMove()
    {
        int angle = GetRandomAngle();

        rb.velocity = new Vector3(1f, Mathf.Tan(angle*Mathf.Deg2Rad), 0).normalized * speed;

    }


    int GetRandomAngle()
    {
        int angle = Random.Range(10, 171);

        if (angle > 80 && angle < 100)
        {
            angle = GetRandomAngle();
        }

        return angle;
    }
}
