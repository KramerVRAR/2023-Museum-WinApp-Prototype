using UnityEngine;
using TMPro;

// Класс для десериализации JSON
[System.Serializable]
public class ObjectData
{
    public string name;
    public string description;
}

[System.Serializable]
public class ObjectInfo
{
    public ObjectData[] objects;
}

public class ObjectInfoLoader : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public TextAsset jsonFile;
    private ObjectData[] objectData;

    private void Start()
    {
        ObjectInfo objectInfo = JsonUtility.FromJson<ObjectInfo>(jsonFile.text);
        objectData = objectInfo.objects;
        if (objectData.Length > 0)
        {
            FillTextFields(0);
        }
    }
    public void FillTextFields(int objectIndex)
    {
        if (objectIndex >= 0 && objectIndex < objectData.Length)
        {
            nameText.text = objectData[objectIndex].name;
            descriptionText.text = objectData[objectIndex].description;
        }
    }
}
