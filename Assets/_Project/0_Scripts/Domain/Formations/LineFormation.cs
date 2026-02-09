using UnityEngine;

/// <summary>
/// Вертикальная линейная формация в 2 колонны
/// </summary>
public class LineFormation : IFormation
{
    private readonly int _columns;

    public LineFormation(int columns = 2)
    {
        _columns = Mathf.Max(1, columns);
    }

    public Vector3 GetLocalPosition(int index, int total, float spacing, float buildSideX)
    {
        int rows = Mathf.CeilToInt((float)total / _columns);
        int row = index / _columns; 
        int col = index % _columns;
        float x = -col * spacing * buildSideX;
        float offsetY = (rows - 1) * 0.5f * spacing;
        float y = row * spacing - offsetY;
        return new Vector3(x, y, 0f);
    }
}
