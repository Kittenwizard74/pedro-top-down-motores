using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public GameObject[] spawners; // Array que contiene a todos los spawners en el nivel
    private int totalEnemies; // N�mero total de enemigos en el nivel
    private int defeatedEnemiesA = 0; // N�mero de enemigos derrotados
    private int defeatedEnemiesB = 0;
    private int defeatedEnemiesC = 0;
    void Start()
    {
        // Calcular el n�mero total de enemigos en el nivel
        foreach (GameObject spawner in spawners)
        {
            totalEnemies += spawner.GetComponent<spawnerEnemigos>().maxEnemies;
        }
    }

    void Update()
    {
        // Verificar si todos los enemigos han sido derrotados
        if (defeatedEnemiesA >= 5 && defeatedEnemiesB >= 5 && defeatedEnemiesC >= 5)
        {
            LoadNextLevel();
        }
    }

    public void EnemyDefeated(string ID)
    {
        if(ID == "A")
        {
            defeatedEnemiesA++;
        }
        if (ID == "B")
        {
            defeatedEnemiesB++;
        }
        if (ID == "C")
        {
            defeatedEnemiesC++;
        }
    }

    void LoadNextLevel()
    {
        // Obtener el �ndice del siguiente nivel
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Verificar si hay un siguiente nivel y cargarlo
        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
        else
        {
            Debug.Log("�Felicidades, has completado todos los niveles!");
            // Aqu� podr�as hacer algo como mostrar un mensaje de victoria o volver al men� principal
        }
    }

}
