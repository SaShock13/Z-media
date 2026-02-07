using UnityEngine;

public enum ShapePrefabType
{
    Cube,
    Sphere
}


[CreateAssetMenu(menuName = "Units/Shape")]
public class UnitShapeSO : ScriptableObject
{
    public string Id;
    public ShapePrefabType PrefabType;


    public int HpDelta;
    public int AtkDelta;
    public float SpeedDelta;
    public float AtkSpeedDelta;
}