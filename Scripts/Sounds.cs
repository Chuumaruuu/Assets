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
        
        footstepsSound.Stop();
        JumpSound.Stop();
        AttackSlapSound.Stop();
        FireballSound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (!footstepsSound.isPlaying)
            {
                footstepsSound.Play();
            }
        }
        else
        {
            footstepsSound.Stop();
        }
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpSound.Play();
        }
       
        if (Input.GetMouseButtonDown(0))
        {
            AttackSlapSound.Play();
        }

        if (Input.GetMouseButtonDown(1))
        {
            FireballSound.Play();
        }
    }
 }

