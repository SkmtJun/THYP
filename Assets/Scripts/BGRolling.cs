using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGRolling : MonoBehaviour
{
    public GameObject BG1;
    public GameObject BG2;
    public GameObject song;

    Transform BG1T;
    Transform BG2T;
    SongSetting songSetting;

    // Start is called before the first frame update
    void Start()
    {
        song = GameObject.Find("Level");
        BG1 = GameObject.Find("RollingHint1");
        BG2 = GameObject.Find("RollingHint2");
        BG1T = BG1.GetComponent<Transform>();
        BG2T = BG2.GetComponent<Transform>();
        songSetting = song.GetComponent<SongSetting>();
    }

    // Update is called once per frame
    void Update()
    {
        BG1T.Translate(0, -songSetting.rollingSpeed * Time.deltaTime, 0);
        BG2T.Translate(0, -songSetting.rollingSpeed * Time.deltaTime, 0);
    }
}
