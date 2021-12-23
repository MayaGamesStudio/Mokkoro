
using System.Collections.Generic;

public interface IHaveLevel {
    public int Level { get; set; }
    public int CurrentExp { get; set; }
    public int ExpToNextLevel { get; set; }
    public Dictionary<int, int> Levels { get; set; }
    public void LevelUp();
}
