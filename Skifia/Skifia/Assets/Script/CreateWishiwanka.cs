using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class CreateWishiwanka : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI InputText;
    [SerializeField] private SpawnChar SpawnLiters;
    private string MyText;
    public TMP_InputField inputField;
    private void Start()
    {
        inputField.onValueChanged.AddListener(OnValueChanged);
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
}
