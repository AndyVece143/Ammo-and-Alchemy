using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class Card : MonoBehaviour
{
    public GameObject Player;
    public GameObject Gun;

    // has the player picked up card dropped by enemy
    public bool pickedUp = false;

    // has the player clicked on it 
    public bool clicked = false;

    // what type of spell this is
    public string cardType;

    //Audio
    [SerializeField]
    AudioClip spellSound;

    // Start is called before the first frame update
    void Start()
    {
        // find reference to the player
        Player = GameObject.FindGameObjectWithTag("Player");

        // find reference to the gun
        Gun = GameObject.FindGameObjectWithTag("Gun");
    }

    // Update is called once per frame
    void Update()
    {
        // if Player has picked up card
        if (pickedUp)
        {
            // follow player
            this.transform.position = new Vector3(Player.transform.position.x, 10 + (Player.GetComponent<PlayerMovement>().cards.IndexOf(gameObject) * 0.1f), Player.transform.position.z - 2);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // if Player is touching card
        if (other.tag == "Player")
        {            
            // add to list of player's cards
            Player.GetComponent<PlayerMovement>().cards.Add(gameObject);

            // it has been picked ups
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
            AudioSource.PlayClipAtPoint(spellSound, Player.transform.position);

            // activate spell and cooldown
            clicked = true;
            Player.GetComponent<PlayerMovement>().spellActive = cardType;
            Player.GetComponent<PlayerMovement>().coolDown = 5.0f;

            // remove from list and destroy
            Player.GetComponent<PlayerMovement>().cards.Remove(gameObject);
            Destroy(gameObject);

            // start off fireball timer
            if (cardType == "fireball")
            {
                Gun.GetComponent<Gun>().fireballTimer = 0.01f;
            }
        }
    }
}
