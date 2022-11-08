using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
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
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 3.0f * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        // key d (move right)
        if (playerInput.x > 0)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 3.0f * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        // key w (move up)
        if (playerInput.y > 0)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3.0f * Time.deltaTime, gameObject.transform.position.z);
        }

        // key s (move down)
        if (playerInput.y < 0)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1000.0f, 0.0f, 0.0f) * Time.deltaTime);
        }
    }

    // updates the input vector
    public void OnAction(InputValue value)
    {
        playerInput = value.Get<Vector2>();
    }
}
