using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public Transform destination;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            other.transform.position = destination.position;
            other.gameObject.SetActive(true);
        }
    }
}
