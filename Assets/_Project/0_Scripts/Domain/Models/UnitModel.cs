/// <summary>
/// Модель юнита: хранит статы + ссылки на конфиги.
/// Важно: ссылки на SO допустимы (это read-only конфигурация).
/// </summary>
public class UnitModel
{
    public int Id { get; }
    public int TeamId { get; }


    public Stats Stats;


    public UnitColorSO Color;
    public UnitShapeSO Shape;
    public UnitSizeSO Size;


    public UnitModel(int id, int teamId, Stats stats, UnitColorSO color, UnitShapeSO shape, UnitSizeSO size)
    {
        Id = id;
        TeamId = teamId;
        Stats = stats;
        Color = color;
        Shape = shape;
        Size = size;
    }
}