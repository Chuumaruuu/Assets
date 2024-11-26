using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    bool isAttack=false;
    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isAttack = true;
            StartCoroutine(ResetAttack());
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "hand"&& isAttack)
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