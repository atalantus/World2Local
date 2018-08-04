using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPosition : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private DataDisplay _dataDisplay;
    private Vector3[] _rotationMatrix;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rotationMatrix = new Vector3[2];
    }

    private void Start()
    {
        RotatePlayer(18);
        CalculateRotationMatrix();
    }

    private void Update()
    {
        CalculateRotationMatrix();
        ToLocal();
        DrawDirectionVector();
    }

    public void RotatePlayer(float rotation)
    {
        rotation = rotation * 5;
        if (rotation >= 360) rotation = 0;
        _transform.localRotation = Quaternion.Euler(0, 0, rotation);
        _dataDisplay.UpdatePlayerRotation(rotation);
    }

    private void CalculateRotationMatrix()
    {
        var rotation = _transform.localRotation.eulerAngles;
        var rotationAngle = rotation.z;
   
        var sin = Mathf.Sin(rotationAngle * Mathf.PI / 180);
        var cos = Mathf.Cos(rotationAngle * Mathf.PI / 180);

        var iHead = new Vector2(sin, -cos);
        var jHead = new Vector2(cos, sin);

        _rotationMatrix[0] = iHead;
        _rotationMatrix[1] = jHead;

        _dataDisplay.UpdateMatrix(iHead, jHead);
    }

    private Vector3 ToLocal()
    {
        return new Vector3();
    }

    private void DrawDirectionVector()
    {

    }
}
