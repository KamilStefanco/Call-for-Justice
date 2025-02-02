using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using UnityEditor;

public class DoorAfterLockpick : MonoBehaviour
{
    
    public KeyCode openKey = KeyCode.E;

    public RuntimeAnimatorController openDoor;

    private bool isOpen = false;
    public Animator animator;
    BoxCollider2D colliderBox;

    public GameObject instructions;

    public Vector2 playerPosition;
    public VectorValue playerStorage;

    

    void Start(){
        colliderBox=GetComponent<BoxCollider2D>();
        colliderBox.enabled=true;
        
        if(animator==null){
            animator = GetComponent<Animator>();
        }
    }

    public void GoNextScene(){
        SceneManager.LoadScene("LockPick");
    }
   

    void Update()
    {
        if (Input.GetKeyDown(openKey) && isPlayerColliding)
        {   
            playerStorage.initalValue = playerPosition;
            GoNextScene();
            if (!isOpen)
            {

                OpenDoor();
            }
        }
    }

    private bool isPlayerColliding = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(!isOpen){
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
            animator.runtimeAnimatorController = openDoor;
            colliderBox.enabled = false;
            isOpen = true;
        }


   
}

