using UnityEngine;
using System.Collections;

public class PlataformaMovil : MonoBehaviour {

    public Transform target;
    public float speed;
    //Me creo 2 variables de tipo Vector para guardar sus positiones.
    private Vector3 start, end;


	void Start () {

        if (target != null)
        {
            target.parent = null; //para que sea independiente de la plataforma movil 
        }
        //En este caso trnsform.position guarda las coordenadas de mi plataaforma inicial y a su vez la otra la posción del objeto destino (que irá variando).


        start = transform.position;

        end = target.position; 


	}
	


    void FixedUpdate()
    {
        if (target !=null)
        {
            float FixedSpeed = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, target.position, FixedSpeed);
        }
        if (transform.position == target.position) //si la plataforma origen se encuentra en la posición destino
        {
            target.position = (transform.position == start) ? end: start;  //operador ternario, que hace la función de un condicional 
        }
    }
}
