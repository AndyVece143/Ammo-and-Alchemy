using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionPart : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        // if Player is touching card
        if (other.tag == "Player")
        {
            player.GetComponent<PlayerMovement>().potionsMats++;
            Destroy(gameObject);
        }
    }
}
