using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{
    public float speed;

    public float xMax = 12.6f;

    public float xMin = -12.6f;

    public float timer = 4f;

    public GameObject ballPrefab;

    public AudioSource itemAudio;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.congradsShow)
        {
            return;
        }

        float xx = Input.GetAxisRaw("Horizontal");

        if (xx != 0)
        {
            Vector3 pos = transform.position;

            pos.x += xx * Time.deltaTime * speed;

            pos.x = Mathf.Clamp(pos.x, xMin, xMax);

            transform.position = pos;
        }

        if (GameManager.instance.isProlong == true)
        {
            timer -= Time.deltaTime;
            print(timer);
        }

        if (timer <= 0)
        {
            transform.localScale = new Vector3(4, 0.5f, 1);

            GameManager.instance.isProlong = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        //if (GameManager.instance.isPlaying)
        //{



            item item = collision.collider.GetComponent<item>();

            if (item != null)
            {
            if (GameManager.instance.isPlaying)
            {
                if (GameManager.instance.isProlong == false)
                {
                    //transform.localScale = new Vector3(6, 0.5f, 1);

                    //GameManager.instance.isProlong = true;

                    if (item.currentType == item.Item_Type.ProlongPaddle)
                    {
                        transform.localScale = new Vector3(6, 0.5f, 1);

                        GameManager.instance.isProlong = true;
                    }
                    else if (item.currentType == item.Item_Type.multipleBalls)
                    {
                        for (int i = 0; i < item.manyNum; i++)
                        {
                            //multiple balls;
                            GameObject ball = Instantiate(ballPrefab);

                            Vector3 pos = transform.position;

                            pos.y = -11.4f;

                            ball.transform.position = pos;

                            ball.GetComponent<ball>().StartMove();
                        }



                    }

                    itemAudio.Play();
                }


                //if (timer == 0)
                //{
                //    isProlong = false;

                //    transform.localScale = new Vector3(4, 0.5f, 1);

                //}
                
                Destroy(collision.collider.gameObject);
            }
        }
    }
}
