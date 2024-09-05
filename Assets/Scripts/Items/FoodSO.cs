using UnityEngine;

[CreateAssetMenu(fileName = "Food", menuName = "Items/Food")]
public class FoodSO : ItemSO
{
    public int Amount;

    public override void Use(Mokkoro mokkoro) {
        mokkoro.Feed(Amount);
        base.Use(mokkoro);
    }
}
