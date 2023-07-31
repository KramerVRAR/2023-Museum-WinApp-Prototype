using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryController : MonoBehaviour
{  
    public void Open()
    {
        StopCoroutine("SmoothChangeSize");
        StartCoroutine(SmoothChangeSize(new Vector3(1, 1, 1), 2f));
    }

    public void Close()
    {
        StopCoroutine("SmoothChangeSize");
        StartCoroutine(SmoothChangeSize(new Vector3(0, 0, 0), 2f));
    }

    private IEnumerator SmoothChangeSize(Vector3 targetSize, float duration)
    {
        Vector3 startSize = transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(startSize, targetSize, elapsedTime / duration);

            elapsedTime += Time.deltaTime;

            yield return null; 
        }
        transform.localScale = targetSize;
    }
}