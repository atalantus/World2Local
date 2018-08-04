using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreRotation : MonoBehaviour
{

    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        // TODO: CHANGE ROTATION
    }
}
