using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;


public class MainMenu : MonoBehaviour
{
 
    public AudioSource src;

    public Vector2 playerPosition;
    public VectorValue playerStorage;

    public LevelLoader levelLoader;

    //public AudioClip sfx1;
    // Start is called before the first frame update
    public void PlayGame(){
        playerStorage.initalValue = playerPosition;
        levelLoader.LoadNextLevel("office");
    }

    public void Hover(){
        //src.clip=sfx1;
        src.Play();
    }
   
    
    public void QuitGame(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying=false;
        #else
        Application.Quit();
        #endif
    }

    
}
