using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public float Timer = 60f;
    public Text TimerText;
    public Shop shop;
    public Energy energy;

    public string targetSceneName = "Scene3"; // <- the scene you want

    private bool startTimer = false;

    void Start()
    {
        Time.timeScale = 1;

        // Check if current scene matches
        if (SceneManager.GetActiveScene().name == targetSceneName)
        {
            startTimer = true;
        }
    }

    void Update()
    {
        if (!startTimer) return;

        Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            Timer = 0;
            SceneManager.LoadScene("Menu");
        }

        TimerText.text = Mathf.Ceil(Timer).ToString();
    }
}
