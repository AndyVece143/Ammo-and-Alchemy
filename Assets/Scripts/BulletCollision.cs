using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public List<GameObject> bulletList;
    public List<GameObject> enemyBulletList;
    public List<GameObject> enemyList;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (bulletList.Count > 0 && enemyList.Count > 0) 
            { 
                for (int i = 0; i < bulletList.Count; i++) 
                { 
                    for (int k = 0; k < enemyList.Count; k ++)
                    {
                        EnemyCollision(enemyList[k], bulletList[i]);
                    }
                }
            }

            if (enemyBulletList.Count > 0 && player != null)
            {
                for (int i = 0; i < enemyBulletList.Count; i ++)
                {
                    PlayerCollision(enemyBulletList[i]);
                }
            }
        }
        catch { }
    }

    //This is a collision check for the player's bullets hitting the enemy
    //I am using the AABB method because I cannot figure out any other method lol
    void EnemyCollision(GameObject enemy, GameObject bullet)
    {
        if (enemy.transform.position.x < bullet.transform.position.x + bullet.GetComponent<Bullet>().width)
        {
            if (enemy.transform.position.x + enemy.GetComponent<EnemyScript>().width > bullet.transform.position.x)
            {
                if (enemy.transform.position.z < bullet.transform.position.z + bullet.GetComponent<Bullet>().width)
                {
                    if (enemy.transform.position.z + enemy.GetComponent<EnemyScript>().width > bullet.transform.position.z)
                    {
                        BulletDestroy(bullet);
                        if (player.GetComponent<PlayerMovement>().spellActive == "damage")
                        {
                            enemy.GetComponent<EnemyScript>().health -= 1.5f;
                        }
                        else
                        {
                            enemy.GetComponent<EnemyScript>().health -= 1;
                        }

                        if (enemy.GetComponent<EnemyScript>().health == 0)
                        {
                            enemyList.Remove(enemy);
                        }
                    }
                }
            }
        }
    }

    void PlayerCollision(GameObject enemyBullet)
    {
        if (player.transform.position.x < enemyBullet.transform.position.x + enemyBullet.GetComponent<EnemyBullet>().width)
        {
            if (player.transform.position.x + player.GetComponent<PlayerMovement>().width > enemyBullet.transform.position.x)
            {
                if (player.transform.position.z < enemyBullet.transform.position.z + enemyBullet.GetComponent<EnemyBullet>().width)
                {
                    if (player.transform.position.z + player.GetComponent<PlayerMovement>().width > enemyBullet.transform.position.z)
                    {
                        EnemyBulletDestroy(enemyBullet);

                        player.GetComponent<PlayerMovement>().health -= 1;
                    }
                }
            }
        }
    }

    void BulletDestroy(GameObject bullet)
    {
        Destroy(bullet);
        bulletList.Remove(bullet);
    }

    void EnemyBulletDestroy(GameObject enemyBullet)
    {
        Destroy(enemyBullet);
        enemyBulletList.Remove(enemyBullet);
    }
}
