using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    //The enemy will shoot on cycles
    public float countdown;
    public float maxCountdown;

    //Reference to the main enemy and the bullet prefab
    public GameObject bullet;
    public GameObject enemy;
    

    // Start is called before the first frame update
    void Start()
    {
        maxCountdown = 2;
        countdown = maxCountdown;
    }

    // Update is called once per frame
    void Update()
    {
        //If the enemy is in range, start the cycle of shooting
        if (enemy.GetComponent<EnemyScript>().inRange == true)
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0.0f)
            {
                Instantiate(bullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), new Quaternion(enemy.transform.rotation.x, enemy.transform.rotation.y, enemy.transform.rotation.z, enemy.transform.rotation.w));
                countdown = maxCountdown;
            }
        }

    }
}
