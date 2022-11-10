using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;

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
            Instantiate(bullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 0.5f), new Quaternion(gameObject.transform.rotation.x + 270, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w));
        }
    }
}
