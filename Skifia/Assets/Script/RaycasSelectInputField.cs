using UnityEngine;

public class RaycasSelectInputField : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private int _numberOfInputFile;
    private void Start()
    {
        PlayerPrefs.SetInt("Raycast", 0);
    }
    private void OnMouseDown()
    {
        PlayerPrefs.SetInt("Raycast", _numberOfInputFile); 
        _gameManager.InputFieldText.Select();
    }
}
