using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletLoc;
    float reload = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        reload += Time.deltaTime;
        if(reload >= 1){
            Instantiate(bulletPrefab, bulletLoc.position, bulletLoc.rotation);
            reload = 0;
        }
        // if(Input.GetButtonDown("Fire1")){
        //     if(ctr!=0){
        //         Debug.Log("Bullets: " + --ctr);
        //         Instantiate(bulletPrefab,
        //         bulletLoc.position,
        //         bulletLoc.rotation);
        //     }else{
        //         empty=true;

        //     }

        // }            
        // if(empty){
        //     Debug.Log("Reloading...");
        //     reload += Time.deltaTime;
        //     if(reload >= 1){
        //         ctr = 12;
        //         reload = 0;
        //         empty = false;
        //     }
        // }
    }
}
