using System;
using UnityEngine;

namespace TankGame
{
    public class Pauser : MonoBehaviour
    {
        [SerializeField] private GameObject pausePanel;

        public Action OnPause;
        public Action OnResume;
        private void Start()
        {
            DisableTimeScale();
        }
        private bool isPaused = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }

        public void PauseGame()
        {
            OnPause?.Invoke();
            DisableTimeScale();
            isPaused = true;
            pausePanel.SetActive(true);
        }

        public void ResumeGame()
        {
            OnResume?.Invoke();
            EnableTimeScale();
            isPaused = false;
            pausePanel.SetActive(false);
        }
        public void DisableTimeScale()
        {
            Time.timeScale = 0f;
        }
        public void EnableTimeScale()
        {
            Time.timeScale = 1f;
        }
    }
}
