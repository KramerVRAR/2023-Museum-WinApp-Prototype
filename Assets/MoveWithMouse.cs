using UnityEngine;
using UnityEngine.EventSystems;

public class MoveWithMouse : MonoBehaviour
{

    private RectTransform mapRectTransform;
    private Vector2 pointerOffset;
    private bool isDragging = false;
    private float scaleFactor = 1.0f; // ��������� ���������� ��� ���������������

    private void Awake()
    {
        mapRectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (isDragging)
        {
            MoveMapWithMouse();
            ClampMapPosition(); // �������� ����� ��� ����������� ������� �����
        }
    }

    private void OnMouseDown()
    {
        Vector2 localCursor;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(mapRectTransform, Input.mousePosition, null, out localCursor);

        // ������������� offset ��� ��������� ��������
        Vector2 pivotOffset = new Vector2(mapRectTransform.pivot.x * mapRectTransform.rect.width, mapRectTransform.pivot.y * mapRectTransform.rect.height);
        pointerOffset = mapRectTransform.anchoredPosition - (localCursor * scaleFactor + pivotOffset);

        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void MoveMapWithMouse()
    {
        Vector2 localCursor;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(mapRectTransform.parent as RectTransform, Input.mousePosition, null, out localCursor);
        mapRectTransform.anchoredPosition = localCursor * scaleFactor + pointerOffset;
    }

    private void ClampMapPosition()
    {
        // ��� ��� ����������� ������� �����, ��� �������� � ���������� �������
    }
}
/*
������� ��������� �� ���������� ��������� �������. ��������� ����������� ������ ������ � ������� ����� ������. � ������ ������, �� ����� ������������ ��������� ScrollRect, ������� ��������� ��������� ����� ��� � Google Maps.

    �������� ����� ������ GameObject � �������� ��� "Map".
    �������� �� ���� ��������� RectTransform, ����� ������ ������� � ������� �����.
    �������� �� ���� ��������� Image ��� RawImage, ����� ���������� �����. ��� �������������, ���������� ������ ��� �������� ��� �����������.
    �������� �� ���� ��������� ScrollRect.
    �������� ��� ���� ������ GameObject � �������� ��� "Content".
    �������� �� ���� ��������� RectTransform, ����� ������ ������� � ������� ��������.
    ���������� "Content" ��� �������� ��������� Content � ���������� ScrollRect.
    ��������� ��������� ���������� ScrollRect ��������� �������:
        ���������� Horizontal � Vertical � �������� true, ����� ��������� ��������� ��� �� �����������, ��� � �� ���������.
        ���������� Movement Type � �������� Unrestricted, ����� ��������� ��������� ����������� �����.
        ���������� Inertia � �������� true, ����� ���������� ����������� ���������.
        ���������� Deceleration Rate � �������� 0.1, ����� ������ �������� ���������� ����� �����������.
        ���������� Scroll Sensitivity � �������� 10, ����� ��������� ���������������� ���������.
    ���������� ��� �������, ������� ������ ���������� �� �����, ������ "Content". �������� ��������, ��� ��� ����� ������ ����� ��������� RectTransform � ���� ��������� �� ��������� � "Content".
    ���������, ��� ������� "Content" ������ �������� "Map", ����� ��������� ���������.
    ��������� ����� � ���������, ��� ����� ������������ � �������������� ��� ���������.

������, ����� � ��� ���� "Map" � ScrollRect, �� ������ ������������ � ��������������, ��� � Google Maps. ���� ��� ����� ���������� ����������� ����� ������ � ������������ ��������, �� ������ ��������� ����������� � �������.
*/