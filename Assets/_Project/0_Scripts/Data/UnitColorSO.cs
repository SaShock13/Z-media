using UnityEngine;

[CreateAssetMenu(menuName = "Units/Color")]
public class UnitColorSO : ScriptableObject
{
    public string Id;
    public Color ViewColor = Color.white;
    public int HpDelta;
    public int AtkDelta;
    public float SpeedDelta;
    public float AtkSpeedDelta;
}