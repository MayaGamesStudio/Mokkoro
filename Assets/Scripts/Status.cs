using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour {
    public Image Fill;
    public StatusEnum StatusName;
    public float MaxValue;
    public float CurrentValue { get; set; }
    public float DecreasingFactor;

    private void Start() {
        CurrentValue = MaxValue;
    }

    private void Update() {
        CurrentValue -= Time.deltaTime * DecreasingFactor;
        Fill.fillAmount = CurrentValue/MaxValue;
    }
}
