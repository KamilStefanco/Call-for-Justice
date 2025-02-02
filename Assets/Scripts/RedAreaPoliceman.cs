using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedAreaPoliceman : MonoBehaviour
{
    public GameObject bustedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoNextScene(){
        SceneManager.LoadScene("PrisonScene");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(BustedAfterDelay());
        }
    }

    IEnumerator BustedAfterDelay()
    {
        bustedObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        bustedObject.SetActive(false);
        GoNextScene();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
