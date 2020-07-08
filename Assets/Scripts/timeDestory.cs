using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeDestory : MonoBehaviour
{
    public float timeDes;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeDes);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
