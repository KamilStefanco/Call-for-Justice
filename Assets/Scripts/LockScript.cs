using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScript : MonoBehaviour
{
    public KeyCode unlockKey = KeyCode.E;

    private bool isPlayerColliding = false;
    public GameObject instructions;
    public GameObject backpack;
    public GameObject needKey;

    public KeyTaker keyTaker;
    public bool isLocked=true;

    void Update()
    {
        if (isPlayerColliding && Input.GetKeyDown(unlockKey))
        {
            
            if(keyTaker.playerhasKey){
                Unlock();
            }
        
        }
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {   
            
            if(keyTaker.playerhasKey){
                instructions.SetActive(true);
            }else{
                needKey.SetActive(true);
            }
            isPlayerColliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            instructions.SetActive(false);
            needKey.SetActive(false);
            isPlayerColliding = false;
        }
    }

    void Unlock()
    {
        isLocked=false;
        // Deactivate the GameObject
        gameObject.SetActive(false);
        backpack.SetActive(false);
    }
}
