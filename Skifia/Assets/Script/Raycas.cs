using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycas : MonoBehaviour
{
    public CreateWishiwanka createWishiwanka;
    public int ID;
    private void Start()
    {
        PlayerPrefs.SetInt("Raycast", 0);
    }
    private void OnMouseDown()
    {
        PlayerPrefs.SetInt("Raycast", ID); 
        createWishiwanka.inputField1.Select();
    }
}
