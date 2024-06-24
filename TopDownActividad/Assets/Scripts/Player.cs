using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    private float inputH;
    private float inputV;
    private bool moviendo;
    private Vector3 puntoDestino;
    private Vector3 puntoInteraccion;
    private Vector3 ultimoInput;
    [SerializeField] private Vector3 nuevaPosicion;
    private Collider2D colliderDelante;
    private Animator anim;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float radioInteraccion;
    [SerializeField] private GameObject botonAgain;
    [SerializeField] private GameObject botonExit;

    private bool interactuando;

    public bool Interactuando { get => interactuando; set => interactuando = value; }
    public Vector3 PuntoDestino { get => puntoDestino; set => puntoDestino = value; }
    public Vector3 NuevaPosicion { get => nuevaPosicion; set => nuevaPosicion = value; }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        transform.position = nuevaPosicion;
    }

    // Update is called once per frame
    void Update()
    {
        LecturaInputs();
        MovimientoYAnimaciones();
    }

    private void MovimientoYAnimaciones()
    {
        //Ejecuto el movimiento solo si estoy en una casilla y solo si hay input
        if (!interactuando && !moviendo && (inputH != 0 || inputV != 0))
        {
            anim.SetBool("andando", true);
            anim.SetFloat("inputH", inputH);
            anim.SetFloat("inputV", inputV);
            //Actualizo cual fue mi ultimo input, cual va a ser mi puntoDestino y cual es mi puntoInteraccion
            ultimoInput = new Vector3(inputH, inputV, 0);
            puntoDestino = transform.position + ultimoInput;
            puntoInteraccion = puntoDestino;
            colliderDelante = LanzarCheck();
            if (colliderDelante == false)
            {
                StartCoroutine(Mover());
            }
        }
        else if (inputH == 0 && inputV == 0)
        {
            anim.SetBool("andando", false);
        }
    }

    private void LecturaInputs()
    {
        if (inputV == 0)
        {
            inputH = Input.GetAxisRaw("Horizontal");
        }
        if (inputH == 0)
        {
            inputV = Input.GetAxisRaw("Vertical");
        }
        if (Input.GetKeyDown(KeyCode.E)) ////////////
        {
            LanzarInteraccion();
        }
    }

    private void LanzarInteraccion()
    {
        colliderDelante = LanzarCheck();
        if (colliderDelante != null) //si existe
        {
            if (!colliderDelante.CompareTag("Cofre"))
            {
                if (colliderDelante.TryGetComponent(out Interactuable interactuable))
                {
                    interactuable.Interactuar();
                }
            }
                           
        }
    }

    IEnumerator Mover()
    {
        moviendo = true;
        while(transform.position != puntoDestino)
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoDestino, velocidadMovimiento * Time.deltaTime);
            yield return null;
        }
        //Ante un nuevo destino, necesito refrescar de nuevo puntoInteraccion
        puntoInteraccion = transform.position + ultimoInput;
        moviendo = false;
    }

    public Collider2D LanzarCheck()
    {
        return Physics2D.OverlapCircle(puntoInteraccion, radioInteraccion);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(puntoInteraccion, radioInteraccion);
    }
}
