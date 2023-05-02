using TMPro;
using UnityEngine;
using System.Text.RegularExpressions;

public class GameManager : MonoBehaviour
{
    [Header("Dembroidery")]
    [SerializeField] private TMP_InputField _mainInputField;
    [SerializeField] private CreateDembroidery _createDembroidery;

    [Header("InputField")]
    public TMP_InputField InputFieldText;
    [SerializeField] private TextMeshPro[] TargetInputFieldText;

    [SerializeField] private TextMeshProUGUI _priceForCreate;
    private void Start()
    {
        _mainInputField.onValueChanged.AddListener(OnValueChangedForMainInputField);
        InputFieldText.onValueChanged.AddListener(OnValueChangedForInputFieldText);
    }
    public void SaveInputText()
    {
        _createDembroidery.TextForCreateDembroidery = _mainInputField.text;
    }
    public void Delete()
    {
        EventManager.DoDelete();
        EventManager.DoCreateFalse();
    }
    private void OnValueChangedForMainInputField(string text)
    {
        _mainInputField.text = Regex.Replace(text, "[^À-ßà-ÿ¨¸²³¯¿ªº¥´\\s]", "");
    }
    private void OnValueChangedForInputFieldText(string text)
    {
        InputFieldText.text = Regex.Replace(text, "[^A-Za-zÀ-ßà-ÿ0123456789\\s]", "");
        TargetInputFieldText[PlayerPrefs.GetInt("Raycast")].text = InputFieldText.text;
    }
    public void SetPriceForCreate()
    {
        System.Random randomValue = new System.Random();
        _priceForCreate.text = randomValue.Next(1, 1000).ToString() + "$";
    }
}
