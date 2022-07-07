using UnityEngine;

public class JumpMGManager : MonoBehaviour {
    public GameObject[] platformsPrefab;
    public int platformsCount;
    public Transform platforms;
    public GameObject player;
    public float loosingOffset;

    // Start is called before the first frame update
    void Start() {
        var height = -4.5f;
        for(int i = 0; i < platformsCount; i++) {
            var x = Random.Range(-4.5f,4.5f);
            var platformPrefab = platformsPrefab[0];
            if(i > 30) {
                platformPrefab = platformsPrefab[Random.Range(0,3)];
            } else if(i > 10) {
                platformPrefab = platformsPrefab[Random.Range(0,2)];
            } 
            Instantiate(platformPrefab,new Vector3(x,height),Quaternion.identity,platforms);
            height += 5;
        }
    }

    private void Update() {
        if(player.transform.position.y < Camera.main.transform.position.y - loosingOffset) {
            GameOver();
        }
    }

    private void GameOver() {
        Debug.Log("GameOver");
    }
}
