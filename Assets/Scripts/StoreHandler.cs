using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreHandler : MonoBehaviour
{
    [SerializeField] private Sprite SoldSprite;
    [SerializeField] private string PathToItemSO;
    public GameObject SlotsContainer;

    public Dictionary<GameObject, ItemSO> SlotsDictionary;
    private GameObject SelectedSlot;

    [Space]
    [Header("Item Description")]
    public Image ItemDescImage;
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemDescription;
    public TextMeshProUGUI ItemPriceText;


    private void Start() {
        SlotsDictionary = new Dictionary<GameObject, ItemSO>();
        var allExistingItems = Resources.LoadAll<ItemSO>(PathToItemSO);

        foreach(Transform slot in SlotsContainer.transform) {
            AddItemToStore(slot.gameObject, allExistingItems[Random.Range(0, allExistingItems.Length)]);
        }
    }

    private void AddItemToStore(GameObject slot, ItemSO item) {
        var image = slot.GetComponent<Image>();
        var priceText = slot.GetComponentInChildren<TextMeshProUGUI>();
        image.sprite = item.Sprite;
        priceText.text = item.Price.ToString();
        if (SlotsDictionary.ContainsKey(slot)) SlotsDictionary[slot] = item;
        else SlotsDictionary.Add(slot, item);
    }

    private void RemoveFromStore() {
        SlotsDictionary[SelectedSlot] = null;
        var image = SelectedSlot.GetComponent<Image>();
        var priceText = SelectedSlot.GetComponentInChildren<TextMeshProUGUI>();
        image.sprite = SoldSprite;
        priceText.text = "---";
    }

    public void OpenDescription(GameObject slot) {
        var item = SlotsDictionary[slot];
        SelectedSlot = slot;
        ItemDescImage.sprite = item.Sprite;
        ItemName.text = item.Name;
        ItemDescription.text = item.Description;
        ItemPriceText.text = item.Price.ToString();
    }

    public void BuyItem() {
        Inventory.Instance.AddItem(SlotsDictionary[SelectedSlot]);
        RemoveFromStore();
    }
}
