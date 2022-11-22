using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // stores WASD input
    public Vector2 playerInput;

    public string spellActive;
    public float coolDown;

    // for looping through spells/cooldowns
    private int index = 0;

    public float health;

    public float width = 1;

    // Start is called before the first frame update
    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        // key a (move left)
        if (playerInput.x < 0)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-1000.0f, 0.0f, 0.0f) * Time.deltaTime);
        }

        // key d (move right)
        if (playerInput.x > 0)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1000.0f, 0.0f, 0.0f) * Time.deltaTime);
        }

        // key w (move up)
        if (playerInput.y > 0)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, 1000.0f) * Time.deltaTime);
        }

        // key s (move down)
        if (playerInput.y < 0)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, -1000.0f) * Time.deltaTime);
        }

        // rotate according to mouse position
        Vector3 mousePos = new Vector3(Input.mousePosition.x - 300.0f, 0, Input.mousePosition.y - 194.7f);
        //Debug.Log(Input.mousePosition.y - 194.7);
        //Debug.Log(mousePos - gameObject.transform.position );
        transform.rotation = Quaternion.LookRotation(mousePos, Vector3.up);

        // subtract spell cooldown
        coolDown -= Time.deltaTime;

        // end spell if cooldown done
        if (coolDown < 0.0f)
        {
            spellActive = "";
        }

        //Health check
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // updates the input vector
    public void OnMovement(InputValue value)
    {
        playerInput = value.Get<Vector2>();
    }

    public void TakeDamage()
    {
        health -= 1;
    }
}
