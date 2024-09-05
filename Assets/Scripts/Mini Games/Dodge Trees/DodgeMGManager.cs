using UnityEngine;
using System.Collections;

public class DodgeMGManager : MiniGamesManager {
    public float timeToSpawnTree;
    private float timeSinceLastTreeSpawn = 0;

    public Transform spawnTreePosition;

    public float ScrollingSpeed;

    // Update is called once per frame
    void Update() {
        var direction = (Camera.main.transform.position + Vector3.right);
        Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position,direction,ScrollingSpeed);
        timeSinceLastTreeSpawn += Time.deltaTime;
        if(timeSinceLastTreeSpawn >= timeToSpawnTree) {
            SpawnTree();
            timeSinceLastTreeSpawn = 0;
        }
    }

    private void SpawnTree() {
        var tree = ((TreesObjectPool) GenericObjectPool.Instance).TreeObjectPool.Get();
        tree.transform.position = spawnTreePosition.position;
    }
}
