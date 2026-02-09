using UnityEngine;
/// <summary>
/// Хаотичная формация
/// </summary>
public class ChaoticFormation : IFormation
{
    private readonly float width;
    private readonly float height;
    private readonly System.Random _random;

    public ChaoticFormation(float width = 5f, float height = 5f, int seed = 0)
    {
        this.width = width;
        this.height = height;
        _random = seed == 0 ? new System.Random() : new System.Random(seed);
    }

    public Vector3 GetLocalPosition(int index, int total, float spacing, float buildSideX )
    {
        float depth = (float)_random.NextDouble() * width;
        float x = -depth * buildSideX;

        float y = (float)_random.NextDouble() * height - height * 0.5f;

        return new Vector3(x, y, 0f);

    }
}
