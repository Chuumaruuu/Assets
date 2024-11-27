using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatforms : MonoBehaviour
{
    Transform[] fPlatTrans;
    GameObject[] fPlatforms;
    float fspeed = -15f; // Falling speed
    float[] fallTimers;
    Vector3[] fPlatStartPos;

    void Start()
    {
        // Find all platforms tagged "FallPlatforms"
        fPlatforms = GameObject.FindGameObjectsWithTag("Platforms");

        // Initialize arrays based on the number of platforms
        fPlatTrans = new Transform[fPlatforms.Length];
        fallTimers = new float[fPlatforms.Length];
        fPlatStartPos = new Vector3[fPlatforms.Length];

        // Store platform transforms and initial positions
        for (int i = 0; i < fPlatforms.Length; i++)
        {
            fPlatTrans[i] = fPlatforms[i].GetComponent<Transform>();
            fallTimers[i] = 0;
            fPlatStartPos[i] = fPlatTrans[i].position;
        }
    }

    void Update()
    {
        CapsuleCollider player = GetComponent<CapsuleCollider>();
        
        for (int i = 0; i < fPlatTrans.Length; i++)
        {
            if(player.bounds.Intersects(fPlatTrans[i].GetComponent<MeshRenderer>().bounds))
            {
                fallTimers[i] += Time.deltaTime;

                if (fallTimers[i] >= 3)
                {
                    fPlatTrans[i].Translate(0, fspeed * Time.deltaTime, 0);
                }
            }
            
        }

        // Reset platforms if they fall below a certain threshold
        for (int i = 0; i < fPlatTrans.Length; i++)
        {
            if (fPlatTrans[i].position.y < -10)
            {
                // Reset platform position and timer
                fPlatTrans[i].position = fPlatStartPos[i];
                fallTimers[i] = 0;
            }
        }
    }
}
