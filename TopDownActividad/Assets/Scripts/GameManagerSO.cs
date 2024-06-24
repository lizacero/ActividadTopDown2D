using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName ="Scriptable Objects/GameManager")]
public class GameManagerSO : ScriptableObject
{
    private Player player;
    private SistemaInventario inventario;

    public SistemaInventario Inventario { get => inventario;}
    public Player Player { get => player; set => player = value; }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += NuevaEscenaCargada;
    }


    private void NuevaEscenaCargada(Scene arg0, LoadSceneMode arg1)
    {
        player = FindAnyObjectByType<Player>();
        inventario = FindAnyObjectByType<SistemaInventario>();
    }

    public void CambiarEstadoPlayer(bool estado)
    {
        player.Interactuando = !estado;
    }

}
