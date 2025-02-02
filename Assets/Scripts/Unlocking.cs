using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEditor;

public class Unlocking : MonoBehaviour
{
    
    public KeyCode openKey = KeyCode.Space;
    GameObject redBodka;
    private int counter=0;
    public GameObject message;
    public GameObject controllsMessage;
    void Update()
    {
        if (Input.GetKeyDown(openKey)&&isIntersect)
        {
            counter++;
            Destroy(redBodka);
            if(counter==3){
                controllsMessage.SetActive(false);
                message.SetActive(true);
                //WAIT FOR 1SECOND
                //change scene on scene named "PrisonScene"
                GoNextScene();   
            }
        }
    }

    public void GoNextScene(){
        SceneManager.LoadScene("PrisonSceneOpened");
    }

   private bool isIntersect = false;   


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("green"))
        {
            redBodka=other.gameObject;
            isIntersect = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("green"))
        {
            isIntersect = false;
        }
    }

    
        


   
}