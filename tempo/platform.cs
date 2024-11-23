using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    GameObject[] target;
    MeshRenderer meshRenderer;
    Collider platformCollider;

    // Start is called before the first frame update
    void Start()
    {

        meshRenderer = GetComponent<MeshRenderer>();
        platformCollider = GetComponent<Collider>(); 
        SetPlatformState(false);
    }

  
    void Update()
    {
        
        target = GameObject.FindGameObjectsWithTag("badguy");

      
        if (target.Length == 0)
        {
            SetPlatformState(true);
        }
    }

   
    void SetPlatformState(bool state)
    {
       
        meshRenderer.enabled = state;
        platformCollider.enabled = state;
    }
}
