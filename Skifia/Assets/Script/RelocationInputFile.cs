using System.Collections;
using UnityEngine;

public class RelocationInputFile : MonoBehaviour
{
    [SerializeField] private GetonRotation _getonGameObject;
    [SerializeField] private RectTransform _positionUp;
    [SerializeField] private RectTransform _positionDuwn;
    [SerializeField] private InputName _inputName;
    private void OnEnable()
    {
        EventManager.Turn += CheckRotation;
    }
    private void OnDisable()
    {
        EventManager.Turn -= CheckRotation;
    }
    public void CheckRotation(bool turn)
    {
        if (turn)
        {
            if(_inputName == InputName.MainInput)
                StartCoroutine(Relocation(_positionDuwn.position));
            else
                StartCoroutine(Relocation(_positionUp.position));
        }
        else
        {
            if (_inputName == InputName.InputFieldText)
                StartCoroutine(Relocation(_positionDuwn.position));
            else
                StartCoroutine(Relocation(_positionUp.position));
        }
    }
    IEnumerator Relocation(Vector2 endPosition)
    {
        Vector2 startPos = this.transform.position;

        float duration = 1;
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector2.Lerp(startPos, endPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    public enum InputName { MainInput, InputFieldText }
}
