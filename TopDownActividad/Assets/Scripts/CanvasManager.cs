using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject botonContinue;
    [SerializeField] private GameObject botonExit;
    public void BotonPlayAgain()
    {
        // Se carga la escena 0 al dar click en el Play again.
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void BotonExit()
    {
        // Se cierra el juego al dar click en el botón exit.
        Application.Quit();
        Debug.Log("Exit Game");
    }
}
