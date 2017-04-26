﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabberscript : MonoBehaviour {

    public bool grabbed;
    RaycastHit2D hit;
    public float distance = 2f;
    public Transform holdpoint;
    public float throwforce;
    public LayerMask notgrabbed;

 

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {

            if (!grabbed)
            {
                Physics2D.queriesStartInColliders = false;

                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x,distance);

                if (hit.collider != null && hit.collider.tag == "grabble")
                {
                    grabbed = true;

                }


                //grab
            }
            else if (!Physics2D.OverlapPoint(holdpoint.position, notgrabbed))
            {
                grabbed = false;

                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {

                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwforce;
                }


               
            }


        }
        /*ARREGLAR ESTO
        if (grabbed)
        {
            hit.collider.gameObject.transform.position = holdpoint.position;
        }
        */
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }
}

