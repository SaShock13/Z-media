using System.Collections.Generic;

public class ArmyFactory
{
    private readonly UnitFactory _unitFactory;


    public ArmyFactory(UnitFactory unitFactory)
    {
        _unitFactory = unitFactory;
    }


    public ArmyModel Create(int teamId, int count)
    {
        var units = new List<UnitModel>(count);
        for (int i = 0; i < count; i++)
            units.Add(_unitFactory.CreateRandom(teamId));


        return new ArmyModel(teamId, units);
    }
}