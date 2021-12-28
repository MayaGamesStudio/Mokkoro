using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Mokkoro : MonoBehaviour, IHaveLevel {
    public string Name { get; set; }
    public Dictionary<AttributesEnum, int> Attributes { get; set; }

    [SerializeField] private GameObject StatusesContainer;
    public Dictionary<StatusEnum, Status> Statuses { get; set; }

    public TypesEnum Type { get; set; }
    public ElementsEnum Element { get; set; }

    public int Level { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int CurrentExp { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int ExpToNextLevel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Dictionary<int, int> Levels { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void LevelUp() {
        throw new System.NotImplementedException();
    }

    private void Start() {
        Statuses = new Dictionary<StatusEnum, Status>();
        foreach(var status in StatusesContainer.GetComponentsInChildren<Status>()) {
            Statuses.Add(status.StatusName, status);
        }
    }

    private void Update() {
        CheckStatuses();
    }

    private void CheckStatuses() {
        var healthMultiplier = 0f;
        Status healthStatus = null;

        foreach(var status in Statuses.Values) {
            if(StatusEnum.HEALTH.Equals(status.StatusName)) {
                healthStatus = status;
                continue;
            }
            var statusPerc = status.CurrentValue / status.MaxValue;
            if(statusPerc <= 0) {
                healthMultiplier += status.HighHealthMultiplier;
            } else if(statusPerc <= 0.5) {
                healthMultiplier += status.MediumHealthMultiplier;
            } else if(statusPerc <= 0.75) {
                healthMultiplier -= status.MediumHealthMultiplier;
            } else {
                healthMultiplier -= status.HighHealthMultiplier;
            }
        }
        Debug.Log(healthMultiplier);
        healthStatus.HealthUpdate(healthMultiplier);
    }

    public void Feed() {
        Statuses[StatusEnum.HUNGRY].IncreaseValue(20);
    }

    public void Drink() {
        Statuses[StatusEnum.THIRSTY].IncreaseValue(20);
    }

    public void Sleep() {
        Statuses[StatusEnum.FATIGUE].IncreaseValue(20);
    }

    public void Play() {
        Statuses[StatusEnum.HAPPINESS].IncreaseValue(20);
    }

    public void Clean() {
        Statuses[StatusEnum.CLEANLINESS].IncreaseValue(20);
    }
}
