using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    [Header("점수")]
    [SerializeField]
    private Text textScore = null;
    [Header("최대점수")]
    [SerializeField]
    private Text textHighscore = null;
    [Header("체력")]
    [SerializeField]
    private Text textLife = null;
    [Header("기본 적 리소스")]
    [SerializeField]
    private GameObject enemyairplainPrefab = null;
    [Header("빠른 적 리소스")]
    [SerializeField]
    private GameObject enemyfastairplainPrefab = null;

    public Vector2 MinPosition { get; private set; }
    public Vector2 MaxPosition { get; private set; }
    private int score = 0;
    private int highscore = 0;
    private int life = 3;

    void Start()
    {
        MinPosition = new Vector2(-2.3f, -5f);
        MaxPosition = new Vector2(2.3f, 5f);
        StartCoroutine(Spwanenemy());
        highscore = PlayerPrefs.GetInt("HighScore", 5);
    }

    
    private IEnumerator Spwanenemy()
    {
        float delay = 0f;
        float positionX = 0f;

        while(true)
        {
            delay = Random.Range(1f, 2f);
            positionX = Random.Range(-2.3f, 2.3f);
            Instantiate(enemyfastairplainPrefab, new Vector2(-positionX, 5f), Quaternion.identity);
            for (int i = 0; i < 5; i++)
            {
                Instantiate(enemyairplainPrefab, new Vector2(positionX, 5f), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(delay);
        }
    }
    public void AddScore(int addscore)
    {
        score += addscore;
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("HighScore", highscore);
        }
        UpdateUI();
    }
    public void Dead()
    {
        life--;
        if (life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        UpdateUI();
    }
    public void UpdateUI()
    {
        textScore.text = string.Format("Score {0}", score);
        textLife.text = string.Format("Life {0}", life);
        textHighscore.text = string.Format("HighScore {0}", highscore);
    }
}
