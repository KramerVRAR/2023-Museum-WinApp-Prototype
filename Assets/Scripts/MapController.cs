using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MapController : MonoBehaviour, IDragHandler, IScrollHandler
{
    private RectTransform mapRectTransform;
    private Vector2 mapStartPosition;
    private Vector2 pointerStartPosition;
    private float minScale = 1f;
    private float maxScale = 1.5f;
    private float zoomSpeed = 0.1f;

    void Start()
    {
        mapRectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (mapRectTransform.localScale.x > minScale)
        {
            mapRectTransform.anchoredPosition += eventData.delta;
            ClampMapPosition();
        }
    }

    public void OnScroll(PointerEventData eventData)
    {
        float newScale = mapRectTransform.localScale.x + eventData.scrollDelta.y * zoomSpeed;
        newScale = Mathf.Clamp(newScale, minScale, maxScale);

        Vector2 pointerPosition = GetPointerPosition(eventData.position);

        mapRectTransform.localScale = Vector3.one * newScale;
        mapRectTransform.anchoredPosition += (pointerPosition - mapStartPosition) * (newScale - 1f);

        ClampMapPosition();
    }

    private Vector2 GetPointerPosition(Vector2 screenPosition)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(mapRectTransform, screenPosition, null, out localPoint);
        return localPoint;
    }

    private void ClampMapPosition()
    {
        Vector2 mapSize = mapRectTransform.rect.size * mapRectTransform.localScale.x;
        Vector2 parentSize = mapRectTransform.parent.GetComponent<RectTransform>().rect.size;
        Vector2 minPosition = (parentSize - mapSize) / 2f;
        Vector2 maxPosition = (mapSize - parentSize) / 2f;

        mapRectTransform.anchoredPosition = new Vector2(
            Mathf.Clamp(mapRectTransform.anchoredPosition.x, minPosition.x, maxPosition.x),
            Mathf.Clamp(mapRectTransform.anchoredPosition.y, minPosition.y, maxPosition.y)
        );
    }

    public void ZoomIn()
    {
        float newScale = mapRectTransform.localScale.x + zoomSpeed;
        newScale = Mathf.Clamp(newScale, minScale, maxScale);

        Vector2 center = new Vector2(0.5f, 0.5f);
        mapRectTransform.anchoredPosition += (center - mapStartPosition) * (newScale - mapRectTransform.localScale.x);

        mapRectTransform.localScale = Vector3.one * newScale;
        ClampMapPosition();
    }

    public void ZoomOut()
    {
        float newScale = mapRectTransform.localScale.x - zoomSpeed;
        newScale = Mathf.Clamp(newScale, minScale, maxScale);

        Vector2 center = new Vector2(0.5f, 0.5f);
        mapRectTransform.anchoredPosition += (center - mapStartPosition) * (newScale - mapRectTransform.localScale.x);

        mapRectTransform.localScale = Vector3.one * newScale;
        ClampMapPosition();
    }
}
