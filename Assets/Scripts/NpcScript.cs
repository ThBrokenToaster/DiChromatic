using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcScript : MonoBehaviour
{
    public Dialgoue dialgoue;
    DialogueManager2 dm;
    bool inCon = false;
    bool end;

    void Awake()
    {
        dm = FindObjectOfType<DialogueManager2>();
    }

    public void triggerDialogue()
    {
        if (!inCon)
        {
            dm.StartDialogue(dialgoue);
            inCon = true;
            end = false;
        } else
        {
            end = dm.DisplayNextSentence();
        }

        if (end)
        {
            inCon = false;
        }
    }
}
