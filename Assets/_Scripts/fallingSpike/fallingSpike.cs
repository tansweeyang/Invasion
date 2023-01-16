using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingSpike : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    BoxCollider2D boxCollider2D;
    Rigidbody2D rb;
    public float distance;
    public GameObject Boss;
    bool isfalling = false;
    private PlayerBehaviour pb;
    private BossBehav bb;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        pb = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        if (Boss == null)
        {
            return;
        }
        else {
            bb = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossBehav>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if (isfalling == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);

            Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);

            if (hit.transform != null)
            {
                if (hit.transform.tag == "Player")
                {
                    rb.gravityScale = 5;
                    isfalling = true;

                }
            }
            if (hit.transform != null)
            {
                if (hit.transform.tag == "Boss")
                {
                    rb.gravityScale = 5;
                    isfalling = true;

                }
            }

        }
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            pb.TakeHit(3);
        /// take damage from falling spike
            Destroy(gameObject);
        }
        else
        {
            rb.gravityScale = 0;
            boxCollider2D.enabled = false;
        }

        if (Boss != null && collision.gameObject.tag == "Boss")
        {
            bb.TakeHit(3);
         
            /// take damage from falling spike
            Destroy(gameObject);
        }
        else
        {
            rb.gravityScale = 0;
            boxCollider2D.enabled = false;
        }
    }
    //------------------------------------------------------------------------------------------
}
