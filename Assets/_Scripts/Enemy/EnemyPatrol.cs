//script for enemy AI
//description: The enemy will keep walking on the terrain horizontally until
//             it reaches a wall or end of the cliff in which case the enemy
//             will turn around and start walking in the opposite direction.
//             When the player enters the enemy's detect range, the enemy
//             will stop patroling, face the player and start shooting. The
//             enemy will continue patrolling after the player gets out of the
//             enemy's detect range.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    [HideInInspector] //serialized the variable and not showing in the inspector
    public bool mustPatrol; //should the enemy patrol?

    public Rigidbody2D rb; //enemy's Rigidbody2D
    public float walkSpeed, range, shootTimer; //enemy's walking speed, player detect range, and attack speed
    public Transform groundCheckPos, player, shootPosition; //check patrol endpoint, check distance to the player, and shoot position
    public LayerMask groundLayer; //Ground layer
    public Collider2D bodyCollider; //enemy's upper Collider2D
    public Animator anim; //enemy's animator
    public GameObject bullet; //enemy's bullet

    private bool mustTurn, isShooting; //should the enemy turn?, is the enemy shooting?
    private float distToPlayer; //distance to the player
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    //initialize the enemy's action
    void Start()
    {
        isShooting = false;
        mustTurn = false;
        mustPatrol = true;
    }

    //update enemy's action
    void Update()
    {
        if (player != null)
        {
            if (mustPatrol)
            {
                Patrol();
            }
            distToPlayer = Vector2.Distance(transform.position, player.position);
            if (distToPlayer <= range)
            {
                if (player.position.x > transform.position.x && transform.localScale.x < 0
                    || player.position.x < transform.position.x && transform.localScale.x > 0)
                {
                    Flip();
                }
                mustPatrol = false;
                rb.velocity = Vector2.zero;
                if (!isShooting)
                {
                    StartCoroutine(Shoot());
                }
            }
            else
            {
                mustPatrol = true;
            }
        }
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    //check if the enemy reaches the end of the ground
    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    //function to patrol and manage the animation
    void Patrol()
    {
        if(walkSpeed != 0)
        {
            anim.SetBool("isWalking", true);
        }
        if (mustTurn || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    //function to turn the enemy
    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

    //function to shoot and manage the animation
    IEnumerator Shoot()
    {
        anim.SetBool("isShooting", true);
        int direction()
        {
            if (transform.localScale.x < 0f)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
        isShooting = true;
        GameObject newbullet = Instantiate(bullet, shootPosition.position, Quaternion.identity);
        newbullet.GetComponent<Rigidbody2D>().velocity = new Vector2(direction() * 200 * Time.fixedDeltaTime, 0f);
        newbullet.transform.localScale = new Vector2(newbullet.transform.localScale.x * direction(), newbullet.transform.localScale.y);
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
        anim.SetBool("isShooting", false);
    }
    //------------------------------------------------------------------------------------------
}
