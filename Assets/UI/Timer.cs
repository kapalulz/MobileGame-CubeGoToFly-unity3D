using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float time;

    private void Awake() => time = 1f;
    void Update() => time += Time.deltaTime;
}
