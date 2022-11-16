using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject Player;

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
    }
}
