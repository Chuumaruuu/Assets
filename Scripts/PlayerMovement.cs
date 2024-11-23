using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController playerCont;
    Vector3 origPos;
    int hp = 100;
    float drop, lakad;
    bool isDone = false, canTakeDamage = true;

    // Start is called before the first frame update
    void Start()
    {
        playerCont = GetComponent<CharacterController>();
        origPos = playerCont.transform.position;
        drop = 0;
        Debug.Log("HP: "+hp);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDone)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                lakad = Input.GetAxis("Horizontal");
            }else
            {
                lakad = Input.GetAxis("Horizontal") * 0.5f;
            }

            playerCont.Move(
                transform.TransformDirection(
                new Vector3(lakad,
                drop, Input.GetAxis("Vertical") * .5f)));
            if(playerCont.isGrounded){
                if(Input.GetButtonDown("Jump"))
                    {
                        drop = 0.5f;
                    }
            }
            else
            {
                drop -= .01f;
            }
            
            float rotY = Input.GetAxis("Mouse X");
            transform.Rotate(0,rotY,0);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.name == "Safety Net")
        {
            transform.position = origPos;
        }
        if (hit.gameObject.tag == "Keys")
        {
            Destroy(hit.gameObject);
        }
        if (hit.gameObject.tag == "obs" && canTakeDamage)
        {
            StartCoroutine(KnockbackAndDamage());
            canTakeDamage = true;
        }
        if(hit.collider.name == "Win")
        {
            isDone = true;
            Debug.Log("You Win");
        }
    }

    private IEnumerator KnockbackAndDamage()
    {
        canTakeDamage = false;
        playerCont.Move(-transform.forward * 5f);
        hp--;
        Debug.Log("HP: " + hp);
        if (hp == 0)
        {
            isDone = true;
            Debug.Log("Game Over");
        }
        yield return new WaitForSeconds(1.0f);
    }
}
