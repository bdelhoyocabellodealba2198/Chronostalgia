using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Time_leap: MonoBehaviour {
    public static GameObject objetos_presente;
    public static GameObject objetos_pasado;
    public GameObject player;
    public AudioSource[] time_leap_sound = null;

    public bool en_presente;
    public bool visible;
    public bool colisionando;

    // Use this for initialization
    void Start () {
        en_presente = true;
        colisionando = false;
        visible = false;
        

        objetos_presente = GameObject.Find("present");
        objetos_pasado = GameObject.Find("past");
        player = GameObject.Find("Nym");
           
    }
    
    //FUNCIÓN DE SALTO TEMPORAL
    void TimeLeap()
    {
        if (en_presente)
        {
            
            en_presente = false;
            time_leap_sound[1].Play();
        }
        else
        {
            en_presente = true;
            time_leap_sound[0].Play();
            
        }
    }





    // Update is called once per frame
    void Update () {

       
        
        SpriteRenderer[] array_sprite_pasado = objetos_pasado.GetComponentsInChildren<SpriteRenderer>();
        SpriteRenderer[] array_sprite_presente = objetos_presente.GetComponentsInChildren<SpriteRenderer>();
        BoxCollider2D[] array_collider_pasado = objetos_pasado.GetComponentsInChildren<BoxCollider2D>();
        BoxCollider2D[] array_collider_presente = objetos_presente.GetComponentsInChildren<BoxCollider2D>();

        int array_past_length = array_sprite_pasado.Length;
        int array_present_length = array_sprite_presente.Length;
        
       


        
        //BLOQUEO DE SALTO TEMPORAL EN CASO DE CLIPPING CON OBJETOS
        if (en_presente)
        {
            for (int i = 0; i < array_past_length; i++)
            {
                if (player.GetComponent<SpriteRenderer>().bounds.Intersects(array_sprite_pasado[i].GetComponent<SpriteRenderer>().bounds))
                {
                    colisionando = true;
                    player.GetComponent<SpriteRenderer>().color = Color.black;              
                    break;
                }
                else
                {
                    colisionando = false;
                    player.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }
        else
        {
            for (int j = 0; j < array_present_length; j++)
            {
                if (player.GetComponent<SpriteRenderer>().bounds.Intersects(array_sprite_presente[j].GetComponent<SpriteRenderer>().bounds))
                {
                    colisionando = true;
                    player.GetComponent<SpriteRenderer>().color = Color.red;
                    break;
                }
                else
                {
                    colisionando = false;
                    player.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }

        

        //SALTO TEPMORAL
        if (Input.GetKeyDown(KeyCode.Mouse0) && colisionando == false)
        {

            TimeLeap(); //función de salto
           
        }


        //PREVIEW DE SALTO TEMPORAL
        if (Input.GetKey(KeyCode.Mouse1))
        {
            visible = true;
        }
        else
        {
            visible = false;
        }

        
        //CAMBIO ENTRE PRESENTE Y PASADO Y VICEVERSA
        if (!en_presente)
        {

            //hacer visible uno e invisible otro
            foreach (SpriteRenderer child in array_sprite_presente)
            {
                child.color = new Color(255, 255, 255, 0);
            }

            foreach (SpriteRenderer child in array_sprite_pasado)
            {
                child.color = new Color(255, 255, 255, 255); ;
            }

            //hacer tangible uno e intangible otro
            foreach (BoxCollider2D child in array_collider_presente)
            {
                child.GetComponent<BoxCollider2D>().enabled = false;
            }

            foreach (BoxCollider2D child in array_collider_pasado)
            {
                child.GetComponent<BoxCollider2D>().enabled = true;
            }

        }
        else
        {
            //hacer visible uno e invisible otro   
            foreach (SpriteRenderer child in array_sprite_pasado)
            {
                child.color = new Color(255, 255, 255, 0);
            }
            foreach (SpriteRenderer child in array_sprite_presente)
            {
                child.color = new Color32(255, 255, 255, 255);
            }

            //hacer tangible uno e intangible otro
            foreach (BoxCollider2D child in array_collider_pasado)
            {
                child.GetComponent<BoxCollider2D>().enabled = false;
            }

            foreach (BoxCollider2D child in array_collider_presente)
            {
                child.GetComponent<BoxCollider2D>().enabled = true;
            }
        }


        //hace transparentes los objetos del tiempo en el que no está
        if (!en_presente && visible)
        {
            foreach (SpriteRenderer child in array_sprite_presente)
            {
                child.color = new Color32(255, 255, 255, 100);
            }
        }
        else if (en_presente && visible)
        {
            foreach (SpriteRenderer child in array_sprite_pasado)
            {
                child.color = new Color32(255, 255, 255, 100);
            }
        }
        
    }

    

    

    //*******IDEAS DESECHADAS*******

    //pasado.SetActive(true);
    //presente.SetActive(false);

    //GameObject.FindGameObjectsWithTag("ground")<SpriteRenderer>().enabled = false;

    //presente.GetComponentInChildren<SpriteRenderer>().enabled=false;
    //presente.GetComponentInChildren<BoxCollider2D>().enabled = false;

    // presente.GetComponent<SpriteRenderer>().enabled=false;
    // presente.GetComponent<BoxCollider2D>().enabled = false;

    //pasado.GetComponent<SpriteRenderer>().enabled = true;
    //pasado.GetComponentInChildren<SpriteRenderer>().color = new Color32(0, 0, 255, 255);
    // pasado.GetComponent<BoxCollider2D>().enabled = true;

    //pasado.GetComponentInChildren<BoxCollider2D>().enabled = true;
    //presente.GetComponentInChildren<BoxCollider2D>().enabled = false;

    //*******IDEAS DESECHADAS*******


    // sanic.GetComponentInChildren<SpriteRenderer>().color = new Color32(50, 50, 50, 255);


    //Hace invisible e intangible los objetos del tiempo en el que no está


}
