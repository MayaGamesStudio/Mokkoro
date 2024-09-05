using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class KitchenHandler : MonoBehaviour
{
    public static KitchenHandler Instance { get; private set; }

    public Image ConsumableImage;
    public Sprite NoConsumableAvailableImage;

    private Inventory Inventory;
    public ItemSO CurrentItem { get; set; }

    private void Awake() {
        if(Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        Inventory = Inventory.Instance;
        CurrentItem = Inventory.itemsList[0];
        ConsumableImage.sprite = CurrentItem.Sprite;
    }

    public void GetNextItem() {
        var items = Inventory.items.Keys.ToList();

        if (items.Count == 0) return;
        if (items.Count == 1) CurrentItem = items[0];
        else {
            for(int i = 0; i < items.Count; i++) {
                var item = items[i];
                if(item.Equals(CurrentItem)) {
                    CurrentItem = i == items.Count - 1 ? items[0] : items[i + 1];
                    break;
                }
            }
        }

        ConsumableImage.sprite = CurrentItem.Sprite;
    }

    public void GetPreviousItem() {
        var items = Inventory.items.Keys.ToList();

        if (items.Count == 0) return;
        if (items.Count == 1) CurrentItem = items[0];
        else {
            for (int i = 0; i < items.Count; i++) {
                var item = items[i];
                if (item.Equals(CurrentItem)) {
                    CurrentItem = (i == 0) ? items[items.Count - 1] : items[i - 1];
                    break;
                }
            }
        }

        ConsumableImage.sprite = CurrentItem.Sprite;
    }

    public void NoMoreItems() {
        ConsumableImage.sprite = NoConsumableAvailableImage;
        GetComponentInChildren<Consumable>().enabled = false;
    }

    public void HaveItemsAgain() {
        GetComponentInChildren<Consumable>().enabled = true;
        GetNextItem();
    }
}
