using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Soap : DragDrop
{
    [SerializeField] private GameObject bubble;

    public override void OnDrag(PointerEventData eventData) {
        base.OnDrag(eventData);

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("OnTriggerEnter2D");
    }

    private void OnTriggerStay2D(Collider2D collision) {
        Debug.Log("OnTriggerStay2D");
        if(collision.CompareTag("Mokkoro")) {
            Instantiate(bubble, this.transform.position, Quaternion.identity, collision.gameObject.transform);
            var mokkoro = collision.GetComponent<Mokkoro>();
            mokkoro.Clean(10);
        }
    }
}
