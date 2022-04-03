using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    public void LaunchGame()
    {
        SceneManager.LoadScene(2);
    }
    public void LaunchCredits()
    {
        SceneManager.LoadScene(1);
    }
    public void LaunchMenu()
    {
        SceneManager.LoadScene(0);
    }
}
