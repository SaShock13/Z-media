using UnityEngine;
/// <summary>
/// делаем максимально квадратную сетку
/// </summary>
public class BoxFormation : IFormation
{
    public Vector3 GetLocalPosition(int index, int total, float spacing, float buildSideX )
    {
        int columns = Mathf.CeilToInt(Mathf.Sqrt(total));
        columns = Mathf.Max(1, columns);
        int rows = Mathf.CeilToInt((float)total / columns);
        int row = index / columns; 
        int col = index % columns; 
        float x = -col * spacing * buildSideX;
        float offsetY = (rows - 1) * 0.5f * spacing;
        float y = row * spacing - offsetY;
        return new Vector3(x, y, 0f);
    }
}
