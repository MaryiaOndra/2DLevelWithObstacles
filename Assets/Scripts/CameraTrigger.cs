using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] PositionConstraint positionConstraint;

    Axis axis;

    private void Awake()
    {
        axis = positionConstraint.translationAxis;
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
