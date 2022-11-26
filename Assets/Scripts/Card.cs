using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class Card : MonoBehaviour
{
    public GameObject Player;

    public bool pickedUp = false;

    public bool clicked = false;

    // what card type this is
    public string cardType;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        /*
        if (cardType == "")
        {
            gameObject
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        // if Player has picked up card
        if (pickedUp)
        {
            // follow player
            this.transform.position = new Vector3(Player.transform.position.x, 10, Player.transform.position.z - 2);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // if Player is touching card
        if (other.tag == "Player")
        {
            pickedUp = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // if leaving range of an interactable
        if (other.tag == "interactable")
        {

        }
    }

    void OnMouseDown()
    {
        if (pickedUp)
        {
            clicked = true;
        }
    }
}
