//script for enemy's hp and die effect
//description: Manage the enemy's hp and canvas to display the enemy's hp and
//             max hp. The enemy will be destroyed if it's hp is lower than or
//             equal to 0.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public float hp, maxHp; //enemy's current hp and max hp
    public HealthBarBehaviour healthBar; //health bar canvas
    public GameObject enemyDie; //enemy die effect
    public GameObject dropCoin;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    //initialize enemy's hp
    void Start()
    {
        hp = maxHp;
        healthBar.SetHealth(hp, maxHp);
    }

    //function to reduce enemy's hp and call Die() when enemy is out of health
    public void TakeHit(float damage)
    {
        hp -= damage;
        healthBar.SetHealth(hp, maxHp);
        if (hp <= 0)
        {
            Die();
        }
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    //Instantiate enemy die effect and destroy the enemy object
    void Die()
    {
        Instantiate(dropCoin, transform.position, Quaternion.identity);
        Instantiate(enemyDie, transform.position, Quaternion.identity); 
        Destroy(gameObject);
    }
    //------------------------------------------------------------------------------------------
}
