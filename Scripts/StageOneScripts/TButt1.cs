using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TButt1 : MonoBehaviour
{
    public GameObject TFloorOne;
    public GameObject TFloorTwo;
    public GameObject TFloorThree;

    // Start is called before the first frame update
    void Start()
    {
        if (TFloorOne != null)
        {
            TFloorOne.SetActive(false);
        }

        if (TFloorTwo != null)
        {
            TFloorTwo.SetActive(false);
        }

        if (TFloorThree != null)
        {
            TFloorThree.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // collider hits this object's collider
    void OnCollisionEnter(Collision collision)
    {
        if (TFloorOne != null)
        {
            TFloorOne.SetActive(true);
        }

        if (TFloorTwo != null)
        {
            TFloorTwo.SetActive(true);
        }

        if (TFloorThree != null)
        {
            TFloorThree.SetActive(true);
        }
    }
}
