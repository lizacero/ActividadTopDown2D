using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour,Interactuable
{
    private Animator anim;
    private bool estado;
    [SerializeField] private AudioClip colectar;

    public bool Estado { get => estado; set => estado = value; }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Llave", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interactuar()
    {
        ControladorSonido.Instance.EjecutarSonido(colectar);
        anim.SetBool("Llave", true);
    }
}
