using UnityEngine;
using UnityEngine.EventSystems;

public class MoveWithMouse : MonoBehaviour
{

    private RectTransform mapRectTransform;
    private Vector2 pointerOffset;
    private bool isDragging = false;
    private float scaleFactor = 1.0f; // Добавляем переменную для масштабирования

    private void Awake()
    {
        mapRectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (isDragging)
        {
            MoveMapWithMouse();
            ClampMapPosition(); // Вызываем метод для ограничения позиции карты
        }
    }

    private void OnMouseDown()
    {
        Vector2 localCursor;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(mapRectTransform, Input.mousePosition, null, out localCursor);

        // Пересчитываем offset при изменении масштаба
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
        // Код для ограничения позиции карты, как показано в предыдущих ответах
    }
}
/*
Приношу извинения за предыдущие неудачные попытки. Позвольте попробовать другой подход к решению вашей задачи. В данном случае, мы будем использовать компонент ScrollRect, который обеспечит прокрутку карты как в Google Maps.

    Создайте новый пустой GameObject и назовите его "Map".
    Добавьте на него компонент RectTransform, чтобы задать размеры и позицию карты.
    Добавьте на него компонент Image или RawImage, чтобы отображать карту. При необходимости, установите спрайт или текстуру для изображения.
    Добавьте на него компонент ScrollRect.
    Создайте еще один пустой GameObject и назовите его "Content".
    Добавьте на него компонент RectTransform, чтобы задать размеры и позицию контента.
    Установите "Content" как значение параметра Content в компоненте ScrollRect.
    Настройте параметры компонента ScrollRect следующим образом:
        Установите Horizontal и Vertical в значение true, чтобы разрешить прокрутку как по горизонтали, так и по вертикали.
        Установите Movement Type в значение Unrestricted, чтобы разрешить свободное перемещение карты.
        Установите Inertia в значение true, чтобы обеспечить инерционную прокрутку.
        Установите Deceleration Rate в значение 0.1, чтобы задать скорость замедления после перемещения.
        Установите Scroll Sensitivity в значение 10, чтобы настроить чувствительность прокрутки.
    Разместите все объекты, которые должны находиться на карте, внутри "Content". Обратите внимание, что они также должны иметь компонент RectTransform и быть дочерними по отношению к "Content".
    Убедитесь, что размеры "Content" больше размеров "Map", чтобы допустить прокрутку.
    Запустите сцену и убедитесь, что карта перемещается и прокручивается как ожидалось.

Теперь, когда у вас есть "Map" с ScrollRect, он должен перемещаться и прокручиваться, как в Google Maps. Если вам нужно ограничить перемещение карты только в определенных пределах, вы можете настроить ограничение в скрипте.
*/