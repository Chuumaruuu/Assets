using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    CharacterController playerCont;
    Animator animator;
    Vector3 originalPosition;
    float initialJumpVelocity;
    float verticalVelocity;
    float gravity = 20.0f; // Gravity force
    float jumpForce = 25.0f; // Jump force
    float moveSpeed = 0.2f; // Normal move speed
    float runSpeed = 0.5f; // Run speed
    bool allCoinsCollected = false;
    int totalCoins;
    int collectedCoins = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerCont = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        originalPosition = new Vector3(transform.position.x, 18.0f, transform.position.z); 
        initialJumpVelocity = jumpForce;

        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    // Update is called once per frame
    void Update()
    {
        float currentSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            currentSpeed = runSpeed;
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal") * currentSpeed, 0, Input.GetAxis("Vertical") * currentSpeed);
        transform.Rotate(0, Input.GetAxis("Mouse X") * 2.0f, 0);

        if (playerCont.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetButtonDown("Jump") && allCoinsCollected)
            {
                verticalVelocity = initialJumpVelocity;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        move.y = verticalVelocity * Time.deltaTime;
        playerCont.Move(transform.TransformDirection(move));

        // Set the walking animation
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Walk Backward", true);
        }
        else
        {
            animator.SetBool("Walk Backward", false);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool("Melee", true);
        }
        else
        {
            animator.SetBool("Melee", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Jumping", true);
        }
        else
        {
            animator.SetBool("Jumping", false);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.name == "Safety Net")
        {
            transform.position = originalPosition;
        }
    }

    public void CollectCoin()
    {
        collectedCoins++;
        if (collectedCoins >= totalCoins)
        {
            allCoinsCollected = true;
        }
    }
}