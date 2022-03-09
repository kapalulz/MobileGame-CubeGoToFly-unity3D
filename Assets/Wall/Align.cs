using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Align : MonoBehaviour
{
    [SerializeField] private bool right, left;

    void Start()
    {
        var position = transform.position;
        
        if (right)
            position.x = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        
        if (left)
            position.x = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;

        transform.position = position;
       
//        print(Screen.width);
    }
}
