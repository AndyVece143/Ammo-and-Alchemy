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

    // spell names and materials
    public string[] spellNames = new string[] {"speed", "damage", "invisible"};
    public Color[] spellMats = new Color[] {Color.yellow, Color.red, Color.white};

    //Value to check if the enemy is in range of the player
    public bool inRange;

    //Health variable
    public float health = 3.0f;

    public GameObject collisionChecker;

    
    private void Awake()
    {
        // collisionChecker = GameObject.FindWithTag("Manager");
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

            if (inRange)
            {
                //Get the player position and rotate toward them
                Vector3 playerPosition = player.transform.position - transform.position;
                transform.rotation = Quaternion.LookRotation(playerPosition, Vector3.up);
            }
        }


        //Health check
        if (health <= 0)
        {
            // spawn a card
            GameObject s = Instantiate(card, gameObject.transform.position, gameObject.transform.rotation);

            // random type of card
            int x = (Random.Range(0, 3));

            // assign name
            s.GetComponent<Card>().cardType = spellNames[x];

            // assign material
            // help from https://answers.unity.com/questions/1211937/change-color-in-c-with-rgb-values.html
            s.GetComponent<Renderer>().material.color = spellMats[x];

            Destroy(gameObject);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        // if Player is touching card
        if (other.tag == "Bullet")
        {
            health--;
            Destroy(other.gameObject);
        }
    }
}
