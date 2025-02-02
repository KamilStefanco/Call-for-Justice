using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableImage : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject image;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            image.SetActive(false);
        }
    }
}
