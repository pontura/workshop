﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLoop : MonoBehaviour
{
    public float speed;

    void Update()
    {
        Vector3 rot = transform.localEulerAngles;
        rot.z += Time.deltaTime * speed;
        transform.localEulerAngles = rot;
    }
}
