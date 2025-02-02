using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAfterTime : MonoBehaviour
{

    public LevelLoader levelLoader;
    public GameObject image;

    public Vector2 playerPosition;
    public VectorValue playerStorage;

    public float time;

    public string scene;

    IEnumerator Start()
    {

        yield return new WaitForSeconds(time);

        image.SetActive(true);
        playerStorage.initalValue = playerPosition;

        if (levelLoader != null)
        {
            levelLoader.LoadNextLevel(scene);
        }
        else
        {
            Debug.LogError("Referencia na objekt LevelLoader nie je nastavená.");
        }
    }

    void Update()
    {
        
    }
}
