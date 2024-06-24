using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCmision : MonoBehaviour,Interactuable
{
    [SerializeField] private GameManagerSO gameManager;
    [SerializeField, TextArea(1, 5)] private string[] frases;
    [SerializeField] private float tiempoEntreLetras;
    [SerializeField] private GameObject cuadroDialogo;
    [SerializeField] private TextMeshProUGUI textoDialogo;

    //private SistemaInventario sistemaInventario;
    private bool hablando = false;
    private int indiceActual = -1;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Interactuar()
    {

        if (gameManager.Inventario.BuscarItem("Pico"))
        {
            gameManager.CambiarEstadoPlayer(false);
            cuadroDialogo.SetActive(true);
            if (!hablando)
            {
                SiguienteFrase();
            }
            else
            {
                CompletarFrase();
            }
        }
        else
        {
            gameManager.CambiarEstadoPlayer(false);
            cuadroDialogo.SetActive(true);
            if (!hablando)
            {
                SiguienteFrase();
            }
            else
            {
                CompletarFrase();
            }
        }
    }

    private void SiguienteFrase()
    {
        Debug.Log(indiceActual);
        if (gameManager.Inventario.BuscarItem("Pico")==true)
        {

            if (indiceActual >= 4)
            {
                TerminarDialogo();
            }
            else
            {
                indiceActual = 3;
                indiceActual++;
                StartCoroutine(EscribirFrase());
            }

        }
        else
        {
            indiceActual++;
            if (indiceActual >= 4)
            {
                TerminarDialogo();
            }
            else
            {
                StartCoroutine(EscribirFrase());
            }
        }
    }

    public void TerminarDialogo()
    {
        hablando = false;
        textoDialogo.text = "";
        indiceActual = -1;
        cuadroDialogo.SetActive(false);
        gameManager.CambiarEstadoPlayer(true);
    }

    private IEnumerator EscribirFrase()
    {
        hablando = true;
        textoDialogo.text = "";
        //Subdividir la frase actual en caracteres
        char[] caracteresFrase = frases[indiceActual].ToCharArray();
        foreach (char caracter in caracteresFrase)
        {
            textoDialogo.text += caracter;
            yield return new WaitForSeconds(tiempoEntreLetras);
        }
        hablando = false;
    }

    private void CompletarFrase()
    {
        StopAllCoroutines();
        textoDialogo.text = frases[indiceActual];
        hablando = false;
    }

}
