using UnityEngine;
using System.Collections;

public class TimeItem : MonoBehaviour {

    public int EnergiaGanada = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter2D (Collider2D collider)
    {

        Destroy(gameObject);
    }
}


