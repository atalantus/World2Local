using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPosition : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private DataDisplay _dataDisplay;
    private Matrix _rotationMatrix;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rotationMatrix = new Matrix(Vector2.zero, Vector2.zero);
    }

    private void Start()
    {
        RotatePlayer(0);
        CalculateRotationMatrix();
        ToLocal();
    }

    public void RotatePlayer(float rotation)
    {
        rotation = rotation * 5;
        if (rotation >= 360) rotation = 0;
        _transform.localRotation = Quaternion.Euler(0, 0, rotation);
        _dataDisplay.UpdatePlayerRotation(rotation);

        CalculateRotationMatrix();
        ToLocal();
    }

    private void CalculateRotationMatrix()
    {
        var rotation = _transform.localRotation.eulerAngles;
        var rotationAngle = rotation.z;

        var sin = Mathf.Sin(rotationAngle * Mathf.Deg2Rad);
        var cos = Mathf.Cos(rotationAngle * Mathf.Deg2Rad);

        var iHead = new Vector2(cos, sin);
        var jHead = new Vector2(-sin, cos);

        _rotationMatrix.Vectors[0] = iHead;
        _rotationMatrix.Vectors[1] = jHead;

        _dataDisplay.UpdateMatrix(iHead, jHead);
    }

    private Vector2 ToLocal()
    {
        var worldDir = new Vector2(4, 3);
        var outputVector = _rotationMatrix * worldDir;
        _dataDisplay.UpdateOuputVector(outputVector);
        Debug.Log("Angle: " + Mathf.Atan2(outputVector.y, outputVector.x) * Mathf.Rad2Deg);
        return outputVector;
    }
}
