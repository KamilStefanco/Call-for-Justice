using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    // Start is called before the first frame update


    public Vector2 playerPosition;
    public VectorValue playerStorage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerStorage.initalValue = playerPosition;
        }
    }
}
