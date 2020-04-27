using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public float startTime;
    public float currentTime;
    public float rollingSpeed;

    public List<string> lines;
    int num = 0;

    public List<GameObject> noteList = new List<GameObject>();
    public GameObject enemy1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (num < lines.Count)
        {
            string[] note = lines[num].Split(',');
            float noteTime = float.Parse(note[0]);
            if (currentTime >= noteTime - (18f / rollingSpeed))
            {
                GenerateNote(num, noteTime, int.Parse(note[1]));
                num++;

                Debug.Log("generate at " + (noteTime - (18f / rollingSpeed)));
                Debug.Log("arrive in " + 18f / rollingSpeed + " at " + noteTime);
                Debug.Log("line " + note[1]);
            }
        }

        KillNote();

    }

    void GenerateNote(int num, float time, int type)
    {

        Vector3 leftPoint = new Vector3(-3, 13.6f, 0);
        Vector3 rightPoint = new Vector3(3, 13.6f, 0);
        Vector3 middlePoint = new Vector3(0, 13.6f, 0);

        if (type == 0)
        {
            GeneratingNote(num, time, type, leftPoint);
        }
        if (type == 1)
        {
            GeneratingNote(num, time, type, rightPoint);
        }
        if (type == 2)
        {
            GeneratingNote(num, time, type, middlePoint);
        }
    }

    void GeneratingNote(int num, float time, int type, Vector3 pos)
    {
        GameObject note = Instantiate(enemy1, pos, Quaternion.identity, gameObject.transform);
        note.GetComponent<NoteFalling>().checkTime = time;
        note.GetComponent<NoteFalling>().num = num;
        note.GetComponent<NoteFalling>().checkType = type;
        noteList.Add(note);
    }

    void KillNote()
    {
        for (int i = 0; i < noteList.Count; i++)
        {
            GameObject note = noteList[i];
            if (note.GetComponent<NoteFalling>().isDead)
            {
                noteList.Remove(note);
                Destroy(note);
            }
        }
    }
}