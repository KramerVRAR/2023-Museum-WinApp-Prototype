using UnityEngine;

public class MapScroll : MonoBehaviour
{
    public RectTransform map;
    public RectTransform content;

    private Vector2 contentStartPosition;
    private Vector2 contentSize;
    private Vector2 mapSize;
    private Vector2 minContentPosition;
    private Vector2 maxContentPosition;

    private void Start()
    {
        contentStartPosition = content.anchoredPosition;
        contentSize = content.sizeDelta;
        mapSize = map.sizeDelta;

        // Вычисляем минимальную и максимальную позицию "Content" внутри "Map"
        minContentPosition = Vector2.zero;
        maxContentPosition = mapSize - contentSize;
    }

    private void LateUpdate()
    {
        // Получаем текущую позицию "Content"
        Vector2 contentPosition = content.anchoredPosition;

        // Ограничиваем позицию по осям X и Y в пределах "Map"
        contentPosition.x = Mathf.Clamp(contentPosition.x, minContentPosition.x, maxContentPosition.x);
        contentPosition.y = Mathf.Clamp(contentPosition.y, minContentPosition.y, maxContentPosition.y);

        // Применяем новую позицию "Content"
        content.anchoredPosition = contentPosition;
    }
}
