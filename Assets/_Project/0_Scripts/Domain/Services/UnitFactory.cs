
/// <summary>
/// Фабрика юнитов. Из базы данных берет данные и создает случайного юнита
/// </summary>
public class UnitFactory
{
    private int _id;
    private readonly UnitDatabaseSO _db;
    private readonly System.Random _rng;

    public UnitFactory(UnitDatabaseSO db, int seed)
    {
        _db = db;
        _rng = new System.Random(seed);
    }

    public UnitModel CreateRandom(int teamId)
    {
        var baseStats = _db.BaseStats.CreateStats();
        var color = _db.GetRandomColor(_rng);
        var shape = _db.GetRandomShape(_rng);
        var size = _db.GetRandomSize(_rng);
        // применяем модификаторы
        baseStats.ApplyDelta(color.HpDelta, color.AtkDelta, color.SpeedDelta, color.AtkSpeedDelta);
        baseStats.ApplyDelta(shape.HpDelta, shape.AtkDelta, shape.SpeedDelta, shape.AtkSpeedDelta);
        baseStats.ApplyDelta(size.HpDelta, size.AtkDelta, size.SpeedDelta, size.AtkSpeedDelta);
        return new UnitModel(++_id, teamId, baseStats, color, shape, size);
    }
}