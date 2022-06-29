using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private Vector3 originalAnchoredPosition;

    public virtual void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
    }

    public virtual void OnDrag(PointerEventData eventData) {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public virtual void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        rectTransform.anchoredPosition = originalAnchoredPosition;
    }
    
    void Start() {
        rectTransform = GetComponent<RectTransform>();
        originalAnchoredPosition = rectTransform.anchoredPosition;
    }
}
