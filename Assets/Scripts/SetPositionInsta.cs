using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionInsta : MonoBehaviour
{
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerStorage.initalValue = playerPosition;
    }
}
