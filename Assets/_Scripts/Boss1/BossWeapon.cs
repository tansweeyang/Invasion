using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public int attackDamage = 20;
    public int enragedAttackDamage = 40;
    
    public Vector3 attackOffset;
    
    public float attackRange = 1f;
    //use to put the player object
    public LayerMask attackMask;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Boss Attacking Skills--------------------------------
    // default attacking skills
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
       
        if (colInfo != null)
        { 
            colInfo.GetComponent<PlayerBehaviour>().TakeHit(attackDamage);
        }
    }

    // when the health of the boss is less than 50
    public void Attack2()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);

        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerBehaviour>().TakeHit(attackDamage);
        }
    }
    //------------------------------------------------------------------------------------------
}
