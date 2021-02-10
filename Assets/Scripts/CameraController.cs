﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraController : MonoBehaviour
{
    Camera mainCamera;
    PositionConstraint positionConstraint;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
        positionConstraint = GetComponent<PositionConstraint>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        positionConstraint.locked = false;
        Debug.Log("UNLOCK");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        positionConstraint.locked = true;
        Debug.Log("UNLOCK");
    }
}
