using UnityEngine;
using System.Collections;
using TMPro;

public class MiniGamesManager : MonoBehaviour {
    #region singleton
    public static MiniGamesManager Instance { get; private set; }

    private void Awake() {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    #endregion

    public GameObject player;

    public TextMeshProUGUI scoreText;
    protected int score = 0;

    public TextMeshProUGUI finalScoreText;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
