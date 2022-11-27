using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal.Profiling;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //Reference to the player
    public GameObject player;

    //Card prefab
    public GameObject card;

    public string[] spellNames = new string[] {"speed", "damage", "invisible"};

    //Value to check if the enemy is in range of the player
    public bool inRange;

    //Health variable
    public float health = 3.0f;

    public GameObject collisionChecker;

    
    private void Awake()
    {
        collisionChecker = GameObject.FindWithTag("Manager");
        player = GameObject.FindWithTag("Player");
    }
    

    // Start is called before the first frame update
    void Start()
    {
        collisionChecker.GetComponent<BulletCollision>().enemyList.Add(gameObject);
    }

    public float width = 1;

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            //Calculate the distance between the enemy and player
            //If in range, the bool is true;
            float distance = Vector3.Distance(player.transform.position, transform.position);

            // player invisibilty check
            if (player.GetComponent<PlayerMovement>().spellActive == "invisible")
            {
                inRange = false;
            }
            else if (distance <= 20.0f)
            {
                inRange = true;
            }
            else
            {
                inRange = false;
            }

            //Get the player position and rotate toward them
            Vector3 playerPosition = player.transform.position - transform.position;

            transform.rotation = Quaternion.LookRotation(playerPosition, Vector3.up);
        }


        //Health check
        if (health <= 0)
        {
            // spawn a card
            GameObject s = Instantiate(card, gameObject.transform.position, gameObject.transform.rotation);
            int x = (Random.Range(0, 3));
            Debug.Log(x);
            s.GetComponent<Card>().cardType = spellNames[x] ;

            Destroy(gameObject);
        }
    }
}
