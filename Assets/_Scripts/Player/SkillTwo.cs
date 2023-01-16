//script for player's skill 2 and its UI
//description: The player casts a fireball that explodes upon colliding with
//             another object. When the fireball explodes, it deals area
//             damage, reducing all the enemies' hp within the area of effect.
//             The fireball will be destroyed after its lifetime.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTwo : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public float shootSpeed, shootTimer; //fireball's travel speed and cd to recast
    public Transform shootPosition; //casting position
    public GameObject bullet; //fireball object
    public KeyCode shootKey; //key to perform skill 2
    public Image skillImage; //UI for skill 2
    private bool isShooting, isShot; //is the player casting fireball?, has the player casted fireball?
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    //initialize the casting status
    void Start()
    {
        isShot = false;
        isShooting = false;
    }

    //update the casting status
    void Update()
    {
        if (!GameScript.isPause && !VictoryScreenScript.isVictory && !DefeatScreenScript.isDefeat)
        {
            Skill2();
            if (Input.GetKey(shootKey) && !isShooting)
            {
                StartCoroutine(Shoot());
            }
        }
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    //function to manage skill 2 UI
    void Skill2()
    {
        if (Input.GetKey(shootKey) && !isShot)
        {
            skillImage.fillAmount = 0;
        }
        skillImage.fillAmount += 1 / shootTimer * Time.deltaTime;
        if (skillImage.fillAmount >= 1)
        {
            skillImage.fillAmount = 1;
        }
    }

    //function to cast fireball
    IEnumerator Shoot()
    {
        isShot = true;
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
        newbullet.GetComponent<Rigidbody2D>().velocity = new Vector2(direction() * shootSpeed * Time.fixedDeltaTime, 0f);
        newbullet.transform.localScale = new Vector2(newbullet.transform.localScale.x * direction(), newbullet.transform.localScale.y);
        
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
        isShot = false;
    }
    //------------------------------------------------------------------------------------------
}
