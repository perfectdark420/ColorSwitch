using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {

    public GameObject splashScreen;
    public GameObject pauseScreen;
    public GameObject deathScreen;
    public GameObject winScreen;

    public TextMeshProUGUI scoreText;

    // ------------------------------------------------- //

    public static UIManager Instance = null;

    // ------------------------------------------------- //

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    // ------------------------------------------------- //

    private void Start()
    {
        HideAllScreens();
    }

    // ------------------------------------------------- //

    public void UpdateScore(int value)
    {
        scoreText.text = "Stars: " + value;
    }

    // ------------------------------------------------- //

    public void HideAllScreens()
    {
        splashScreen.SetActive(false);
        pauseScreen.SetActive(false);
        deathScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    public void ShowSplashScreen()
    {
        HideAllScreens();
        splashScreen.SetActive(true);
    }

    public void ShowPauseScreen()
    {
        HideAllScreens();
        pauseScreen.SetActive(true);
    }

    public void ShowDeathScreen()
    {
        HideAllScreens();
        deathScreen.SetActive(true);
    }

    public void ShowWinScreen()
    {
        HideAllScreens();
        winScreen.SetActive(true);
    }

}
