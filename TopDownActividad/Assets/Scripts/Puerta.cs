using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour,Interactuable
{
    [SerializeField] private int indice;
    [SerializeField] private GameManagerSO gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager.Player.NuevaPosicion = GameController.instance.Pos0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("puerta "+gameManager.Player.PuntoDestino);
        Debug.Log("pos0 " + GameController.instance.Pos0);
        
    }

    public void Interactuar()
    {
        if (indice == 0)
        {
            SceneManager.LoadScene(indice);
            gameManager.Player.NuevaPosicion = GameController.instance.Pos0;
        }
        if (indice == 1)
        {
            GameController.instance.GuardarPuerta(indice, gameManager.Player.PuntoDestino);
            SceneManager.LoadScene(indice);
            gameManager.Player.NuevaPosicion = GameController.instance.Pos1;
        }
        if (GameController.instance.Puerta2 == true && indice == 2) 
        {
            GameController.instance.GuardarPuerta(indice, gameManager.Player.PuntoDestino);
            SceneManager.LoadScene(indice);
            gameManager.Player.NuevaPosicion = GameController.instance.Pos1;
        }
        if (GameController.instance.Puerta3 == true && indice == 3)
        {
            GameController.instance.GuardarPuerta(indice, gameManager.Player.PuntoDestino);
            SceneManager.LoadScene(indice);
            gameManager.Player.NuevaPosicion = GameController.instance.Pos2;
        }
    }
}
