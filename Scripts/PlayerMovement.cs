using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletLoc;
    CharacterController playerCont;
    Vector3 origPos;
    public int hp = 3;
    float drop, lakad;
    bool isDone = false, canTakeDamage = true, isPaused = false, win = false;
    public bool backToMain = false, isRestart = false;

    // Start is called before the first frame update
    void Start()
    {
        playerCont = GetComponent<CharacterController>();
        origPos = playerCont.transform.position;
        drop = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = true;
        }
        if (hp <= 0)
        {
            isDone = true;
        }
        if(!isDone || !isPaused)
        {
            if(canTakeDamage)
            {
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    lakad = Input.GetAxis("Vertical") *.5f;
                }else
                {
                    lakad = Input.GetAxis("Vertical") * 0.25f;
                }

                playerCont.Move(
                    transform.TransformDirection(
                    new Vector3(Input.GetAxis("Horizontal") * .1f,
                    drop, lakad)));
                if(playerCont.isGrounded){
                    if(Input.GetButtonDown("Jump"))
                        {
                            drop = 0.5f;
                        }
                }
                else
                {
                    drop -= .01f;
                };
                float rotY = Input.GetAxis("Mouse X");
                transform.Rotate(0,rotY,0);
                if(Input.GetButtonDown("Fire2"))
                {
                    StartCoroutine(FireBullet());
                }
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.name == "Safety Net")
        {
            StartCoroutine(RespawnPlayer());
        }
        if (hit.gameObject.tag == "Keys")
        {
            Destroy(hit.gameObject);
        }
        if (hit.gameObject.tag == "obs" && canTakeDamage)
        {
            StartCoroutine(KnockbackAndDamage());
        }
        if(hit.collider.name == "End")
        {
            isDone = true;
            win = true;
        }
    }

    private IEnumerator RespawnPlayer()
    {
        canTakeDamage = false;
        playerCont.enabled = false;
        playerCont.transform.position = origPos;
        yield return new WaitForSeconds(1);
        hp--;
        playerCont.enabled = true;
        canTakeDamage = true;
    }

    private IEnumerator KnockbackAndDamage()
    {
        canTakeDamage = false;
        playerCont.Move(-transform.forward * 15f);
        hp-=1;
        yield return new WaitForSeconds(.5f);
        canTakeDamage = true;
    }

    IEnumerator FireBullet()
    {
        yield return new WaitForSeconds(1);
        Instantiate(bulletPrefab, bulletLoc.position, bulletLoc.rotation);
    }

    private void OnGUI(){
        GUI.Box(new Rect(10, 10, 100, 25), "HP: " + hp);
        if(isPaused)
        {
            GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 300, 300), "PAUSED");
            if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 30), "RESUME"))
            {
                isPaused = false;
            }
            if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 30), "RESTART"))
            {
                isRestart = true;
                isPaused = false;
                playerCont.transform.position = origPos;
                hp = 3;
                isDone = false;
                float wait = Time.deltaTime;
                if(wait == 1){
                    isRestart = false;
                    wait = 0;
                }
            }
            if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 30), "BACK TO MAIN MENU"))
            {
                isPaused = false;
                backToMain = true;
            }
            if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 30), "QUIT"))
            {
                Application.Quit();
            }
        }
        if(win)
        {
            float loading = 0;
            loading = Time.deltaTime;
            if(loading == 1)
            {
                GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 300, 300), "YOU WIN!");
                if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 30), "RESTART"))
                {
                    isRestart = true;
                    playerCont.transform.position = origPos;
                    hp = 3;
                    isDone = false;
                    win = false;
                    float wait = Time.deltaTime;
                    if(wait == 1){
                        isRestart = false;
                        wait = 0;
                    }
                }
                if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 30), "BACK TO MAIN MENU"))
                {
                    backToMain = true;
                }
                if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 30), "QUIT"))
                {
                    Application.Quit();
                }
            }
        }
    }
}
