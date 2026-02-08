using System.Collections.Generic;
using UnityEngine;

public class ArmyController : MonoBehaviour
{
    private readonly ArmyModel _army;
    private readonly List<UnitController> _units;
    private readonly Transform _root;
    private readonly float _spacing;
    private readonly float _facingX;

    public ArmyController(
        ArmyModel army,
        List<UnitController> unitControllers,
        Transform root,
        float spacing,
        float facingX)
    {
        _army = army;
        _units = unitControllers;
        _root = root;
        _spacing = spacing;
        _facingX = facingX;

        _army.FormationChanged += OnFormationChanged;
    }

    public void Dispose()
    {
        _army.FormationChanged -= OnFormationChanged;
    }

    private void OnFormationChanged(FormationType newFormation)
    {
        ApplyFormation(newFormation);
    }

    public void ApplyFormation(FormationType formationType)
    {
        IFormation formation = FormationFactory.Create(formationType);

        for (int i = 0; i < _units.Count; i++)
        {
            UnitController unitController = _units[i];
            if (unitController.Model.Stats.IsDead)
                continue;

            Vector3 localPos = formation.GetLocalPosition(i, _units.Count, _spacing, _facingX);
            unitController.View.transform.position = _root.position + localPos;
        }
    }
}
