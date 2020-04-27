using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    GameObject controller;

    TouchCheck checker;
    NoteManager generator;
    SongSwitch songSwitch;

    bool left = false;
    bool right = false;

    List<GameObject> notes;

    public int combo = 0;

    int nowNum;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Controller");
        checker = controller.GetComponent<TouchCheck>();
        generator = GetComponent<NoteManager>();
        songSwitch = GetComponent<SongSwitch>();
        notes = generator.noteList;
    }

    // Update is called once per frame
    void Update()
    {
        if (checker.isTouchLeft && !left && !checker.isTouchRight)//按下左
        {
            CheckHit(0);
        }

        if (checker.isTouchRight && !right && !checker.isTouchLeft)//按下右
        {
            CheckHit(1);
        }

        if (checker.isTouchLeft && checker.isTouchRight)//同时
        {
            if (!left || !right)
            {
                CheckHit(2);
            }
        }

        CheckMiss();

        left = checker.isTouchLeft;
        right = checker.isTouchRight;
    }


    void CheckMiss()
    {
        if (notes.Count > 0)
        {
            foreach (GameObject n in notes)
            {
                NoteFalling nf = n.GetComponent<NoteFalling>();
                if (!nf.isMiss && nf.checkTime < songSwitch.currentTime - 0.1f)
                {
                    nf.isMiss = true;
                    Debug.Log("Miss!");
                }
            }
        }
    }

    void CheckHit(int type)
    {
        //Debug.Log("check desu");
        if (notes.Count > 0)
        {
            List<GameObject> pendingNotes = new List<GameObject>();//可判定的note表
            GameObject bestNote;
            foreach (GameObject n in notes)//检查每个note
            {
                //Debug.Log("check each note");
                NoteFalling nf = n.GetComponent<NoteFalling>();
                float deltaTime = Mathf.Abs(nf.checkTime - songSwitch.currentTime);
                if (deltaTime < 0.1f && nf.checkType == type)//找到可判定的note
                {
                    pendingNotes.Add(n);//加入表
                    //Debug.Log("add desu");
                }
            }

            if (pendingNotes.Count > 0)//确定有可判定的note
            {
                Debug.Log("check out desu");
                bestNote = pendingNotes[0];
                foreach (GameObject n in pendingNotes)
                {
                    float bestDT = Mathf.Abs(bestNote.GetComponent<NoteFalling>().checkTime - songSwitch.currentTime);
                    float DT = Mathf.Abs(n.GetComponent<NoteFalling>().checkTime - songSwitch.currentTime);
                    if (DT < bestDT)
                    {
                        bestNote = n;
                    }
                }

                float dt = Mathf.Abs(bestNote.GetComponent<NoteFalling>().checkTime - songSwitch.currentTime);
                if (dt < 0.05f)//评分
                {
                    Debug.Log("Perfect!");
                }
                else
                {
                    Debug.Log("Good!");
                }

                if (bestNote.GetComponent<NoteFalling>().num - 1 == nowNum)
                {
                    combo++;
                }
                else
                {
                    combo = 1;
                }

                Debug.Log("Combo:" + combo);
                nowNum = bestNote.GetComponent<NoteFalling>().num;

                bestNote.GetComponent<NoteFalling>().isDead = true;//给note标记死亡
            }
        }
    }

}
