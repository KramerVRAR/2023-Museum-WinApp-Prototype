using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoController : MonoBehaviour
{
    public float transitionDuration = 2f;

    public void Open(int number)
    {
        StartCoroutine(SmoothOpenInfo(number));
    }

    public void Close()
    {
        StartCoroutine(SmoothCloseInfo());
    }

    private IEnumerator SmoothOpenInfo(int number)
    {

        this.GetComponent<ObjectInfoLoader>().FillTextFields(number);
        this.GetComponent<ObjectImageLoader>().LoadImageByNumber(number + 1);

        float timer = 0f;
        Vector3 initialScale = this.transform.localScale;
        Vector3 targetScale = new Vector3(1f, 1f, 1f);

        while (timer < transitionDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / transitionDuration);
            this.transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            yield return null;
        }

        this.transform.localScale = targetScale;


    }

    private IEnumerator SmoothCloseInfo()
    {
        float timer = 0f;
        Vector3 initialScale = this.transform.localScale;
        Vector3 targetScale = new Vector3(0f, 0f, 0f);

        while (timer < transitionDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / transitionDuration);
            this.transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            yield return null;
        }

        this.transform.localScale = targetScale;
    }
}
