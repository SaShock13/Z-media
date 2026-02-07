using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System;

public class BattleController : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private UnitDatabaseSO unitDatabase;

    [Header("Prefabs")]
    [SerializeField] private UnitView cubePrefab;
    [SerializeField] private UnitView spherePrefab;

    [Header("Spawn")]
    [SerializeField] private Transform armyASpawnRoot;
    [SerializeField] private Transform armyBSpawnRoot;
    [SerializeField] private int unitsPerArmy = 20;
    [SerializeField] private float spacing = 1.5f;

    private BattleModel _battle;
    private ArmyModel _armyA;
    private ArmyModel _armyB;

    private readonly Dictionary<int, UnitController> _unitControllers = new();

    private readonly List<UnitController> _teamA = new();
    private readonly List<UnitController> _teamB = new();

    private bool _battleRunning;

    public event Action<ArmyModel> ArmyDefeated;


    private void Update()
    {
        // Тестирование нанесения урона
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (var unit in _armyA.Units)
            {

                Debug.Log($"HEalth of {unit.Id} before {unit.Stats.CurrentHP}");
                unit.Stats.TakeDamage(20);
                Debug.Log($"HEalth after {unit.Stats.CurrentHP}");
            }
            // Второй проход по тем же юнитам — изменились ли они по-настоящему?
            Debug.Log("=== Second pass (real state in list) ===");
            foreach (var unit in _armyA.Units)
                Debug.Log($"Unit {unit.Id} CurrentHP = {unit.Stats.CurrentHP}");
        }

    }

    private void Start()
    {
        CreateBattle(seed: System.Environment.TickCount);
        //StartBattle();
    }

    public void StartBattle()
    {
        StartCoroutine(BattleLoop());
    }

    public void CreateBattle(int seed)
    {
        ClearBattle();
        var unitFactory = new UnitFactory(unitDatabase, seed);
        var armyFactory = new ArmyFactory(unitFactory);

        _armyA = armyFactory.Create(teamId: 0, count: unitsPerArmy);
        _armyB = armyFactory.Create(teamId: 1, count: unitsPerArmy);

        _battle = new BattleModel(_armyA, _armyB);
        _battle.BattleFinished += OnBattleFinished;

        SpawnArmy(_armyA, armyASpawnRoot, facingX: +1f);
        SpawnArmy(_armyB, armyBSpawnRoot, facingX: -1f);
    }

    private void OnArmyDefeated(ArmyModel model)
    {
        OnBattleFinished(model.TeamId);
    }

    private void SpawnArmy(ArmyModel army, Transform root, float facingX)
    {
        for (int i = 0; i < army.Units.Count; i++)
        {
            UnitModel model = army.Units[i];

            UnitView prefab = model.Shape.PrefabType == ShapePrefabType.Cube
                ? cubePrefab
                : spherePrefab;

            UnitView view = Instantiate(prefab, root);

            // --- 2D позиция: XY, Z = 0 ---
            int row = i / 5;
            int col = i % 5;

            Vector3 pos = root.position + new Vector3(col * spacing, -row * spacing, 0f);
            view.transform.position = pos;

            // --- ВАЖНО: в 2D не крутим forward ---
            view.transform.rotation = Quaternion.identity;

            // внешний вид
            view.SetColor(model.Color.ViewColor);
            view.SetScale(model.Size.ViewScale);

            // направление: флип по X
            view.SetFacing(facingX);

            // контроллер юнита
            var unitController = new UnitController(model, view);
            _unitControllers[model.Id] = unitController;

            if (army.TeamId == 0) _teamA.Add(unitController);
            else _teamB.Add(unitController);
        }
    }

    /// <summary>
    /// Очисить армии
    /// </summary>
    private void ClearBattle()
    {
        //удалить старые объекты со сцены
        ClearChildren(armyASpawnRoot);
        ClearChildren(armyBSpawnRoot);

        // 2) очистить контроллеры
        _unitControllers.Clear();
        _teamA.Clear();
        _teamB.Clear();

        // сбросить модели
        _armyA = null;
        _armyB = null;
        _battle = null;
    }
    private void ClearChildren(Transform root)
    {
        for (int i = root.childCount - 1; i >= 0; i--)
        {
            Destroy(root.GetChild(i).gameObject);
        }
    }

    private IEnumerator BattleLoop()
    {
        _battleRunning = true;

        while (_battleRunning)
        {
            //foreach (var kv in _unitControllers)
            //{
            //    kv.Value.Tick(Time.deltaTime, _armyA, _armyB);
            //}
            float dt = Time.deltaTime;

            for (int i = 0; i < _teamA.Count; i++)
                _teamA[i].Tick(dt, _teamA, _teamB);

            for (int i = 0; i < _teamB.Count; i++)
                _teamB[i].Tick(dt, _teamB, _teamA);
            // удаление умерших (чтобы не атаковали и не двигались)
            CleanupDeadUnits();

            yield return null;
        }
    }

    private void CleanupDeadUnits()
    {
        // удаляем view + controller, но model остаётся в армии (AliveCount считает по Stats.IsDead)
        var toRemove = new List<int>();

        foreach (var kv in _unitControllers)
        {
            if (kv.Value.Model.Stats.IsDead)
            {
                Destroy(kv.Value.View.gameObject);
                toRemove.Add(kv.Key);
            }
        }

        foreach (int id in toRemove)
            _unitControllers.Remove(id);

        // проверка победы
        _armyA.CheckDefeat();
        _armyB.CheckDefeat();
    }

    private void OnBattleFinished(int winnerTeamId)
    {
        _battleRunning = false;
        StartCoroutine(ReturnToMenu());
    }

    private IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("MainMenu");
    }
}
