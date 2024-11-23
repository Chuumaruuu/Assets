using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator playerAnim;
    int hp=3;
    bool canTakeDamage = true;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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
            playerAnim.SetTrigger("atk");
        }
        if(Input.GetButtonDown("Fire2")){
            playerAnim.SetTrigger("atk2");
        }
        if (animInfo.IsName("atk"))
        {
            Debug.Log(animInfo.normalizedTime+"");
        }
        if(Input.GetButtonDown("Jump")){
            playerAnim.SetTrigger("talon");
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "obs")
        {
            StartCoroutine(Knockback());
        }
        if(hit.collider.name == "Win")
        {
            playerAnim.SetTrigger("panalo");
        }
    }

    private IEnumerator Knockback()
    {
        canTakeDamage = false;
        playerAnim.SetTrigger("hit");
        hp--;
        if (hp == 0)
        {
            playerAnim.SetTrigger("talo");
        }
        yield return new WaitForSeconds(1.0f);
        canTakeDamage = true;
    }
}
