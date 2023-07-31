using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWaitingScreen : MonoBehaviour
{
    public void Close()
    {
        GetComponent<Animation>().Play();
        StartCoroutine( deactivateObject(GetComponent<Animation>().clip.length) );
    }
    IEnumerator deactivateObject(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        this.gameObject.SetActive(false);
    }
}
