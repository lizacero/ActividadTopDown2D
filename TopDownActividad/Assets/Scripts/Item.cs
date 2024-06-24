using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, Interactuable
{
    [SerializeField] private ItemSO misDatos;
    [SerializeField] private GameManagerSO gameManager;
    [SerializeField] private AudioClip colectar;
    public void Interactuar()
    {
        gameManager.Inventario.NuevoItem(misDatos);
        ControladorSonido.Instance.EjecutarSonido(colectar);
        Destroy(this.gameObject);
    }

}
