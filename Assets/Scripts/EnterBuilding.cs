using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBuilding : MonoBehaviour
{

    public bool isPlayerColliding= false;

    public LevelLoader levelLoader;

    public GameObject panel;

    public string nextScene;

    public Vector2 playerPosition;
    public VectorValue playerStorage;

    public GameObject image;

    void Update()
    {
        if(isPlayerColliding && Input.GetKeyDown(KeyCode.E)){
            if(image != null){
                image.SetActive(true);
            }

            panel.SetActive(false);
            levelLoader.LoadNextLevel(nextScene);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerStorage.initalValue = playerPosition;
            panel.SetActive(true);
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
