using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{

    public bool isPlayerColliding= false;

    public LevelLoader levelLoader;
    public string nextScene;

    public Vector2 playerPosition;
    public VectorValue playerStorage;

      public GameObject image;

    void Update()
    {
        if(isPlayerColliding){
            levelLoader.LoadNextLevel(nextScene);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            if(image != null){
                image.SetActive(true);
            }
            playerStorage.initalValue = playerPosition;
            isPlayerColliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            isPlayerColliding = false;
        }
    }
}
