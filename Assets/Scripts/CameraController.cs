using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private float _zoomSpeed;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

	void Update ()
	{
	    _camera.orthographicSize = _camera.orthographicSize + Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * -_zoomSpeed;

	    if (_camera.orthographicSize < 1f) _camera.orthographicSize = 1f;
        else if (_camera.orthographicSize > 25f) _camera.orthographicSize = 15f;
	}
}
