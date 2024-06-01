using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botones : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("juego");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
