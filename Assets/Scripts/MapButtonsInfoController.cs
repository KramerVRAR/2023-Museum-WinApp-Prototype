using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapButtonsInfoController : MonoBehaviour
{

    public void OpenInfo(int number)
    {
        this.transform.localScale = new Vector3(1,1,1);
        this.GetComponent<ObjectInfoLoader>().FillTextFields(number);
        this.GetComponent<ObjectImageLoader>().LoadImageByNumber(number+1);
    }

}
