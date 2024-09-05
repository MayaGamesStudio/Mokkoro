using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    public ItemSO[] itemsList;
    public Dictionary<ItemSO, int> items { get; private set; }

    private void Awake() {
        if(Instance == null) {
            Instance = this;
            items = new Dictionary<ItemSO, int>();
            foreach (var itemSO in itemsList) items.Add(itemSO, 1);
        } else {
            Destroy(gameObject);
        }
    }

    public void AddItem(ItemSO item) {
        if(items.TryGetValue(item, out int quantity)) {
            items[item] = quantity + 1;
        } else {
            items.Add(item, 1);
            if(items.Count == 1) {
                KitchenHandler.Instance.HaveItemsAgain();
            }
        }
    }

    public void RemoveItem(ItemSO item) {
        var total = -1;
        if (items.TryGetValue(item, out int quantity)) {
            total += quantity;
        } else {
            Debug.Log("Item does not exist!");
            return;
        }
        if(total > 0) {
            items[item] = total;
        } else {
            items.Remove(item);
            if(items.Keys.Count == 0) {
                var kitchenHandler = KitchenHandler.Instance;
                kitchenHandler.NoMoreItems();
            }
        }
    }
}
