using UnityEngine;
using UnityEngine.UI;

public class ObjectImageLoader : MonoBehaviour
{
    public RawImage rawImage;
    public void LoadImageByNumber(int number)
    {
        string formattedNumber = number.ToString("D2");
        string imagePath = "Photos/Info" + formattedNumber + "_01";
        Texture2D loadedTexture = Resources.Load<Texture2D>(imagePath);
        if (loadedTexture != null)
        {
            rawImage.texture = loadedTexture;
        }
        else
        {
            Debug.LogError("Failed to load image: " + imagePath);
        }
    }
}