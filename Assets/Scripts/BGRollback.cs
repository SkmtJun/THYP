using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGRollback : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -19.2f) 
        {
            transform.position = new Vector3(transform.position.x, 19.2f, transform.position.z);
        }
    }
}
