using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UnitController управляет:
/// - движением к цели
/// - таймером атаки
/// - нанесением урона
///
/// Здесь допустима Unity-логика (позиции, дистанции).
/// </summary>
public class UnitController
{
    public UnitModel Model { get; }
    public UnitView View { get; }

    private float _attackCooldown;

    // дистанция атаки
    private const float MeleeRange = 0.75f;

    public UnitController(UnitModel model, UnitView view)
    {
        Model = model;
        View = view;
        _attackCooldown = Random.Range(0f, 0.25f); // чтобы не били идеально синхронно
    }

    public void Tick(float dt, List<UnitController> allies,
        List<UnitController> enemies)
    {
        if (Model.Stats.IsDead)
            return;

        UnitController target = TargetSelector.GetNearestAlive(this, enemies);
        if (target == null)
            return;

        Vector3 myPos = View.transform.position;
        Vector3 targetPos = target.View.transform.position;

        Vector3 toTarget = targetPos - myPos;
        float sqrDist = toTarget.sqrMagnitude;

        float meleeSqr = MeleeRange * MeleeRange;

        // 1) Если далеко — двигаемся
        if (sqrDist > meleeSqr)
        {
            MoveTowards(dt, targetPos);
            FaceTo(targetPos);
            return;
        }

        // 2) Если рядом — атакуем 
        FaceTo(targetPos);

        _attackCooldown -= dt;
        if (_attackCooldown <= 0f)
        {
            target.Model.Stats.TakeDamage(Model.Stats.ATK);
            _attackCooldown = Model.Stats.ATKSPD;
        }
    }

    private void MoveTowards(float dt, Vector3 targetPos)
    {
        Vector3 myPos = View.transform.position;

        Vector3 dir = targetPos - myPos;
        dir.z = 0f;

        float dist = dir.magnitude;
        if (dist < 0.001f)
            return;

        dir /= dist;

        float step = Model.Stats.SPEED * dt;

        // чтобы не перелетать цель
        if (step >= dist)
            View.transform.position = new Vector3(targetPos.x, targetPos.y, myPos.z);
        else
            View.transform.position = myPos + dir * step;
    }

    private void FaceTo(Vector3 targetPos)
    {
        float dx = targetPos.x - View.transform.position.x;

        if (Mathf.Abs(dx) < 0.0001f)
            return;

        Vector3 s = View.transform.localScale;
        s.x = Mathf.Abs(s.x) * (dx > 0f ? 1f : -1f);
        View.transform.localScale = s;
    }
}
