using UnityEngine;
using System.Collections;

public class TimeItem : MonoBehaviour
{
    public GameObject DoorOpen;
    public GameObject DoorLocked;
    public GameObject player;
    public int ClockCounter = 0;
    public bool touched;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Nym");
        DoorOpen = GameObject.Find("DoorOpen");
        DoorLocked = GameObject.Find("DoorLocked");

        DoorOpen.GetComponent<BoxCollider2D>().enabled = false;
        DoorLocked.GetComponent<BoxCollider2D>().enabled = false;
        DoorOpen.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);

    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        touched = true;
 
 
        Destroy(gameObject);
    }

    
}


