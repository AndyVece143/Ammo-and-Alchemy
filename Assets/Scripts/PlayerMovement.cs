using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // stores WASD input
    public Vector2 playerInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // key a (move left)
        if (playerInput.x < 0)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-3000.0f, 0.0f, 0.0f) * Time.deltaTime);
        }

        // key d (move right)
        if (playerInput.x > 0)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(3000.0f, 0.0f, 0.0f) * Time.deltaTime);
        }

        // key w (move up)
        if (playerInput.y > 0)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, 3000.0f) * Time.deltaTime);
        }

        // key s (move down)
        if (playerInput.y < 0)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, -3000.0f) * Time.deltaTime);
        }
        Vector3 mousePos = new Vector3(Input.mousePosition.x - 300.0f, 0, Input.mousePosition.y - 194.7f);
        Debug.Log(Input.mousePosition.y - 194.7);
        Debug.Log(mousePos - gameObject.transform.position );
        transform.rotation = Quaternion.LookRotation(mousePos, Vector3.up);
    }

    // updates the input vector
    public void OnMovement(InputValue value)
    {
        playerInput = value.Get<Vector2>();
    }
}
