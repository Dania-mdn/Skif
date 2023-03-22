using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class CreateWishiwanka : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI money;
    [SerializeField] private TextMeshProUGUI InputText;
    [SerializeField] private SpawnChar SpawnLiters;
    private string MyText;
    public TMP_InputField inputField;
    public TMP_InputField inputField1;
    [SerializeField] private TextMeshPro[] InputText1;
    private void Start()
    {
        inputField.onValueChanged.AddListener(OnValueChanged);
        inputField1.onValueChanged.AddListener(OnValueChanged1);
    }
    public void SaveInputText()
    {
        MyText = InputText.text;
        SpawnLiters.MyText = MyText;
    }
    public void Delete()
    {
        EventManager.DoDelete();
        EventManager.DoCreateFalse();
    }
    private void OnValueChanged(string text)
    {
        inputField.text = Regex.Replace(text, "[^À-ßà-ÿ¨¸²³¯¿ªº¥´\\s]", "");
    }
    private void OnValueChanged1(string text)
    {
        inputField1.text = Regex.Replace(text, "[^A-Za-zÀ-ßà-ÿ0123456789\\s]", "");
        InputText1[PlayerPrefs.GetInt("Raycast")].text = inputField1.text;
    }
    public void Money()
    {
        System.Random ran = new System.Random();
        int i = ran.Next(1, 1000);
        money.text = i.ToString() + "$";
    }
}
