using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPrefabScript : MonoBehaviour
{
    Rigidbody bulletRigid;
    // Start is called before the first frame update
    void Start()
    {
        bulletRigid = GetComponent<Rigidbody>();
        bulletRigid.AddForce(transform.forward*2000);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
        // MeshRenderer c1Mesh = col.collider.GetComponent<MeshRenderer>();
        // c1Mesh.material.color = new Color(Random.Range(0.0f,1.0f),
        // Random.Range(0.0f,1.0f),
        // Random.Range(0.0f,1.0f));
    }
}
