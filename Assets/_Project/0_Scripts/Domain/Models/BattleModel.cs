using System;

public class BattleModel
{
    public ArmyModel ArmyA { get; }
    public ArmyModel ArmyB { get; }


    public event Action<int> BattleFinished; // победившая команда


    public BattleModel(ArmyModel a, ArmyModel b)
    {
        ArmyA = a;
        ArmyB = b;


        ArmyA.ArmyDefeated += OnArmyDefeated;
        ArmyB.ArmyDefeated += OnArmyDefeated;
    }


    private void OnArmyDefeated(ArmyModel defeated)
    {
        int winner = defeated.TeamId == ArmyA.TeamId ? ArmyB.TeamId : ArmyA.TeamId;
        BattleFinished?.Invoke(winner);
    }
}