using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    bool isAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.up, 40*Time.deltaTime);
        if (Input.GetButtonDown("Fire1"))
        {
            isAttack = true;
            StartCoroutine(ResetAttack());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Hitter" && isAttack)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(0.5f);
        isAttack = false;
    }
}
