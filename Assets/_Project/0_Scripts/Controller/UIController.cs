using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private BattleController battleController ;

   public void RandomizeArmies()
    {
        battleController.CreateBattle(System.Environment.TickCount);
    }

    public void StartBattle()
    {
        battleController.StartBattle();
    }   
}
