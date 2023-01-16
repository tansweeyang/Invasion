//script for player's hp and die effect
//description: Manage the player's hp and canvas to display the player's hp and
//             max hp. The player will be destroyed if it's hp is lower than or
//             equal to 0.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public float hp, maxHp; //player's current hp and max hp
    public HealthBarBehaviour healthBar; //health bar canvas
    public GameObject playerDie; //player die effect
    //goh
    private EdgeCollider2D ec;
    public float hitboxCdTime;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    //initialize player's hp
    void Start()
    {
        hp = maxHp;
        healthBar.SetHealth(hp, maxHp);
        //goh
        ec = GetComponent<EdgeCollider2D>();
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    //function to reduce player's hp and call Die() when player is out of health
    public void TakeHit(float damage)
    {
        hp -= damage;
        healthBar.SetHealth(hp, maxHp);
        if (hp <= 0)
        {
            Die();
        }
    }

    //Instantiate player die effect and destroy the player object
    void Die()
    {
        Instantiate(playerDie, transform.position, Quaternion.identity);
        Destroy(gameObject);
        FindObjectOfType<LevelManager>().Restart();
    }

    //goh
    //add condition

    public void TakeHitByGroundSpite(float damage)
    {
        hp -= damage;
        healthBar.SetHealth(hp, maxHp);
        if (hp <= 0)
        {
            Die();
        }
        //goh

        ec.enabled = false;
        StartCoroutine(ShowPlayerHitBox());
    }
    //goh
    IEnumerator ShowPlayerHitBox()
    {
        yield return new WaitForSeconds(hitboxCdTime);
        ec.enabled = true;
    }
    //------------------------------------------------------------------------------------------
}
