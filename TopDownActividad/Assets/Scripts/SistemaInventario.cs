using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaInventario : MonoBehaviour
{
    [SerializeField] private GameManagerSO gameManager;
    [SerializeField] private GameObject marcoInventario;
    [SerializeField] private Button[] botones;
    [SerializeField] private GameObject llave;
    [SerializeField] private GameObject moneda;
    [SerializeField] private GameObject botonAgain;
    [SerializeField] private GameObject botonExit;

    private List <string> nombres = new List<string>();
    private string valor;
    private Collider2D colliderDelante;
    private int itemsDisponibles = 0;
    private bool coincide = false;
    private int indiceBoton;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < botones.Length; i++)
        {
            indiceBoton = i;
            botones[i].onClick.AddListener(()=> BotonClickado(indiceBoton));
        }
    }

    private void BotonClickado(int indiceBoton)
    {
        Debug.Log("Botón clickado " + indiceBoton);
        colliderDelante = gameManager.Player.LanzarCheck();
        if (colliderDelante != null && colliderDelante.CompareTag("NPCmision"))
        {
            int item = 23 - indiceBoton;
            Debug.Log("item " + item);
            botones[item].gameObject.SetActive(false);
            llave.gameObject.SetActive(true);
        }
        else if (colliderDelante != null && colliderDelante.CompareTag("Cofre"))
        {
            int item = 24 - indiceBoton;
            Debug.Log("item " +item);
            botones[item].gameObject.SetActive(false);
            moneda.gameObject.SetActive(true);
            if (colliderDelante.TryGetComponent(out Interactuable interactuable))
            {
                interactuable.Interactuar();
                botonAgain.SetActive(true); 
                botonExit.SetActive(true);
            }
        }


    }

    public void ItemEntregado(int item)
    {
        
        botones[item].gameObject.SetActive(false);
    }

    public void NuevoItem(ItemSO datosItem)
    {
        //1.Activo un botón de mi inventario
        botones[itemsDisponibles].gameObject.SetActive(true);
        //2. accedo al componete image y cambio el sprite con el dato en el SO
        botones[itemsDisponibles].GetComponent<Image>().sprite = datosItem.icono;
        valor = datosItem.nombre;
        nombres.Add(valor);
        Debug.Log(nombres[itemsDisponibles]);
        itemsDisponibles++;
        
    }

    public bool BuscarItem(string name)
    {
        for (int i=0; i<itemsDisponibles; i++)
        {
            string nombre = nombres[i];
            if (name == nombre)
            {
                coincide = true;
                return coincide;
            }
        }
        return coincide;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            marcoInventario.SetActive(!marcoInventario.activeSelf);           
        }
    }
}
