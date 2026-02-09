using UnityEngine;
using UnityEngine.UI;

public class FormationUI : MonoBehaviour
{
    [Header("Army A")]
    [SerializeField] private Button aLine;
    [SerializeField] private Button aBox;
    [SerializeField] private Button aWedge;
    [SerializeField] private Button aChaotic;

    [Header("Army B")]
    [SerializeField] private Button bLine;
    [SerializeField] private Button bBox;
    [SerializeField] private Button bWedge;
    [SerializeField] private Button bChaotic;

    private ArmyModel _armyA;
    private ArmyModel _armyB;

    public void Bind(ArmyModel armyA, ArmyModel armyB)
    {
        _armyA = armyA;
        _armyB = armyB;
        // Army A
        aLine.onClick.AddListener(() => _armyA.SetFormation(FormationType.Line));
        aBox.onClick.AddListener(() => _armyA.SetFormation(FormationType.Box));
        aWedge.onClick.AddListener(() => _armyA.SetFormation(FormationType.Wedge));
        aChaotic.onClick.AddListener(() => _armyA.SetFormation(FormationType.Chaotic));
        // Army B
        bLine.onClick.AddListener(() => _armyB.SetFormation(FormationType.Line));
        bBox.onClick.AddListener(() => _armyB.SetFormation(FormationType.Box));
        bWedge.onClick.AddListener(() => _armyB.SetFormation(FormationType.Wedge));
        bChaotic.onClick.AddListener(() => _armyB.SetFormation(FormationType.Chaotic));
    }

    private void OnDestroy()
    {
        aLine.onClick.RemoveAllListeners();
        aBox.onClick.RemoveAllListeners();
        aWedge.onClick.RemoveAllListeners();
        aChaotic.onClick.RemoveAllListeners();
        bLine.onClick.RemoveAllListeners();
        bBox.onClick.RemoveAllListeners();
        bWedge.onClick.RemoveAllListeners();
        bChaotic.onClick.RemoveAllListeners();
    }
}
