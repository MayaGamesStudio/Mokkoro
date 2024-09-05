using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour {
    private Image Fill;

    public StatusEnum StatusName;
    public float MaxValue;
    public float CurrentValue { get; set; }

    public float TimeBeforeStartDecreasing;
    private float TimeToStartDecreasing;

    public float DecreasingFactor;

    public float MediumHealthMultiplier;
    public float HighHealthMultiplier;

    private void Start() {
        CurrentValue = MaxValue;
        Fill = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        TimeToStartDecreasing = TimeBeforeStartDecreasing;
    }

    private void Update() {
        TimeToStartDecreasing -= Time.deltaTime;

        if(TimeToStartDecreasing <= 0) {
            CurrentValue -= Time.deltaTime * DecreasingFactor;
        }
        Fill.fillAmount = CurrentValue/MaxValue;
    }

    public void HealthUpdate(float multiplier) {
        CurrentValue -= Time.deltaTime * multiplier;
        if(CurrentValue >= MaxValue) {
            CurrentValue = MaxValue;
        }
    }

    public void IncreaseValue(float amount) {
        CurrentValue = CurrentValue + amount >= MaxValue ? MaxValue : CurrentValue + amount;
        TimeToStartDecreasing = TimeBeforeStartDecreasing;
    }
}
