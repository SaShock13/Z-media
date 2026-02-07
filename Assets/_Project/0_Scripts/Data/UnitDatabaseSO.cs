using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Units/Database")]
public class UnitDatabaseSO : ScriptableObject
{
    public UnitBaseStatsSO BaseStats;


    public List<UnitColorSO> Colors;
    public List<UnitShapeSO> Shapes;
    public List<UnitSizeSO> Sizes;


    public UnitColorSO GetRandomColor(System.Random rng) => Colors[rng.Next(Colors.Count)];
    public UnitShapeSO GetRandomShape(System.Random rng) => Shapes[rng.Next(Shapes.Count)];
    public UnitSizeSO GetRandomSize(System.Random rng) => Sizes[rng.Next(Sizes.Count)];
}