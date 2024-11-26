using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource footstepsSound;
    public AudioSource JumpSound;
    public AudioSource AttackSlapSound;
    public AudioSource FireballSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            footstepsSound.enabled = true;
        }
        else{
            footstepsSound.enabled = false;
        }
           if(Input.GetKey(KeyCode.Space))
        {
            JumpSound.enabled = true;
        }
        else
        {
            JumpSound.enabled = false;
        }
            if(Input.GetButtonDown("Fire1"))
        {
            AttackSlapSound.enabled = true;
        }
        else
        {
            AttackSlapSound.enabled = false;
        }
             if(Input.GetButtonDown("Fire2"))
        {
            FireballSound.enabled = true;
        }
        else
        {
            FireballSound.enabled = false;
        }

        
    }
}
