//script for enemy's bullet
//description: The bullet will be destroyed when it collides with another
//             object. If the object is a player, reduce the player's hp.
//             The bullet will be destroyed after its lifetime.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDiePlayer : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public GameObject bulletDie; //bullet impact effect
    public float dieTime; //bullet travel time
    public float bulletDamage; //bullet damage
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    //starts a Coroutine
    void Start()
    {
        StartCoroutine(Timer());
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    //reduce the player's hp when the bullet touches player's Collider2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        var player = collision.collider.GetComponent<PlayerBehaviour>();
        if (player)
        {
            player.TakeHit(bulletDamage);
        }
        Die();
    }

    //call Die() after dieTime
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(dieTime);
        Die();
    }

    //Instantiate bullet impact effect and destroy the bullet object
    void Die()
    {
        if (bulletDie != null)
        {
            Instantiate(bulletDie, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    //------------------------------------------------------------------------------------------
}
