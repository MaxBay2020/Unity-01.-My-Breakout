using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
{
    public enum Brick_Type
    {
        Normal,

        ThreeHitBroken,

        NonBroken,

        ProlongPaddle,

        Multiple,
    }

    //public GameObject prolongItemPrefab;
    
    public GameObject itemPrefab;

    public Brick_Type currentType;


    public GameObject breakParticlePrefab;

    public AudioSource brickAudio;

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
        if(currentType == Brick_Type.NonBroken)
        {
            return;

        }else if(currentType == Brick_Type.ProlongPaddle || currentType == Brick_Type.Multiple)
        {
            GameObject item = Instantiate(itemPrefab);

            Vector3 pos = transform.position;

            pos.z -= 1f;

            item.transform.position = pos;

        }

        GameObject particle = Instantiate(breakParticlePrefab);

        particle.transform.position = transform.position;

        brickAudio.Play();

        this.enabled = false;

        GameManager.instance.CheckLevelPassed();

        Destroy(gameObject);


        if (GameManager.instance.scoreOnce)
        {
            int markInt = int.Parse(GameManager.instance.mark.text);

            markInt++;

            GameManager.instance.mark.text = markInt.ToString();

            //GameManager.instance.scoreOnce = false;
        }
     
    }

}
