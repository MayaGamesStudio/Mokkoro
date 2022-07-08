using UnityEngine;

public class JumpMGManager : MonoBehaviour {

    #region singleton
    public static JumpMGManager Instance { get; private set; }

    private void Awake() {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    #endregion

    public int platformsCount;
    public GameObject player;
    public float loosingOffset;

    private float currentHeight = -3.5f;

    // Start is called before the first frame update
    void Start() {
        for(int i = 0; i < platformsCount; i++) {
            var maxRandom = 1;
            if(i > 30) {
                maxRandom = 3;
            } else if(i > 10) {
                maxRandom = 2;
            }
            CreatePlatform(maxRandom);
        }
    }

    private void Update() {
        if(player.transform.position.y < Camera.main.transform.position.y - loosingOffset) {
            GameOver();
        }
    }

    public void CreatePlatform(int maxRandom = 3) {
        var x = Random.Range(-6f,6f);
        var random = Random.Range(0,maxRandom);
        GameObject platformPrefab = null;
        switch(random) {
            case 0:
                platformPrefab = PlatformsObjectPool.Instance.CommonPlatfomsPool.Get();
                break;
            case 1:
                platformPrefab = PlatformsObjectPool.Instance.MovingPlatfomsPool.Get();
                break;
            case 2:
                platformPrefab = PlatformsObjectPool.Instance.BrokenPlatfomsPool.Get();
                break;
        }
        platformPrefab.transform.position = new Vector3(x,currentHeight);
        currentHeight += 4;
    }

    private void GameOver() {
        Debug.Log("GameOver");
    }
}
