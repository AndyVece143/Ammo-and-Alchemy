using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
//using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // stores WASD input
    public Vector2 playerInput;

    // the name of the spell that is active
    public string spellActive;

    // how long current spell will be active for
    public float coolDown;

    public float health;

    // how many potion parts have been picked up
    public int potionsMats = 0;

    // has the player won
    public bool won = false;

    public float width = 1;

    // all cards the player has
    public List<GameObject> cards = new List<GameObject>();

    // player damage
    public float d;

    // player speed
    public float s;

    //I-Frame bool
    public bool invincible = false;

    // Start is called before the first frame update
    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        // defaults what spell is active if spell timre runs out
        if(coolDown < 0.01)
        {
            spellActive = "";
            d = 1.0f;
            s = 1000;
        }
        else if(spellActive == "speed")
        {
            s = 2000.0f;
        }
        else if (spellActive == "damage")
        {
            d = 1.5f;
        }

        // key a (move left)
        if (playerInput.x < 0)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-1.0f * s, 0.0f, 0.0f) * Time.deltaTime);
        }

        // key d (move right)
        if (playerInput.x > 0)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(s, 0.0f, 0.0f) * Time.deltaTime);
        }

        // key w (move up)
        if (playerInput.y > 0)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, s) * Time.deltaTime);
        }

        // key s (move down)
        if (playerInput.y < 0)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, -1.0f * s) * Time.deltaTime);
        }

        // rotate according to mouse position
        Vector3 mousePos = new Vector3(Input.mousePosition.x - (Screen.width / 2), 0, Input.mousePosition.y - (Screen.height / 2));
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

        if (potionsMats == 3)
        {
            won = true;
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
        StartCoroutine(waiter());
    }

    
    void OnTriggerEnter(Collider other)
    {
        // If the player gets hit by a bullet
        if (other.tag == "EnemyBullet" && invincible == false)
        {
           TakeDamage();
        }

        if (other.tag == "Enemy" && invincible == false)
        {
            TakeDamage();
        }
    }
    
    IEnumerator waiter()
    {
        invincible = true;

        yield return new WaitForSeconds(2);

        invincible = false;
    }
}
