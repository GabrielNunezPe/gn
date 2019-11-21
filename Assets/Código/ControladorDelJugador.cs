using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorDelJugador : MonoBehaviour
{
    //Almacena componente Rigibody del personaje Jugador.
    Rigidbody rb;
    public float velocidad;
    int contador;
    int numItem_1;
    int numItem_2;

   public Text marcador;
   public Text finjuego;



    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        marcador.text = "tienes: " + contador + "puntos";
        //AG- Desactiva el elemento texto de fin de juego
        finjuego.gameObject.SetActive(false);
    }

    public void FixedUpdate()
    {

        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical);
        rb.AddForce(movimiento*velocidad);
       
    }

    public void OnTriggerEnter(Collider other) //Collider es el objeto con el que ha colisionado

    {
       
        if(other.tag == "Suma1")
        {
            Destroy(other.gameObject);
            contador = +1;
            numItem_1 = numItem_1 + 1;

        }
        else if (other.tag == "Suma2")
        {
            Destroy(other.gameObject);
            contador = contador + 2;
            numItem_2 = numItem_2 + 1;
        }
        else if (other.tag == "Resta1")
        {
            contador = contador - 1;
        }

            ActualizaMarcador();

        if (contador >= 20) //acaba la partida porque recoge todos los items
        {
            finjuego.gameObject.SetActive(true);
            Time.timeScale = 0;

        }
        



    }
    void ActualizaMarcador()
    {
        marcador.text = "tienes: " + contador + "puntos";
    }

}


