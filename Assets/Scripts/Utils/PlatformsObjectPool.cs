﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;

public class PlatformsObjectPool : MonoBehaviour {
    #region singleton
    public static PlatformsObjectPool Instance { get; protected set; }
    private void Awake() {
        if(Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }
    #endregion

    [SerializeField] private Transform platforms;
    [SerializeField] private GameObject commonPlatformPrefab;
    public ObjectPool<GameObject> CommonPlatfomsPool { get; set; }

    [SerializeField] private GameObject movingPlatformPrefab;
    public ObjectPool<GameObject> MovingPlatfomsPool { get; set; }

    [SerializeField] private GameObject brokenPlatformPrefab;
    public ObjectPool<GameObject> BrokenPlatfomsPool { get; set; }

    // Use this for initialization
    void Start() {
        CommonPlatfomsPool = new ObjectPool<GameObject>(() => Instantiate(commonPlatformPrefab,platforms),OnTakeFromPool,OnReturnedToPool,OnDestroyPoolObject);
        MovingPlatfomsPool = new ObjectPool<GameObject>(() => Instantiate(movingPlatformPrefab,platforms),OnTakeFromPool,OnReturnedToPool,OnDestroyPoolObject);
        BrokenPlatfomsPool = new ObjectPool<GameObject>(() => Instantiate(brokenPlatformPrefab,platforms),OnTakeFromPool,OnReturnedToPool,OnDestroyPoolObject);
    }

    // Called when an item is returned to the pool using Release
    void OnReturnedToPool(GameObject system) {
        system.gameObject.SetActive(false);
        JumpMGManager.Instance.CreatePlatform();
    }

    // Called when an item is taken from the pool using Get
    void OnTakeFromPool(GameObject system) {
        system.gameObject.SetActive(true);
    }

    // If the pool capacity is reached then any items returned will be destroyed.
    // We can control what the destroy behavior does, here we destroy the GameObject.
    void OnDestroyPoolObject(GameObject system) {
        Destroy(system.gameObject);
    }
}
