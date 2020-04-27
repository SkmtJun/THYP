using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCheck : MonoBehaviour
{
    public bool isTouchLeft = false;
    public bool isTouchRight = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isTouchLeft = false;
        isTouchRight = false;
        //屏幕触摸检测
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                //Debug.Log(touch.position.x);
                if (touch.position.x < Screen.width / 2)
                {
                    isTouchLeft = true;
                    Debug.Log("Left!");
                }
                else
                {
                    isTouchRight = true;
                    Debug.Log("Right!");
                }
            }
        }
        else//键盘检测
        {
            if (Input.GetKey("j"))
            {
                //Debug.Log("J is pressed!");
                isTouchLeft = true;
            }
            if (Input.GetKey("k"))
            {
                //Debug.Log("K is pressed!");
                isTouchRight = true;
            }
        }
    }

}

