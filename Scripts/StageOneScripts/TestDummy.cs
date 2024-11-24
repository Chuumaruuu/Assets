using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDummy : MonoBehaviour
{
    CharacterController playerCont;
    Vector3 originalPosition;
    float initialJumpVelocity;
    float verticalVelocity;
    float gravity = 20.0f; // Gravity force
    float jumpForce = 25.0f; // Jump force
    float moveSpeed = 0.2f; // Normal move speed
    float runSpeed = 0.5f; // Run speed

    // Start is called before the first frame update
    void Start()
    {
        playerCont = GetComponent<CharacterController>();
        originalPosition = new Vector3(transform.position.x, 18.0f, transform.position.z); 
        initialJumpVelocity = jumpForce;
    }

    // Update is called once per frame
    void Update()
    {
        float currentSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            currentSpeed = runSpeed;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal") * currentSpeed, 0, Input.GetAxis("Vertical") * currentSpeed);
        transform.Rotate(0, Input.GetAxis("Mouse X") * 2.0f, 0);

        if (playerCont.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
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
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.name == "Safety Net")
        {
            transform.position = originalPosition;
        }
    }
}