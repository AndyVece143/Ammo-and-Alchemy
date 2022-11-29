using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject fireball;
    public GameObject Player;
    public float fireballTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // left click check
        if (Input.GetMouseButtonDown(0))
        {
            // on left click, spawn a bullet at position and rotation of gun
            Instantiate(bullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), new Quaternion(Player.transform.rotation.x, Player.transform.rotation.y, Player.transform.rotation.z, Player.transform.rotation.w));
        }

        // increment timer if active
        if (0.01f <= fireballTimer)
        {
            fireballTimer += Time.deltaTime;
        }

        // fireball
        if (2.0f < fireballTimer)
        {
            Instantiate(fireball, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), new Quaternion(Player.transform.rotation.x, Player.transform.rotation.y, Player.transform.rotation.z, Player.transform.rotation.w));
            fireballTimer = 0.0f;
        }
    }
}
