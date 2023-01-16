//script for player's shooting
//description: Manages the weapon equipment and UI. The player is able to
//             switch between weapons by pressing the weapon switch key. The
//             orders of the weapons are as follow:
//             Gun 1:
//               Name          = Machine Gun
//               Bullet damage = 1
//               Firing speed  = 0.1s
//               Bullet speed  = 900
//             Gun 2:
//               Name          = Shotgun
//               Bullet damage = 1
//               Firing speed  = 0.3s
//               Bullet speed  = 900
//             Gun 3:
//               Name          = Sniper
//               Bullet damage = 15
//               Firing speed  = 1s
//               Bullet speed  = 1500

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public Transform shootPosition, shootPosition2, shootPosition3; //shooting positions
    public GameObject bullet, bullet2; //normal bullet and sniper bullet
    public KeyCode shootKey, weaponSwitchKey; //key to shoot and switch weapons
    public Image gun1Image, gun2Image, gun3Image; //UI for all weapons

    private float shootTimer; //Firing speed
    private bool isShooting, hasGun2, hasGun3; //is the player shooting?
    private string weaponEquipped; //current equipped weapon
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    //initialize the shooting status and current equipped weapon
    void Start()
    {
        

        isShooting = false;
        weaponEquipped = "Gun1";
        gun1Image.fillAmount = 1;
        gun2Image.fillAmount = 0;
        gun3Image.fillAmount = 0;
        hasGun2 = false;
        hasGun3 = false;
        int isOwned = PlayerPrefs.GetInt("shotgunOwnedKey");
        if (isOwned == 1)
        {
            hasGun2 = true;
        }
        isOwned = PlayerPrefs.GetInt("sniperOwnedKey");
        if (isOwned == 1)
        {
            hasGun3 = true;
        }
    }

    //update the shooting status and current equipped weapon
    void Update()
    {
        if (!GameScript.isPause && !VictoryScreenScript.isVictory && !DefeatScreenScript.isDefeat)
        {
            if (Input.GetKeyDown(weaponSwitchKey))
            {
                if (weaponEquipped == "Gun1" && hasGun2)
                {
                    gun1Image.fillAmount = 0;
                    gun2Image.fillAmount = 1;
                    gun3Image.fillAmount = 0;
                    weaponEquipped = "Gun2";
                }
                else if (weaponEquipped == "Gun2" && hasGun3 || weaponEquipped == "Gun1" && !hasGun2 && hasGun3)
                {
                    gun1Image.fillAmount = 0;
                    gun2Image.fillAmount = 0;
                    gun3Image.fillAmount = 1;
                    weaponEquipped = "Gun3";
                }
                else
                {
                    gun1Image.fillAmount = 1;
                    gun2Image.fillAmount = 0;
                    gun3Image.fillAmount = 0;
                    weaponEquipped = "Gun1";
                }
            }
            if (Input.GetKey(shootKey) && !isShooting && weaponEquipped == "Gun1")
            {
                StartCoroutine(Shoot1());
            }
            if (Input.GetKey(shootKey) && !isShooting && weaponEquipped == "Gun2")
            {
                StartCoroutine(Shoot2());
            }
            if (Input.GetKey(shootKey) && !isShooting && weaponEquipped == "Gun3")
            {
                StartCoroutine(Shoot3());
            }
        }
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    //function to fire Gun 1 (Machine Gun)
    IEnumerator Shoot1()
    {
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
        FindObjectOfType<AudioManagerScript>().Play("MachineGun Fire");
        GameObject newbullet = Instantiate(bullet, shootPosition.position, Quaternion.identity);
        newbullet.GetComponent<Rigidbody2D>().velocity = new Vector2(direction() * 900 * Time.fixedDeltaTime, 0f);
        newbullet.transform.localScale = new Vector2(newbullet.transform.localScale.x * direction(), newbullet.transform.localScale.y);
        shootTimer = 0.1f;
        yield return new WaitForSeconds(shootTimer);
        FindObjectOfType<AudioManagerScript>().Stop("MachineGun Fire");
        isShooting = false;
    }

    //function to fire Gun 2 (Shotgun)
    IEnumerator Shoot2()
    {
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
        GameObject newBullet = Instantiate(bullet, shootPosition2.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(direction() * 900 * Time.fixedDeltaTime, 5f);
        newBullet.transform.localScale = new Vector2(newBullet.transform.localScale.x * direction(), newBullet.transform.localScale.y);
        GameObject newBullet2 = Instantiate(bullet, shootPosition.position, Quaternion.identity);
        newBullet2.GetComponent<Rigidbody2D>().velocity = new Vector2(direction() * 900 * Time.fixedDeltaTime, 0f);
        newBullet2.transform.localScale = new Vector2(newBullet2.transform.localScale.x * direction(), newBullet2.transform.localScale.y);
        GameObject newBullet3 = Instantiate(bullet, shootPosition3.position, Quaternion.identity);
        newBullet3.GetComponent<Rigidbody2D>().velocity = new Vector2(direction() * 900 * Time.fixedDeltaTime, -5f);
        newBullet3.transform.localScale = new Vector2(newBullet3.transform.localScale.x * direction(), newBullet3.transform.localScale.y);
        shootTimer = 0.3f;
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }

    //function to fire Gun 3 (Sniper)
    IEnumerator Shoot3()
    {
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
        GameObject newBullet = Instantiate(bullet2, shootPosition.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(direction() * 1500 * Time.fixedDeltaTime, 0f);
        newBullet.transform.localScale = new Vector2(newBullet.transform.localScale.x * direction(), newBullet.transform.localScale.y);
        shootTimer = 1f;
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }
    //------------------------------------------------------------------------------------------
}
