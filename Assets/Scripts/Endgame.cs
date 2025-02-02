using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; // Include this if you plan to load a scene on game over.

public class Endgame : MonoBehaviour {

   
    void Update() {
        Transform transformComponent = GetComponent<Transform>();
        float posY = transformComponent.position.y;
        if(posY < -4.937553) {
            Debug.Log("KONIEC");
            WordGenerator.ResetIndex(); // Resetujeme currentIndex pred načítaním scény
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }   
    }
}