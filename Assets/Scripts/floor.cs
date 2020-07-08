using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {


        item item = collision.collider.GetComponent<item>();

        if (item != null)
        {
            GameManager.instance.onceOnly = false;

            Destroy(collision.collider.gameObject);
        }
        else
        {
            if (GameManager.instance.IslastBall)
            {
                GameManager.instance.GameOver();
            }
            else
            {
                Destroy(collision.collider.gameObject);
            }
            
        }

    }

}
