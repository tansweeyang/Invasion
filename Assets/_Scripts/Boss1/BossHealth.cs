using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public int health = 20;
    public GameObject deathEffect;
    public bool isInvulnarable = false;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    public void TakeDamage(int damage)
    {
        if (isInvulnarable)
            return;

        health -= damage;
        if (health <= 0) {
          
            Die();
        }
    }

    void Die() {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    //------------------------------------------------------------------------------------------
}
