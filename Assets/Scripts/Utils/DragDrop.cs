using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] protected Canvas canvas;

    protected RectTransform rectTransform;
    protected Vector3 originalAnchoredPosition;

    protected virtual void Start() {
        rectTransform = GetComponent<RectTransform>();
        originalAnchoredPosition = rectTransform.anchoredPosition;
        Debug.Log("Start!!");
    }

    public virtual void OnPointerDown(PointerEventData eventData) {
        //Debug.Log("OnPointerDown");
    }

    public virtual void OnDrag(PointerEventData eventData) {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public virtual void OnEndDrag(PointerEventData eventData) {
        //Debug.Log("OnEndDrag");
        rectTransform.anchoredPosition = originalAnchoredPosition;
    }

    private void OnEnable() {
        if(rectTransform != null)
            rectTransform.anchoredPosition = originalAnchoredPosition;
    }
}
