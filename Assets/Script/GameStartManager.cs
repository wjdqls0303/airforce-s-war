using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartManager : MonoBehaviour
{
    public void OnclickStart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
