using UnityEngine;

[CreateAssetMenu(menuName = "Units/Base Stats")]
public class UnitBaseStatsSO : ScriptableObject
{
    public int BaseHP = 100;
    public int BaseATK = 10;
    public float BaseSPEED = 10f;
    public float BaseATKSPD = 1f;


    public Stats CreateStats()
    {
        return new Stats
        {
            MaxHP = BaseHP,
            CurrentHP = BaseHP,
            ATK = BaseATK,
            SPEED = BaseSPEED,
            ATKSPD = BaseATKSPD
        };
    }
}