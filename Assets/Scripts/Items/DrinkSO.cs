using UnityEngine;

[CreateAssetMenu(fileName = "Drink", menuName = "Items/Drink")]
public class DrinkSO : ItemSO {
    public int Amount;

    public override void Use(Mokkoro mokkoro) {
        mokkoro.Drink(Amount);
        base.Use(mokkoro);
    }
}
