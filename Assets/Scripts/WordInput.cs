using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordInput : MonoBehaviour {

    public WordManager wordManager;

    void Update() {
        foreach (char letter in Input.inputString) {
            wordManager.TypeLetter(letter);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            QuitGame();
        }
    }

    void QuitGame() {
        Debug.Log("Quit Game");
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
