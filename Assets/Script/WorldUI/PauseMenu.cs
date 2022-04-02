using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale != 0)
            {
                _pauseUI.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                _pauseUI.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
