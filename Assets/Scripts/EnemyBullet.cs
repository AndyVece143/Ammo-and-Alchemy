using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
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
        collisionChecker.GetComponent<BulletCollision>().enemyBulletList.Add(gameObject);
        
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

    void Destroyed()
    {
        Destroy(gameObject);
        //collisionChecker.GetComponent<BulletCollision>().enemyBulletList.Remove(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        //If bullet collides with the player or a wall
        if (other.tag == "Player" || other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
