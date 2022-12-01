using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public List<GameObject> enemyList;
    bool isOpen;
    bool move;
    public Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        move = false;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i] == null) 
            { 
                enemyList.RemoveAt(i);  
            }
        }

        if (enemyList.Count == 0 && move == false)
        {
            isOpen = true;
            float step = 3 * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, target, step);
            
        }
    }
}
