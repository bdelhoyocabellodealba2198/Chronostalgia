using UnityEngine;
using System.Collections;



public class PlayerController : MonoBehaviour {

    public float AlturaSalto;

    public float VelocidadMovimiento;

    public bool grounded;
	

	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, AlturaSalto);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(VelocidadMovimiento, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-VelocidadMovimiento, GetComponent<Rigidbody2D>().velocity.y);

           
        }
    }



}
