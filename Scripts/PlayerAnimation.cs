using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator playerAnim;
    CharacterController playerCont;
    PlayerMovement playerMovement;
    bool canTakeDamage = true;
    int playerHp;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerCont = GetComponent<CharacterController>();
        playerMovement = GetComponent<PlayerMovement>();
        playerHp = playerMovement.hp;
    }

    // Update is called once per frame
    void Update()
    {
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
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "obs")
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
