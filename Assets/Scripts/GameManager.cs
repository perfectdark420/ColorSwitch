using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

namespace ColorSwitch
{
    public class GameManager : MonoBehaviour
    {

        public bool IsPaused { get; private set; }

        // ------------------------------------------------- //

        private GameObject player;

        // ------------------------------------------------- //

        public static GameManager Instance = null;

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
            // Disable the player
            GetPlayer().SetActive(false);

            // Show splash "Tap to play!"
            UIManager.Instance.ShowSplashScreen();
        }

        // ------------------------------------------------- //

        private void Update()
        {

            // Pause/Unpause
            if (Input.GetKeyDown(KeyCode.Escape))
                PauseGame(!IsPaused);

        }

        // ------------------------------------------------- //

        public GameObject GetPlayer()
        {
            if (player == null)
                player = GameObject.FindGameObjectWithTag("Player");
            return player;
        }

        // ------------------------------------------------- //

        public void StartGame()
        {
            // Hide all screens
            UIManager.Instance.HideAllScreens();

            // Enable the player
            GetPlayer().SetActive(true);
        }

        public void PauseGame(bool pause)
        {
            // Set flag
            IsPaused = pause;

            // Stop/resume time
            // Update() still gets called on all objects though!
            Time.timeScale = pause ? 0 : 1;

            // Show/hide pause screen
            if (pause)
                UIManager.Instance.ShowPauseScreen();
            else
                UIManager.Instance.HideAllScreens();

        }

        public void ResetGame()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }

        // ------------------------------------------------- //

        public void Win()
        {

            Debug.Log("You win!");

            // Stop everything
            Time.timeScale = 0;

            UIManager.Instance.ShowWinScreen();

        }

        public void GameOver()
        {

            Debug.Log("Game over!");

            UIManager.Instance.ShowDeathScreen();

        }

        // ------------------------------------------------- //

        public void StopGame()
        {
#if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}