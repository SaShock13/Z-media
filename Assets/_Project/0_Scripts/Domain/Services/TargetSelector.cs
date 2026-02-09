using System.Collections.Generic;
using UnityEngine;

public static class TargetSelector
{
    /// <summary>
    /// Выбираем ближайшего живого врага по позиции.
    /// </summary>
    public static UnitController GetNearestAlive(
        UnitController seeker,
        List<UnitController> enemies)
    {
        UnitController best = null;
        float bestSqrDist = float.MaxValue;
        Vector3 seekerPos = seeker.View.transform.position;

        for (int i = 0; i < enemies.Count; i++)
        {
            var e = enemies[i];
            if (e == null) continue;
            if (e.Model.Stats.IsDead) continue;
            Vector3 d = e.View.transform.position - seekerPos;
            float sqr = d.sqrMagnitude;
            if (sqr < bestSqrDist)
            {
                bestSqrDist = sqr;
                best = e;
            }
        }
        return best;
    }
}

