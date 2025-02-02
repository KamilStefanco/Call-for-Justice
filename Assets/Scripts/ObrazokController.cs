using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObrazokController : MonoBehaviour
{
    public GameObject hra;

    public GameObject panel;
    public bool isPlayerColliding= false;

    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public GameObject player;

    public GameObject image;

    void Start()
    {
        hra.SetActive(false);
    }

    void Update()
    {
        if(isPlayerColliding && Input.GetKeyDown(KeyCode.E)){
            playerStorage.initalValue = playerPosition;
            panel.SetActive(false);
            hra.SetActive(true);
            PlayerMovement movementScript = player.GetComponent<PlayerMovement>();

            movementScript.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            panel.SetActive(true);
            image.SetActive(false);
            isPlayerColliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            panel.SetActive(false);
            isPlayerColliding = false;
        }
    }
}
