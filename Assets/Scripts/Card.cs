using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Card : MonoBehaviour
{
    public GameObject Player;

    public bool pickedUp = false;

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

        // if Player has picked up card and clicks it
        if (pickedUp && Input.GetMouseButtonDown(1))
        {
            // card activates here
            if (cardType == "")
            {
                
            }
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
}
