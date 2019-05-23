using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    public GameObject indicator;
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetButtonDown("Use"))
            {
                GetComponent<NpcScript>().triggerDialogue();
            }
        }
    }*/

    void Update()
    {
        if ((Vector2.Distance(GetComponent<Transform>().position, GameObject.FindGameObjectWithTag("Player").transform.position) < 1))
        {
            indicator.GetComponent<SpriteRenderer>().enabled = true;
            if (Input.GetButtonDown("Use"))
            {
                GetComponent<NpcScript>().triggerDialogue();
            }
        } else
        {
            indicator.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
