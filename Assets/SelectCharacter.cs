using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{
    public GameObject player;
    PlayerController pc;
    Canvas can;

    // Start is called before the first frame update
    void Awake()
    {
        //pc = player.GetComponent<PlayerController>();
        can = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initiate() {
        SceneManager.LoadScene("CinemachineTest");
        /*pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        pc.enabled = true;
        can.enabled = false;*/
    }
}
