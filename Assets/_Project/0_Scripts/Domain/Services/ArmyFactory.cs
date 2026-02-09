using System.Collections.Generic;
/// <summary>
/// Фабрика армии - создает юнитов через фабрики , добавляет в армию и ее возвращает
/// </summary>
public class ArmyFactory
{
    private readonly UnitFactory _unitFactory;

    public ArmyFactory(UnitFactory unitFactory)
    {
        _unitFactory = unitFactory;
    }

    public ArmyModel Create(int teamId, int count, FormationType formationType)
    {
        var units = new List<UnitModel>(count);

        for (int i = 0; i < count; i++)
        {
            UnitModel unit = _unitFactory.CreateRandom(teamId);
            units.Add(unit);
        }
        return new ArmyModel(teamId, units, formationType);
    }
}