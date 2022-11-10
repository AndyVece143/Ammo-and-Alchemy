using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateHand : MonoBehaviour
{
    GameObject arrrow;
    bool rotateOn;

    // Start is called before the first frame update
    void Start()
    {
        rotateOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateOn)
        {
            RotateToMouse();
        }
    }

    void RotateToMouse()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint((Vector3)Mouse.current.position.ReadValue());

        float angle = Mathf.Atan2(mouseWorldPos.x, mouseWorldPos.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, -(angle + 90));
    }

    public void onClickBool()
    {
        if(rotateOn)
        {
            rotateOn = false;
        }
        else
        {
            rotateOn = true;
        }
    }
}
