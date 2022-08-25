using UnityEngine;
using UnityEngine.Pool;

public class PlatformsObjectPool : GenericObjectPool {
    protected override void Awake() {
        base.Awake();
        CommonPlatfomsPool = new ObjectPool<GameObject>(() => Instantiate(prefabs[0],parent),OnTakeFromPool,OnReturnedToPool,OnDestroyPoolObject);
        MovingPlatfomsPool = new ObjectPool<GameObject>(() => Instantiate(prefabs[1],parent),OnTakeFromPool,OnReturnedToPool,OnDestroyPoolObject);
        BrokenPlatfomsPool = new ObjectPool<GameObject>(() => Instantiate(prefabs[2],parent),OnTakeFromPool,OnReturnedToPool,OnDestroyPoolObject);
    }

    public ObjectPool<GameObject> CommonPlatfomsPool { get; set; }
    public ObjectPool<GameObject> MovingPlatfomsPool { get; set; }
    public ObjectPool<GameObject> BrokenPlatfomsPool { get; set; }
}
