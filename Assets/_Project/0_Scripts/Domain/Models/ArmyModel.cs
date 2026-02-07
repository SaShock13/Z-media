using System.Collections.Generic;

using System;
using System.Linq;

/// <summary>
/// Модель армии: хранит список юнитов.
/// </summary>
public class ArmyModel
{
    public int TeamId { get; }
    public List<UnitModel> Units { get; }


    public event Action<ArmyModel> ArmyDefeated;


    public ArmyModel(int teamId, List<UnitModel> units)
    {
        TeamId = teamId;
        Units = units;
    }


    public int AliveCount => Units.Count(u => !u.Stats.IsDead);


    public void CheckDefeat()
    {
        if (AliveCount <= 0)
            ArmyDefeated?.Invoke(this);
    }
}