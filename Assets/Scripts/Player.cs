using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHaveLevel {
    public string Name { get; set; }
    public List<Mokkoro> Mokkoros { get; set; }

    public int Level { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int CurrentExp { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int ExpToNextLevel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Dictionary<int, int> Levels { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void LevelUp() {
        throw new System.NotImplementedException();
    }
}
