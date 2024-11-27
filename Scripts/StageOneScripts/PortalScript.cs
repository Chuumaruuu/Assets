using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public Transform destination;
    public GameObject coin; // Reference to the coin object

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !coin.activeInHierarchy) // Check if the coin is inactive
        {
            other.gameObject.SetActive(false);
            other.transform.position = destination.position;
            other.gameObject.SetActive(true);
        }
    }
}
