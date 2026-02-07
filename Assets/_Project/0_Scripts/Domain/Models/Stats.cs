using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats 
{
    public int MaxHP;
    public int CurrentHP;
    public int ATK;
    public float SPEED;
    public float ATKSPD;
    public bool IsDead => CurrentHP <= 0;

    public void ApplyDelta(int hp, int atk, float speed, float atkSpd)
    {
        MaxHP += hp;
        CurrentHP += hp;
        ATK += atk;
        SPEED += speed;
        ATKSPD += atkSpd;

        // защитные ограничения
        if (MaxHP < 1) MaxHP = 1;
        if (CurrentHP > MaxHP) CurrentHP = MaxHP;
        if (CurrentHP < 0) CurrentHP = 0;
        if (ATK < 0) ATK = 0;
        if (SPEED < 0.1f) SPEED = 0.1f;
        if (ATKSPD < 0.05f) ATKSPD = 0.05f;
    }

    public void TakeDamage(int damage)
    {

        Debug.Log($"before CurrentHP {CurrentHP}");
        Debug.Log($"TakeDamage {damage}");
        if (damage < 0) damage = 0;
        CurrentHP -= damage;
        if (CurrentHP < 0) CurrentHP = 0;
        Debug.Log($"after CurrentHP {CurrentHP}");
    }
}
