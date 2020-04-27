using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteFalling : MonoBehaviour
{
    float rollSpeed;

    public bool isDead = false;
    public float checkTime;
    public int checkType;
    public int num;
    public bool isMiss = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        rollSpeed = GameObject.Find("Level").GetComponent<SongSetting>().rollingSpeed;
        transform.Translate(new Vector3(0, -rollSpeed * Time.deltaTime));

        if (transform.position.y < -13.6)
        {
            isDead = true;
        }
    }
}
