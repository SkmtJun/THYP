using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHero : MonoBehaviour
{
    TouchCheck touchCheck;
    Transform heroTransform;

    Vector3 posInit = new Vector3(0, -4, 0);
    Vector3 posLeft = new Vector3(-3, -2, 0);
    Vector3 posRight = new Vector3(3, -2, 0);
    Vector3 posMiddle = new Vector3(0, -2, 0);

    //bool isTouchLeft = false;
    //bool isTouchRight = false;

    // Start is called before the first frame update
    void Start()
    {
        touchCheck = GetComponent<TouchCheck>();
        heroTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (touchCheck.isTouchLeft == true && touchCheck.isTouchRight == false)
        {
            heroTransform.transform.position = posLeft;
        }
        else if (touchCheck.isTouchLeft == false && touchCheck.isTouchRight == true)
        {
            heroTransform.transform.position = posRight;
        }
        else if (touchCheck.isTouchLeft == true && touchCheck.isTouchRight == true)
        {
            heroTransform.transform.position = posMiddle;
        }
        else if (touchCheck.isTouchLeft == false && touchCheck.isTouchRight == false)
        {
            heroTransform.transform.position = posInit;
        }
    }
}
