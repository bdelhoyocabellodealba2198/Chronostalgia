﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller3 : MonoBehaviour {

    public void CambiarEscena(string nombre)
    {

        print("Cambiando la escena" + nombre);
        SceneManager.LoadScene(nombre);

    }
}