//script for player's skill 3 and its UI
//description: The player casts a rain of meteors that explodes upon colliding
//             with another object. When the meteor explodes, it deals area
//             damage, reducing all the enemies' hp within the area of effect.
//             The meteors will be destroyed after their lifetimes.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillThree : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public float shootSpeed, shootTimer; //meteor's travel speed and cd to recast
    public Transform shootPosition1, shootPosition2, shootPosition3; //all casting positions
    public GameObject bullet; //meteor object
    public KeyCode shootKey; //key to perform skill 3
    public Image skillImage; //UI for skill 3
    private bool isShooting, isShot; //is the player casting meteors?, has the player casted meteors?
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
            Skill3();
            if (Input.GetKey(shootKey) && !isShooting)
            {
                StartCoroutine(Shoot());
            }
        }
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    //function to manage skill 3 UI
    void Skill3()
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

    //function to cast meteors
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

        GameObject newbullet = Instantiate(bullet, shootPosition1.position, Quaternion.identity);
        newbullet.GetComponent<Rigidbody2D>().velocity = new Vector2(direction() * shootSpeed * Time.fixedDeltaTime, -10f);
        newbullet.transform.localScale = new Vector2(newbullet.transform.localScale.x * direction(), newbullet.transform.localScale.y);

        GameObject newbullet2 = Instantiate(bullet, shootPosition2.position, Quaternion.identity);
        newbullet2.GetComponent<Rigidbody2D>().velocity = new Vector2(direction() * shootSpeed * Time.fixedDeltaTime, -10f);
        newbullet2.transform.localScale = new Vector2(newbullet2.transform.localScale.x * direction(), newbullet2.transform.localScale.y);

        GameObject newbullet3 = Instantiate(bullet, shootPosition3.position, Quaternion.identity);
        newbullet3.GetComponent<Rigidbody2D>().velocity = new Vector2(direction() * shootSpeed * Time.fixedDeltaTime, -10f);
        newbullet3.transform.localScale = new Vector2(newbullet3.transform.localScale.x * direction(), newbullet3.transform.localScale.y);
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
        isShot = false;
    }
    //------------------------------------------------------------------------------------------
}