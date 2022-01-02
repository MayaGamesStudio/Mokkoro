using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Soap : DragDrop
{
    public override void OnDrag(PointerEventData eventData) {
        base.OnDrag(eventData);

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("OnTriggerEnter2D");
    }

    private void OnTriggerStay2D(Collider2D collision) {
        Debug.Log("OnTriggerStay2D");
        if(collision.CompareTag("Mokkoro")) {
            var mokkoro = collision.GetComponent<Mokkoro>();
            mokkoro.Clean(10);
        }
    }
}
