using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    void Start()
    {
    }

    void Update()
    {
        Vector2 positon = prefab.transform.position;
        this.transform.position = positon;
    }
}
