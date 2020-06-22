using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    [SerializeField]
    private GameObject pausePanel;

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    public void restartGame()
    {
        pausePanel.SetActive(false);
    }

    public void openMenuScene()
    {
        SceneManager.LoadScene("MenuLevel");
    }

    public void exit()
    {
        Application.Quit();
    }
}
