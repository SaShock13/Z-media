using UnityEngine;

[CreateAssetMenu(menuName = "Units/Size")]
public class UnitSizeSO : ScriptableObject
{
    public string Id;
    public Vector3 ViewScale = Vector3.one;


    public int HpDelta;
    public int AtkDelta;
    public float SpeedDelta;
    public float AtkSpeedDelta;
}