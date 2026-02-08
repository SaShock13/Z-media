using UnityEngine;

public interface IFormation
{
    /// <summary>
    /// Возвращает позицию локал координат юнита относительно root.
    /// </summary>
    Vector3 GetLocalPosition(int index, int total, float spacing, float buildSideX);
}