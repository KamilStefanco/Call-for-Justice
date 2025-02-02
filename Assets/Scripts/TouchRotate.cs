using UnityEngine;

public class TouchRotate : MonoBehaviour
{
    public float sensitivity = 0.4f; // Citlivosť otáčania
    private Vector3 mouseReference;
    private Vector3 mouseOffset;
    private bool isRotating;
    public PuzzleGameControl puzzleGameControl; // Referencia na PuzzleGameControl

    void Start()
    {
        // Získanie referencie na PuzzleGameControl
        puzzleGameControl = FindObjectOfType<PuzzleGameControl>();
    }

    void Update()
    {
        if (isRotating)
        {
            mouseOffset = (Input.mousePosition - mouseReference);
            float rotationZ = -(mouseOffset.x + mouseOffset.y) * sensitivity;
            transform.Rotate(0, 0, rotationZ);
            mouseReference = Input.mousePosition;
        }
    }

    private void OnMouseDown()
    {
        // Overí, či hra ešte nebola vyhraná pred začatím otáčania
        if (!puzzleGameControl.youWin)
        {
            isRotating = true;
            mouseReference = Input.mousePosition;
        }
    }

    private void OnMouseUp()
    {
        isRotating = false;
        // Po uvoľnení myši zavolá metódu na kontrolu výherných podmienok
        puzzleGameControl.CheckWinCondition();
    }
}