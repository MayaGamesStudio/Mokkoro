using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetsManager : MonoBehaviour {
    #region singleton
    public static PetsManager Instance { get; private set; }

    private void Awake() {
        if(Instance == null) {
            Instance = this;
        }
    }
    #endregion

    [SerializeField] private Mokkoro startPet;
    public Mokkoro CurrentPet { get; private set; }

    private void Start() {
        CurrentPet = startPet;    
    }
}
