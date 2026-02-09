using UnityEngine;

[CreateAssetMenu(menuName = "Units/Shape")]
public class UnitShapeSO : ScriptableObject
{
    public string Id;
    public UnitView Prefab;
    public int HpDelta;
    public int AtkDelta;
    public float SpeedDelta;
    public float AtkSpeedDelta;
}