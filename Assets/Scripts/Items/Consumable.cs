using UnityEngine;
using UnityEngine.EventSystems;

public class Consumable : DragDrop
{
    private Mokkoro mokkoroSelected;

    public override void OnEndDrag(PointerEventData eventData) {
        base.OnEndDrag(eventData);
        if(mokkoroSelected) {
            var itemSO = KitchenHandler.Instance.CurrentItem;
            itemSO.Use(mokkoroSelected);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Mokkoro")) {
            mokkoroSelected = collision.GetComponent<Mokkoro>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Mokkoro")) {
            mokkoroSelected = null;
        }
    }
}
