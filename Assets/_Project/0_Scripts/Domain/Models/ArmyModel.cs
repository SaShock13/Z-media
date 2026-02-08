using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Модель армии: хранит список юнитов.
/// </summary>
public class ArmyModel
{
    public int TeamId { get; }
    public List<UnitModel> Units { get; }

    //  Формация армии 
    public FormationType Formation { get; private set; }

    public event Action<ArmyModel> ArmyDefeated;
    public event Action<FormationType> FormationChanged;

    public ArmyModel(int teamId, List<UnitModel> units, FormationType formationType)
    {
        TeamId = teamId;
        Units = units;
        Formation = formationType;
    }

    public int AliveCount => Units.Count(u => !u.Stats.IsDead);

    public void CheckDefeat()
    {
        if (AliveCount <= 0)
            ArmyDefeated?.Invoke(this);
    }

    public void SetFormation(FormationType newFormationType)
    {
        if(newFormationType == Formation) return;
        Formation = newFormationType;
        FormationChanged?.Invoke(Formation);
    }
}