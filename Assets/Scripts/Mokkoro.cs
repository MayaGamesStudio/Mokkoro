using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mokkoro : MonoBehaviour, IHaveLevel {
    public string Name { get; set; }
    public Dictionary<AttributesEnum, int> Attributes { get; set; }
    public Dictionary<StatusEnum, Status> Statuses { get; set; }
    public TypesEnum Type { get; set; }
    public ElementsEnum Element { get; set; }

    public int Level { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int CurrentExp { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int ExpToNextLevel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Dictionary<int, int> Levels { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void LevelUp() {
        throw new System.NotImplementedException();
    }

    private void Update() {
        
    }
}
