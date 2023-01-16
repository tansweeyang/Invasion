//script for player's bullet
//description: The bullet will be destroyed when it collides with another
//             object. If the object is an enemy, reduce the enemy's hp.
//             The bullet will be destroyed after its lifetime.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDie : MonoBehaviour
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
    //reduce the enemy's hp when the bullet touches enemy's Collider2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        var enemy = collision.collider.GetComponent<EnemyBehaviour>();
        if (enemy)
        {
            enemy.TakeHit(bulletDamage);
        }
        Die();

        /////use to hit the boss
        if (collisionGameObject.name != "Player")
        {
            var enemy1 = collision.collider.GetComponent<BossBehav>();
            if (enemy1)
            {
                enemy1.TakeHit(bulletDamage);

            }
            Die();
        }

        //////use to hit the random object
        if (collisionGameObject.name != "Player")
        {
            var random = collision.collider.GetComponent<randomDrop>();
            if (random)
            {
                random.RandomGen();
            }
            Die();
        }
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
