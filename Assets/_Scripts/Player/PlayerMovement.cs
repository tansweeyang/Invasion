//script for player's movement and skill 1
//description: The player will run towards the arrow keys' directions and
//             jump whenever the jump key is pressed. The player is not able
//             jump again when the player is already jumping. The player will
//             dash (skill 1) when the dash key is pressed. The player is not
//             able to perform any other movements during dashing.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //-------------------------------------Class Variables---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public float walkingVelocity, jumpVelocity, dashingPower, dashingTime, dashingCooldown; //movement speed, jump power, dash power, dashing time, skill 1 cd
    public Rigidbody2D rb; //player's Rigidbody2D
    public KeyCode jumpKey, dashKey; //keys to perform jump and dash
    public LayerMask groundLayer; //Ground layer
    public Collider2D footCollider; //player's foot Collider2D
    public Animator anim; //player's animator
    public Image skillImage; //skill 1 UI

    private bool isGrounded, canDash = true, isDashing = false, isDashed = false; //is the player on the ground?, can the player dash?, is the player dashing?, has the player started dashing?

    [SerializeField] private TrailRenderer tr; //player's TrailRenderer
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    //update player's action
    void Update()
    {
        if (!GameScript.isPause && !VictoryScreenScript.isVictory && !DefeatScreenScript.isDefeat)
        {
            Skill1();
            if (isDashing)
            {
                return;
            }

            float direction = Input.GetAxisRaw("Horizontal");
            isGrounded = footCollider.IsTouchingLayers(groundLayer);
            rb.velocity = new Vector2(direction * walkingVelocity * Time.fixedDeltaTime, rb.velocity.y);
            if (direction != 0)
            {
                anim.SetBool("isRunning", true);
                transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * direction, transform.localScale.y);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
            if (Input.GetKey(dashKey) && canDash)
            {
                StartCoroutine(Dash());
            }
            if (Input.GetKey(jumpKey))
            {
                if (isGrounded)
                {
                    Jump();
                }
            }
            if (isGrounded)
            {
                anim.SetBool("isJumping", false);
            }
            else
            {
                anim.SetBool("isJumping", true);
            }

        }
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    //function to jump
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity * Time.fixedDeltaTime);
    }

    //function to perform skill 1 and manage the UI
    void Skill1()
    {
        if (Input.GetKey(dashKey) && !isDashed)
        {
            skillImage.fillAmount = 0;
        }


        skillImage.fillAmount += 1 / dashingCooldown * Time.deltaTime;
        if (skillImage.fillAmount >= 1)
        {
            skillImage.fillAmount = 1;
        }
    }

    //function to dash
    private IEnumerator Dash()
    {
        isDashed = true;
        canDash = false;
        isDashing = true;
        anim.SetBool("isDashing", true);
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        if (transform.localScale.x >= 0)
        {
            rb.velocity = new Vector2(transform.localScale.x + dashingPower, 0f);
        }
        else
        {
            rb.velocity = new Vector2(transform.localScale.x - dashingPower, 0f);
        }
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        anim.SetBool("isDashing", false);
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
        isDashed = false;
    }
   
   //use to detect the moving platform so the player can follow the platform
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.parent = collision.gameObject.transform;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.parent = null;
        }
    }
    //------------------------------------------------------------------------------------------
}
