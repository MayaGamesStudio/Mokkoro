using UnityEngine;
using UnityEngine.Pool;

public class TreesObjectPool : GenericObjectPool {
    protected override void Awake() {
        base.Awake();
        TreeObjectPool = new ObjectPool<GameObject>(() => Instantiate(prefabs[0],parent),OnTakeFromPool,OnReturnedToPool,OnDestroyPoolObject);
    }

    public ObjectPool<GameObject> TreeObjectPool { get; set; }
}
