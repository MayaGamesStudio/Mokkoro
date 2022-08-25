using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {
    public PlatformTypeEnum platformType;
    private PlatformsObjectPool objectPool;

    protected virtual void Start() {
        objectPool = (PlatformsObjectPool) GenericObjectPool.Instance;
    }
    
    protected virtual void Update() {
        if(transform.position.y < Camera.main.transform.position.y - 15) {
            switch(platformType) {
                case PlatformTypeEnum.COMMON:
                    objectPool.CommonPlatfomsPool.Release(gameObject);
                    break;
                case PlatformTypeEnum.MOVING:
                    objectPool.MovingPlatfomsPool.Release(gameObject);
                    break;
                case PlatformTypeEnum.BROKEN:
                    objectPool.BrokenPlatfomsPool.Release(gameObject);
                    break;
            }
            
        }
    }
}

public enum PlatformTypeEnum {
    COMMON,
    MOVING,
    BROKEN
}
