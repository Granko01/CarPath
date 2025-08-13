using System;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    public int EnergyAmount = 5;
    public int MaxEnergy = 5;
    public Text EnergyText;
    public Text CountdownText; // UI Text for the countdown

    private const string EnergyKey = "EnergyKey";
    private const string LastEnergyTimeKey = "LastEnergyTime";
    private const int MinutesPerEnergy = 10;

    private float timer; // seconds passed while game is running

    void Start()
    {
        // Load saved energy
        GetEnergy();

        float timeUntilNextEnergy = MinutesPerEnergy * 60f;

        // Restore based on time passed
        if (PlayerPrefs.HasKey(LastEnergyTimeKey))
        {
            DateTime lastTime = DateTime.Parse(PlayerPrefs.GetString(LastEnergyTimeKey));
            TimeSpan timePassed = DateTime.Now - lastTime;

            int energyToAdd = (int)(timePassed.TotalMinutes / MinutesPerEnergy);
            double leftoverSeconds = timePassed.TotalSeconds % (MinutesPerEnergy * 60);

            if (energyToAdd > 0)
            {
                EnergyAmount = Mathf.Min(EnergyAmount + energyToAdd, MaxEnergy);
            }

            // If not full, set timer to leftover seconds
            if (EnergyAmount < MaxEnergy)
            {
                timeUntilNextEnergy = (float)((MinutesPerEnergy * 60) - leftoverSeconds);
            }
            else
            {
                timeUntilNextEnergy = MinutesPerEnergy * 60f;
            }

            timer = (MinutesPerEnergy * 60f) - timeUntilNextEnergy;
        }
        else
        {
            PlayerPrefs.SetString(LastEnergyTimeKey, DateTime.Now.ToString());
            timeUntilNextEnergy = MinutesPerEnergy * 60f;
        }

        UpdateUI(timeUntilNextEnergy);
        SaveEnergy();
    }

    void Update()
    {
        if (EnergyAmount < MaxEnergy)
        {
            timer += Time.deltaTime;
            float timeRemaining = (MinutesPerEnergy * 60f) - timer;

            if (timer >= MinutesPerEnergy * 60f)
            {
                EnergyAmount++;
                timer = 0;
                PlayerPrefs.SetString(LastEnergyTimeKey, DateTime.Now.ToString());
                SaveEnergy();
            }

            UpdateUI(timeRemaining);
        }
        else
        {
            CountdownText.text = "Full";
        }
    }

    public void GetEnergy()
    {
        EnergyAmount = PlayerPrefs.GetInt(EnergyKey, EnergyAmount);
    }

    public void SaveEnergy()
    {
        PlayerPrefs.SetInt(EnergyKey, EnergyAmount);
        PlayerPrefs.Save();
    }

    public void UseEnergy()
    {
        if (EnergyAmount > 0)
        {
            EnergyAmount--;
            timer = 0;
            PlayerPrefs.SetString(LastEnergyTimeKey, DateTime.Now.ToString());
            SaveEnergy();
        }
    }

    private void UpdateUI(float timeRemaining)
    {
        EnergyText.text = EnergyAmount.ToString();
        CountdownText.text = FormatTime(timeRemaining);
    }

    private string FormatTime(float time)
    {
        time = Mathf.Max(0, time);
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
