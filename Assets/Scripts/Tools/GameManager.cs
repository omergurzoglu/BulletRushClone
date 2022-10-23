
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Canvas canvas;
    public TextMeshProUGUI scoreText;
    public int score=0;

    private void OnEnable()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(StartDelay());
    }

    public void GameOver()
    {
        StartCoroutine(WaitAndRestart());
    }

    public void UpdateScore()
    {
        score+=10;
        scoreText.text = score.ToString();
    }

    IEnumerator WaitAndRestart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1;
    }
}
