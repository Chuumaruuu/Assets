using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private Vector3[] platformOrigPos;
    private GameObject[] platforms;
    private GameObject currentPlatform;
    private bool isOnPlatform = false;
    // Start is called before the first frame update
    void Start()
    {
        platforms = GameObject.FindGameObjectsWithTag("Platforms");
        platformOrigPos = new Vector3[platforms.Length];
        for (int i = 0; i < platforms.Length; i++)
        {
            platformOrigPos[i] = platforms[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnPlatform && currentPlatform != null)
        {
            currentPlatform.transform.position = Vector3.Lerp(currentPlatform.transform.position, currentPlatform.transform.position + Vector3.down * 1.5f, Time.deltaTime);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Platform
        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].transform.position = platformOrigPos[i];
        }
        isOnPlatform = false;
        currentPlatform = null;
        
        if (hit.gameObject.CompareTag("Platforms"))
        {
            currentPlatform = hit.gameObject;
            isOnPlatform = true;
        }
        }
}
