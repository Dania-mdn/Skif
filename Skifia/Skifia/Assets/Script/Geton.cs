using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Geton : MonoBehaviour
{
    public float duration;
    bool istrun = false;
    IEnumerator RotateCube()
    {
        if (istrun)
        {
            Quaternion startRotation = transform.rotation;
            Quaternion endRotation = startRotation * Quaternion.Euler(0, 180, 0);
            float elapsedTime = 0.0f;

            while (elapsedTime < duration)
            {
                transform.rotation = Quaternion.Slerp(startRotation, endRotation, (elapsedTime / duration));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.rotation = endRotation; istrun = false;
        }
    }
    public void Turn()
    {
        if(istrun == false)
        {
            istrun = true;
            StartCoroutine(RotateCube());
        }
    }
}
