
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource buttonSound;
    public void PlayGame ()
    {
        SceneManager.LoadScene("Game Explain");
    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void playsButton ()
    {
        buttonSound.Play();
    }

    public void ReStart ()
    {
        SceneManager.LoadScene("Starting Scene");
    }

    public void Continue()
    {
        SceneManager.LoadScene("Game");
    }

    public void Continue2()
    {
        SceneManager.LoadScene("Game 2");
    }

    public void Continue3()
    {
        SceneManager.LoadScene("Game 3");
    }
    public void Continue4()
    {
        SceneManager.LoadScene("Game 4");
    }

}
