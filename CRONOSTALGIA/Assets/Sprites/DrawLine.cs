using UnityEngine;
using System.Collections.Generic;
using System.Collections; 

public class DrawLine : MonoBehaviour {

    public Transform from;
    public Transform to;

    void OnDrawGizmosSelected()
    {
        if (from !=null && to!= null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(from.position, to.position);
            Gizmos.DrawSphere(from.position, 0.01f);
            Gizmos.DrawSphere(to.position, 0.01f);

        }

    }


}
