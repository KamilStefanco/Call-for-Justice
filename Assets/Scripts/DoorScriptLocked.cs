using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScriptLocked : MonoBehaviour
{
    
    public KeyCode openKey = KeyCode.E;

    public RuntimeAnimatorController openDoor;

    private bool isOpen = false;
    public Animator animator;
    BoxCollider2D colliderBox;

    public GameObject instructions;

    public LockScript locked;
    public AudioClip sfx1;
    public AudioSource src;
    
    
    void Start(){
        colliderBox=GetComponent<BoxCollider2D>();
        colliderBox.enabled=true;
        
        if(animator==null){
            animator = GetComponent<Animator>();
        }
    }


   

    void Update()
    {
        if (Input.GetKeyDown(openKey) && isPlayerColliding)
        {
            if (!isOpen&&locked.isLocked==false)
            {
                Debug.Log("halo");
                OpenDoor();
            }
        }
    }

    private bool isPlayerColliding = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(!isOpen&&locked.isLocked==false){
                instructions.SetActive(true);
            }
            isPlayerColliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(instructions!=null){
                instructions.SetActive(false);
            }
            isPlayerColliding = false;
        }
    }

    
        void OpenDoor()
        {
            src.clip=sfx1;
            src.Play();
            animator.runtimeAnimatorController = openDoor;
            colliderBox.enabled = false;
            isOpen = true;
        }


   
}