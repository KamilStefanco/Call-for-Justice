using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGameScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void backToMenu(){
        SceneManager.LoadScene("Menu");
    }
}
