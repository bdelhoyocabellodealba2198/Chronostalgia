using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

  
 public class CheckGround : MonoBehaviour {

    private PlayerControls player;

    
	
	void Start () {

        player = GetComponentInParent<PlayerControls>();
	}
	
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag =="Ground")
        {
            player.grounded = true;
           
        }
        if (col.gameObject.tag == "grabble")
        {
            player.grounded = true;
        }
        if (col.gameObject.tag =="Platform")
        {
            player.transform.parent = col.transform;
            player.grounded = true;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MENÚ INICIO");
        }

        if (col.gameObject.tag == "dangerPlatform")
        {
            SceneManager.LoadScene("NYMDEAD");
            
        }

    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            player.grounded = false;
        }
        if (col.gameObject.tag == "grabble")
        {
            player.grounded = false;
        }
        if (col.gameObject.tag=="Platform")
        {
            player.transform.parent = null;
            player.grounded = false;
        }
    }

}
