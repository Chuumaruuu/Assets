using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door2script : MonoBehaviour
{
    GameObject[] target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectsWithTag("door2break");
        if (target.Length == 0)
        {
            Destroy(gameObject);
        }
    }
}
