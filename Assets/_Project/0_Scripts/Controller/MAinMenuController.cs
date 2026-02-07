using UnityEngine;
using UnityEngine.SceneManagement;

public class MAinMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("BattleScene");
    }
}

