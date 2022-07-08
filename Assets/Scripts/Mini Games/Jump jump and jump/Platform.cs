using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {
    public PlatformTypeEnum platformType;

    protected virtual void Update() {
        if(transform.position.y < Camera.main.transform.position.y - 15) {
            switch(platformType) {
                case PlatformTypeEnum.COMMON:
                    PlatformsObjectPool.Instance.CommonPlatfomsPool.Release(gameObject);
                    break;
                case PlatformTypeEnum.MOVING:
                    PlatformsObjectPool.Instance.MovingPlatfomsPool.Release(gameObject);
                    break;
                case PlatformTypeEnum.BROKEN:
                    PlatformsObjectPool.Instance.BrokenPlatfomsPool.Release(gameObject);
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
