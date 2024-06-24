using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool puerta2 = false;
    private bool puerta3 = false;
    private Vector3 pos0 = new Vector3(0.5f, 1.5f,0);
    private Vector3 pos1 = new Vector3(5.5f, -2.5f, 0);
    private Vector3 pos2 = new Vector3(-1.5f, 3.5f, 0);

    public static GameController instance;

    public bool Puerta2 { get => puerta2; set => puerta2 = value; }
    public bool Puerta3 { get => puerta3; set => puerta3 = value; }
    public Vector3 Pos0 { get => pos0; set => pos0 = value; }
    public Vector3 Pos1 { get => pos1; set => pos1 = value; }
    public Vector3 Pos2 { get => pos2; set => pos2 = value; }

    private void Awake()
    {
        if (GameController.instance == null)
        {
            GameController.instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GuardarPuerta(int puerta, Vector3 posicion)
    {
        if (puerta==1)
        {
            puerta2 = true;
            pos0 = posicion;
        }
        if (puerta==2)
        {
            puerta3 = true;
            pos0 = posicion;
        }
        if (puerta == 3)
        {
            pos0 = posicion;
        }
        Debug.Log("pos0 " + pos0);

    }

}
