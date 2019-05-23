using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class YoyoThrowDoTween : MonoBehaviour
{
    PlayerController pc;
    public GameObject yoyo;
    public Transform point;
    public Transform target;
    public Transform target2;
    public Transform target3;
    bool thrown = false;
    public Transform hand;
    bool onWayBack = false;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Collider2D c;
    LineRenderer line;

    // Start is called before the first frame update
    void Awake()
    {
        pc = GetComponent<PlayerController>();
        rb = yoyo.GetComponent<Rigidbody2D>();
        sr = yoyo.GetComponent<SpriteRenderer>();
        c = yoyo.GetComponent<Collider2D>();
        line = yoyo.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire2") && !thrown && !onWayBack)
        {
            thrown = true;
            yoyo.transform.position = hand.position;
            sr.enabled = true;
            c.enabled = true;
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                point.position = target2.position;
            } else if (Input.GetAxisRaw("Vertical") < 0 && !pc.grounded)
            {
                point.position = target3.position;
            } else
            {
                point.position = target.position;
            }
            rb.DOMove(point.position, .5f);
            line.enabled = true;
        }

        if (line.enabled)
        {
            line.SetPosition(0, yoyo.transform.position);
            line.SetPosition(1, hand.position);
        }

        if (thrown && (Vector2.Distance(yoyo.transform.position, point.position) <= .3f))
        {
            onWayBack = true;
        }

        if (onWayBack)
        {
            rb.DOMove(hand.position, .5f);
        }

        if (onWayBack && (Vector2.Distance(yoyo.transform.position, hand.position) <= .3f))
        {
            thrown = false;
            onWayBack = false;
            sr.enabled = false;
            c.enabled = false;
            line.enabled = false;
        }
    }
}
