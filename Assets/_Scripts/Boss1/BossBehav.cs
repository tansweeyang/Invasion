using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehav : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public float hp, maxHp;
    public HealthBarBehaviour healthBar;
    public GameObject enemyDie;
    public GameObject dropCoin;
    public bool isInvulnarable = false;
    public GameObject fallingSpite;
    public GameObject nextStage;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    void Start()
    {
        fallingSpite.SetActive(false);
        hp = maxHp;
        healthBar.SetHealth(hp, maxHp);
        nextStage.SetActive(false);
    }

    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    public void TakeHit(float damage)
    {
        //for Boss
        if (isInvulnarable)
            return;

        hp -= damage;
        healthBar.SetHealth(hp, maxHp);

        /////enrage condition
        if (hp <= maxHp / 2)
        {
            fallingSpite.SetActive(true);
            GetComponent<Animator>().SetBool("IsEnrage", true);
        }
        if (hp <= 0)
        {
            Die();
            nextStage.SetActive(true);
        }


    }

    void Die()
    {
        Instantiate(dropCoin, transform.position, Quaternion.identity);
        Instantiate(enemyDie, transform.position, Quaternion.identity);
        FindObjectOfType<AudioManagerScript>().Stop("Boss BGM");
        Destroy(gameObject);
    }
    //------------------------------------------------------------------------------------------
}