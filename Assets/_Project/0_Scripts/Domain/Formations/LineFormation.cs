using UnityEngine;

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

        int row = index / _columns; // вверх/вниз
        int col = index % _columns; // глубина

        // X: глубина, всегда "назад" от root
        float x = -col * spacing * buildSideX;

        // Y: центрируем по вертикали
        float offsetY = (rows - 1) * 0.5f * spacing;
        float y = row * spacing - offsetY;

        return new Vector3(x, y, 0f);
    }
}
