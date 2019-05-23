using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KnifeThrow : MonoBehaviour
{

    public GameObject knife;
    public Transform backKnife;
    public Transform hand;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Collider2D c;
    public float throwSpeed = 15f;
    PlayerController pc;
    public LayerMask lm;
    RaycastHit2D hit;
    bool right = true;
    bool hasKnife = true;
    bool returning;
    bool thrown;
    TrailRenderer tr;


    // Start is called before the first frame update
    void Awake()
    {
        pc = GetComponent<PlayerController>();
        rb = knife.GetComponent<Rigidbody2D>();
        sr = knife.GetComponent<SpriteRenderer>();
        c = knife.GetComponent<Collider2D>();
        tr = knife.GetComponentInChildren<TrailRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {




        if (hasKnife) {
            if (Input.GetButtonDown("Fire1"))
            {
                
                knife.transform.position = hand.position;
                sr.enabled = true;
                tr.enabled = true;
                if (pc.facingRight)
                {
                    hit = Physics2D.Raycast(hand.position, Vector2.right, 1000f, lm);
                    knife.transform.localScale = new Vector3(1, 1, 1);
                    rb.velocity = Vector2.right * throwSpeed;
                    right = true;
                } else
                {
                    hit = Physics2D.Raycast(hand.position, Vector2.left, 1000f, lm);
                    knife.transform.localScale = new Vector3(-1, 1, 1);
                    rb.velocity = Vector2.left * throwSpeed;
                    right = false;
                }
            }

            if (right)
            {
                if (hit.point.x <= knife.transform.position.x)
                {
                    rb.velocity = Vector2.zero;
                    rb.transform.position = hit.point;
                    hasKnife = false;
                }
            } else
            {
                if (hit.point.x >= knife.transform.position.x)
                {
                    rb.velocity = Vector2.zero;
                    rb.transform.position = hit.point;
                    hasKnife = false;
                }
            }
        } else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                //rb.DOMove(pc.transform.position, .1f);
                returning = true;
            }
            if (returning)
            {
                knife.transform.position = Vector3.Lerp(hit.point, hand.position, ((Vector2.Distance(hand.position, knife.transform.position)) / (Vector2.Distance(hand.position, hit.point))));
                //knife.transform.rotation = Quaternion.Slerp(hit.point, hand.rotation, ((Vector2.Distance(hand.position, knife.transform.position)) / (Vector2.Distance(hand.position, hit.point))));
            }
            if (returning && Vector2.Distance(pc.transform.position, rb.transform.position) < 1f)
            {
                returning = false;
                hasKnife = true;
                sr.enabled = false;
                tr.enabled = false;
                tr.Clear();
            }
        }

        /*
        if (pc.facingRight)
        {
            hit = Physics2D.Raycast(backKnife.transform.position, Vector2.right, .4f, lm);
            if (hit)
            {
                rb.velocity = new Vector2(0, 0);
                Debug.Log("Hello: " + rb.velocity);
            }
        } else
        {
            hit = Physics2D.Raycast(backKnife.transform.position, Vector2.left, .4f, lm);
            if (hit)
            {
                rb.velocity = new Vector2(0, 0);
                Debug.Log("Hello: " + rb.velocity);
            }
        }*/
    }
}
