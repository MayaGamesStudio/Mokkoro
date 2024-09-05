using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform target;
    public float yOffset;

    private Camera mainCamera;

    private void Start() {
        mainCamera = Camera.main;
    }

    private void LateUpdate() {
        if(mainCamera.transform.position.y > target.position.y + yOffset) return;

        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x,target.position.y + yOffset,mainCamera.transform.position.z);
    }
}
