using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GalleryImageLoader : MonoBehaviour
{
    public RawImage rawImage;
    public RawImage currentImageInInfo;
    public int targetHeight = 720;

    private Texture2D[] loadedTextures;
    private int currentIndex = 0;
    public string message;

    public void LoadImagesByMessage()
    {
        message = currentImageInInfo.texture.name;
        currentIndex = 0;
         List<Texture2D> texturesList = new List<Texture2D>();

        Object[] loadedImages = Resources.LoadAll("Photos", typeof(Texture2D));
        foreach (Object image in loadedImages)
        {
            Texture2D texture = (Texture2D)image;
            message = message.Substring(0,6);
            Debug.Log(texture.name);
            if (texture.name.Length >= 6 && texture.name.Substring(0, 6) == message)
            {
                texturesList.Add(texture);
            }
        }

        loadedTextures = texturesList.ToArray();
        if (loadedTextures.Length > 0)
        {
            DisplayImageAtIndex(currentIndex);
        }
        else
        {
            Debug.LogWarning("No images found for the message: " + message);
        }

    }

    private void DisplayImageAtIndex(int index)
    {
        Texture2D texture = loadedTextures[index];
        int targetWidth = Mathf.FloorToInt((float)texture.width * targetHeight / texture.height);
        rawImage.texture = texture;
        rawImage.rectTransform.sizeDelta = new Vector2(targetWidth, targetHeight);
    }

    public void NextImage()
    {
        if (loadedTextures.Length == 0) return;

        currentIndex = (currentIndex + 1) % loadedTextures.Length;
        DisplayImageAtIndex(currentIndex);
    }

    public void PreviousImage()
    {
        if (loadedTextures.Length == 0) return;

        currentIndex = (currentIndex - 1 + loadedTextures.Length) % loadedTextures.Length;
        DisplayImageAtIndex(currentIndex);
    }
}