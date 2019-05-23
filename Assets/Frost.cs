using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frost : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
