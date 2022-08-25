using UnityEngine;
using System.Collections;

public class GenericObjectPool : MonoBehaviour {
    #region singleton
    public static GenericObjectPool Instance { get; protected set; }
    protected virtual void Awake() {
        if(Instance == null) {
            Instance = this;
        } else Destroy(gameObject);
    }
    #endregion

    [SerializeField] protected Transform parent;
    [SerializeField] protected GameObject[] prefabs;

    // Called when an item is returned to the pool using Release
    protected virtual void OnReturnedToPool(GameObject gameobject) {
        gameobject.SetActive(false);
    }

    // Called when an item is taken from the pool using Get
    protected virtual void OnTakeFromPool(GameObject gameobject) {
        gameobject.SetActive(true);
    }

    // If the pool capacity is reached then any items returned will be destroyed.
    // We can control what the destroy behavior does, here we destroy the GameObject.
    protected virtual void OnDestroyPoolObject(GameObject gameobject) {
        Destroy(gameobject);
    }
}
