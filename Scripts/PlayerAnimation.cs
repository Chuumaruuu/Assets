using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator playerAnim;
    CharacterController playerCont;
    bool canTakeDamage = true, isRestart;
    int playerHp;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerCont = GetComponent<CharacterController>();
        playerHp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        isRestart = playerMovement.isRestart;
        if (canTakeDamage)
        {
            float lakad = Input.GetAxis("Vertical");
            float lakad2 = Input.GetAxis("Horizontal");
            if (lakad2 != 0)
            {
                lakad = lakad2;
            }
            playerAnim.SetFloat("lakad", lakad);
            bool checkRun = false;
            if (Input.GetKey(KeyCode.LeftShift) && lakad > 0)
            {
                checkRun = true;
            }
            playerAnim.SetBool("takbo", checkRun);
            AnimatorStateInfo animInfo = playerAnim.GetCurrentAnimatorStateInfo(0);
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(atk());
            }
            if(Input.GetButtonDown("Fire2")){
                StartCoroutine(FireBullet());
            }
            if(Input.GetButtonDown("Jump") && playerCont.isGrounded){
                playerAnim.SetTrigger("talon");
            }
        }
        if (isRestart)
        {
            playerAnim.SetBool("talo", false);
            playerAnim.SetBool("panalo", false);
            playerHp = 3;
            isRestart = false;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "obs")
        {
            StartCoroutine(Knockback());
        }
        if(hit.collider.name == "Safety Net")
        {
            StartCoroutine(Knockback());
        }
        if(hit.collider.name == "End")
        {
            playerAnim.SetBool("panalo", true);
        }
    }

    private IEnumerator Knockback()
    {
        canTakeDamage = false;
        playerAnim.SetTrigger("hit");
        playerHp--;
        if (playerHp <= 0)
        {
            playerAnim.SetBool("talo", true);
        }
        yield return new WaitForSeconds(.5f);
        canTakeDamage = true;
    }

    IEnumerator FireBullet()
    {
        yield return new WaitForSeconds(0.5f);
        playerAnim.SetTrigger("atk2");
    }

    IEnumerator atk()
    {
        yield return new WaitForSeconds(0.5f);
        playerAnim.SetTrigger("atk");
    }
}
