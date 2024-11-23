using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    private CharacterController playerCont;
    private Vector3 origPos;
    private GameObject[] coinsCol;
    private int coinsLeft, hp = 100;
    private float drop;
    private bool isDone = false;
    private bool canTakeDamage = true;

    // Start is called before the first frame update
    void Start()
    {
        playerCont = GetComponent<CharacterController>();
        origPos = playerCont.transform.position;
        drop = 0;
        Debug.Log("HP: " + hp);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDone)
        {
            float lakad = Input.GetAxis("Horizontal") * 0.05f;
            playerCont.Move(
                transform.TransformDirection(
                new Vector3(lakad,
                drop, Input.GetAxis("Vertical") * 0.05f)));
            // {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                lakad *= 2;
            }
            else
            {
                lakad *= 1;
            }
            if (playerCont.isGrounded)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    drop = 0.5f;
                }
            }
            else
            {
                drop -= .01f;
            }

            float rotY = Input.GetAxis("Mouse X");
            transform.Rotate(0, rotY, 0);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.name == "Safety Net")
        {
            transform.position = origPos;
        }
        if (hit.gameObject.tag == "Coins")
        {
            Destroy(hit.gameObject);
        }
        if (hit.gameObject.tag == "trap" && canTakeDamage)
        {
            StartCoroutine(KnockbackAndDamage());
        }
        if (hit.collider.name == "Win")
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
        canTakeDamage = true;
    }
}