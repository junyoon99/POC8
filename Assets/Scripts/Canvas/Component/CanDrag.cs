using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CanDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;

    private Vector2 pointerOffset;

    Vector2 beforePos;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = transform.root.GetComponentInParent<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("Canvas not found in parent hierarchy.");
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle( canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localPointerPosition);

        pointerOffset = rectTransform.localPosition - (Vector3)localPointerPosition;
        beforePos = rectTransform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle( canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localPointerPosition);

        rectTransform.localPosition = localPointerPosition + pointerOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // �巡���� ������Ʈ�� ��ġ�� UI Slot�� �ִ��� �˻�
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = eventData.position;

        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, results);

        foreach (var result in results)
        {
            Slot slot = result.gameObject.GetComponent<Slot>();
            if (slot != null)
            {
                rectTransform.position = slot.transform.position;
                transform.SetParent(slot.transform);
                return;
            }
        }

        // �ƹ� Slot���� ��ġ�� ������ ���� ��ġ��
        rectTransform.position = beforePos;
    }
}
