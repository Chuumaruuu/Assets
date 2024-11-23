using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeranimation : MonoBehaviour
{
    Animator playerAnim;
    //GameObject[] pointsCollect;
    int remainingPoints, lifeCtr = 3;
    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            float lakad = Input.GetAxis("Vertical");
            playerAnim.SetFloat("Lakad", lakad);
            bool checkRun = false;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                checkRun = true;
            }
            playerAnim.SetBool("Takbo", checkRun);
            if (Input.GetButtonDown("Fire1"))
            {
                playerAnim.SetTrigger("ATK");
            }
            AnimatorStateInfo animInfo = playerAnim.GetCurrentAnimatorStateInfo(0);
            if (animInfo.IsName("ATK"))
            {
                Debug.Log(animInfo.normalizedTime + "");
            }
            if (Input.GetButtonDown("Fire2"))
            {
                playerAnim.SetTrigger("Shoot");
            }
            if (Input.GetButtonDown("Jump"))
                {
                    playerAnim.SetTrigger("Hopping");
                }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("trap"))
        {
            playerAnim.SetTrigger("Knocked");
            if (lifeCtr == 0)
            {
                playerAnim.SetTrigger("Defeat");
                isDead = true;
            }
            lifeCtr--;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.name == "Goal")
        {
            playerAnim.SetTrigger("Winner");
        }
    }
}