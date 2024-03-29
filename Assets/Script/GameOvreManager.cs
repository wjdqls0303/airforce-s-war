using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOvreManager : MonoBehaviour
{
    [SerializeField]
    private Text textHighScore = null;
    void Start()
    {
        textHighScore.text = string.Format("HIGHSCORE\n{0}", PlayerPrefs.GetInt("HighScore", 0));
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void GiveUpButton()
    {
        Application.Quit();
    }
}
