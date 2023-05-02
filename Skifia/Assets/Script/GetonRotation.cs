using System.Collections;
using UnityEngine;

public class GetonRotation : MonoBehaviour
{
    [SerializeField] private float _duration;
    private bool _isturn = false;
    private bool _isTurnedFace = true;
    public void Turn()
    {
        if(_isturn == false)
        {
            _isturn = true;
            EventManager.DoTurn(_isTurnedFace);
            StartCoroutine(RotateCube(Quaternion.Euler(0, 180, -90)));
            _isTurnedFace = !_isTurnedFace;
        }
    }
    public void rotationLeft()
    {
        if(_isturn == false)
        {
            _isturn = true;
            if(_isTurnedFace)
                StartCoroutine(RotateCube(Quaternion.Euler(0, 0, -90)));
            else
                StartCoroutine(RotateCube(Quaternion.Euler(0, 0,90)));
        }
    }
    public void rotationRight()
    {
        if(_isturn == false)
        {
            _isturn = true;
            if (_isTurnedFace)
                StartCoroutine(RotateCube(Quaternion.Euler(0, 0, 90)));
            else
                StartCoroutine(RotateCube(Quaternion.Euler(0, 0, -90)));
        }
    }
    IEnumerator RotateCube(Quaternion Quaternion)
    {
        if (_isturn)
        {
            Quaternion startRotation = transform.rotation;
            Quaternion endRotation = startRotation * Quaternion;
            float elapsedTime = 0.0f;

            while (elapsedTime < _duration)
            {
                transform.rotation = Quaternion.Slerp(startRotation, endRotation, (elapsedTime / _duration));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.rotation = endRotation;
            _isturn = false;
        }
    }
}
