using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move bullet each frame
        gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 2000 * Time.deltaTime);
    }
}
