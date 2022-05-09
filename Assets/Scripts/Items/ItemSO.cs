using UnityEngine;

public abstract class ItemSO : ScriptableObject
{
    public Sprite Sprite;
    public string Name;
    public string Description;
    public int Price;

    public virtual void Use(Mokkoro mokkoro) {
        KitchenHandler.Instance.GetPreviousItem();
        Inventory.Instance.RemoveItem(this);
    }
}
