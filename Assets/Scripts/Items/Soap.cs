using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Soap : DragDrop
{
    [SerializeField] private GameObject bubble;

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.CompareTag("Mokkoro")) {
            Instantiate(bubble, transform.position, Quaternion.identity, collision.gameObject.transform);
            var mokkoro = collision.GetComponent<Mokkoro>();
            mokkoro.Clean(10);
        }
    }
}
