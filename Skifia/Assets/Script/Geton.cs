using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Geton : MonoBehaviour
{
    public float duration;
    bool istrun = false;
    public bool Face = true;
    IEnumerator RotateCube(Quaternion Quaternion)
    {
        if (istrun)
        {
            Quaternion startRotation = transform.rotation;
            Quaternion endRotation = startRotation * Quaternion;
            float elapsedTime = 0.0f;

            while (elapsedTime < duration)
            {
                transform.rotation = Quaternion.Slerp(startRotation, endRotation, (elapsedTime / duration));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.rotation = endRotation; 
            istrun = false;
        }
    }
    public void Turn()
    {
        if(istrun == false)
        {
            istrun = true;
            StartCoroutine(RotateCube(Quaternion.Euler(0, 180, -90)));
            Face = !Face;
        }
    }
    public void rotateRight()
    {
        if(istrun == false)
        {
            istrun = true;
            if(Face)
                StartCoroutine(RotateCube(Quaternion.Euler(0, 0, -90)));
            else
                StartCoroutine(RotateCube(Quaternion.Euler(0, 0,90)));
        }
    }
    public void rotateLeft()
    {
        if(istrun == false)
        {
            istrun = true;
            if (Face)
                StartCoroutine(RotateCube(Quaternion.Euler(0, 0, 90)));
            else
                StartCoroutine(RotateCube(Quaternion.Euler(0, 0, -90)));
        }
    }
}
