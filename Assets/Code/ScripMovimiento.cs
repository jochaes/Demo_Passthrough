using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScripMovimiento : MonoBehaviour

{

    [SerializeField]
    private float tiempo = 2f;              //Duracion de la animacion

    [SerializeField]
    private float y_Objetivo = 0.5f;        //Lo que se va a elevar el modelo 

    private bool esVisible = false;         //Nos permite si el modelo esta visible o no 

    void Start()
    {
        //Al iniciar el script, se esconde el modelo, osea baja en y a 0
        esVisible = false;
        transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.localPosition.z);
    }

    void Update()
    {
        
    }

    //Funcion para mover el modelo de su posicion actual a un punto objetivo en y, en un tiempo determinado
    private IEnumerator Mover(float duracion, float y_Objetivo)
   {
        var posicionInicial = transform.localPosition;                                      // Guarda la posición inicial
        var posicionFinal = new Vector3(posicionInicial.x, y_Objetivo, posicionInicial.z);  // Calcula la posicion final
        var tiempoTranscurrido = 0f;                                                        // Inicializa un timer

        //Mientras que se se transcurre el tiempo 
        while (tiempoTranscurrido < duracion)
        {
            var t = tiempoTranscurrido / duracion;  // Calcula la interpolacion actual 
            transform.localPosition = Vector3.Lerp(posicionInicial, posicionFinal, t); //Mueve el modelo
            tiempoTranscurrido += Time.deltaTime;   // Calcula el tiempo transcurrido
            yield return null;                      // Espera el siguiente frame
        }

        transform.localPosition = posicionFinal;
    }

    //Funcion para alternar la visivilidad del modelo
    public void AlternarVisibilidad()
    {
        //Depenidendo de la visibilidad sube o baja el modelo. 
        if (!esVisible)
        {
            StartCoroutine(Mover(tiempo, y_Objetivo));
            esVisible = true;
        }
        else
        {
            StartCoroutine(Mover(tiempo, 0));
            esVisible = false;
        }
    }


}
