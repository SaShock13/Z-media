using UnityEngine;
/// <summary>
/// Клиновидная формация
/// </summary>
public class WedgeFormation : IFormation
{
    public Vector3 GetLocalPosition(int index, int total, float spacing, float buildSideX)
    {
        int row = 0;
        int startIndexOfRow = 0;

        while (true)
        {
            int rowSize = row + 1;
            int endExclusive = startIndexOfRow + rowSize;
            if (index < endExclusive)
                break;
            startIndexOfRow = endExclusive;
            row++;
        }
        int rowSizeFinal = row + 1;
        int indexInRow = index - startIndexOfRow;
        float centered = indexInRow - (rowSizeFinal - 1) * 0.5f;
        float y = centered * spacing;
        float x = -row * spacing * buildSideX;
        return new Vector3(x, y, 0f);
    }
}
