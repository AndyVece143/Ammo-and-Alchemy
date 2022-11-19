using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float timer = 0.0f;

    public float width = 0.2f;

    public GameObject collisionChecker;

    private void Awake()
    {
        collisionChecker = GameObject.FindWithTag("Manager");
    }

    // Start is called before the first frame update
    void Start()
    {
        collisionChecker.GetComponent<BulletCollision>().bulletList.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // move bullet each frame
        gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 2000 * Time.deltaTime);

        // increment hiw long bullet has been out
        timer += Time.deltaTime;

        // if more than two seconds, destroy it
        if (2.0f < timer)
        {
            Destroyed();
        }
    }

    public void Destroyed()
    {
        Destroy(gameObject);
        collisionChecker.GetComponent<BulletCollision>().bulletList.Remove(gameObject);
    }
}
