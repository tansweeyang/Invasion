//script for meteor
//description: The meteor will be destroyed when it collides with another
//             object. The meteor will explode and deal area damage reducing
//             all the enemies' hp within the area. The meteor will be
//             destroyed after its lifetime.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDie : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public GameObject meteorDie; //meteor impact effect
    public float dieTime; //meteor travel time
    public float bulletDamage; //meteor damage
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    //starts a Coroutine
    void Start()
    {
        StartCoroutine(Timer());
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    //reduce all enemies' hp within the circle of meteor collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.name != "Player")
        {
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, 2f);
            foreach (var hit in hitColliders)
            {
                var enemy = hit.GetComponent<EnemyBehaviour>();
                if (enemy)
                {
                    enemy.TakeHit(bulletDamage);
                }
            }
            Die();
        }

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

    //Instantiate meteor impact effect and destroy the meteor object
    void Die()
    {
        if (meteorDie != null)
        {
            Instantiate(meteorDie, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    //------------------------------------------------------------------------------------------
}
