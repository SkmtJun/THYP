using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSwitch : MonoBehaviour
{
    public float currentTime;
    public float startTime;

    bool loaded = false;
    bool pausing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!loaded)
        {
            startTime = Time.time;

            GetComponent<NoteManager>().enabled = true;

            GetComponent<NoteManager>().rollingSpeed = GetComponent<SongSetting>().rollingSpeed;
            GetComponent<NoteManager>().lines = GenerateMap(GetComponent<SongSetting>().songMap);
            GetComponent<NoteManager>().startTime = startTime;

            Input.multiTouchEnabled = true;

            loaded = true;
            Debug.Log("Start!");
        }

        currentTime = Time.time - startTime;
        GetComponent<NoteManager>().currentTime = currentTime;

        if (currentTime > GetComponent<SongSetting>().audio.length)
        {
            GetComponent<NoteManager>().enabled = false;
        }

        
    }

    List<string> GenerateMap(TextAsset txt)
    {
        string[] strs = txt.text.Split('\n');
        List<string> map = new List<string>();
        foreach (string str in strs)
        {
            map.Add(str);
        }
        return map;
    }
}
