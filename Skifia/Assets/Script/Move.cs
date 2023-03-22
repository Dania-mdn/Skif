using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Geton geton;
    public RectTransform Up;
    public RectTransform duwn;
    public bool face;
    public void fg()
    {
        if (face)
        {
            if (geton.Face)
                startUp();
            else
                startDown();
        }
        else
        {
            if (geton.Face) 
                startDown();
            else
                startUp();
        }
    }
    public void startUp()
    {
        StartCoroutine(MuveUp());
    }
    public void startDown()
    {
        StartCoroutine(MuveDuwn());
    }
    IEnumerator MuveUp()
    {
        Vector2 startPos = this.transform.position;

        float duration = 1;
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector2.Lerp(startPos, Up.position, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator MuveDuwn()
    {
        Vector2 startPos = this.transform.position;

        float duration = 1;
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector2.Lerp(startPos, duwn.position, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
