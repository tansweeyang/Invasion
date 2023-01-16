using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSfirst : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    BoxCollider2D boxCollider2D;
    Rigidbody2D rb;
    public float distance;

    bool isfalling = false;
    private PlayerBehaviour pb;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        pb = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
    
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
           

        }
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            pb.TakeHit(1);
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
