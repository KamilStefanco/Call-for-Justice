using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGameControl : MonoBehaviour
{
    [SerializeField]
    private Transform[] pictures;
    public float tolerance; // Nastaviteľná tolerancia v stupňoch

    public float idealRotation; // Ideálna rotácia

    public bool youWin; // Odstránil som statický modifikátor pre prístup z iných skriptov

    public GameObject panel;

    public LevelLoader levelLoader;

    void Start()
    {
        youWin = false;
        panel.SetActive(false);
    }

    public void CheckWinCondition()
    {
        youWin = AreAllPicturesWithinTolerance();

        if(youWin){
            panel.SetActive(true);
        }
    }

    bool AreAllPicturesWithinTolerance()
    {
        foreach (Transform picture in pictures)
        {
            if (!IsPictureWithinTolerance(picture))
            {
                return false; // Ak aspoň jeden obrázok nie je v tolerancii
            }
        }
        return true; // Všetky obrázky sú v tolerancii
    }

    bool IsPictureWithinTolerance(Transform picture)
    {
        
        float angle = picture.eulerAngles.z % 360;
        if (angle > 180) angle -= 360; // Normalizácia uhla na rozsah -180 až 180 stupňov

        // Vypočítanie rozdielu uhla od ideálnej rotácie
        float angleDifference = Mathf.Abs(angle - idealRotation);

        // Kontrola, či je rozdiel uhla v rámci povolenej tolerancie
        return angleDifference <= tolerance;
    }
    void Update()
    {
        if(youWin && Input.GetKeyDown(KeyCode.E)){
            levelLoader.LoadNextLevel("budova vrazdy 2");
        }
    }
}
