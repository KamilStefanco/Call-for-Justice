using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTaker : MonoBehaviour
{
    public KeyCode takeKeyKey = KeyCode.E;

    private bool isPlayerColliding = false;
    public GameObject instructions;
    public GameObject backpack;

    public bool playerhasKey=false;

    public GameObject image;

    void Update()
    {
        if (isPlayerColliding && Input.GetKeyDown(takeKeyKey))
        {
            TakeKey();
        }
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {       
            image.SetActive(true);
            instructions.SetActive(true);
            isPlayerColliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            instructions.SetActive(false);
            isPlayerColliding = false;
        }
    }

    void TakeKey()
    {
        playerhasKey=true;      // Deactivate the GameObject
        gameObject.SetActive(false);
        backpack.SetActive(true);
    }
}
