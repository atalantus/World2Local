using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataDisplay : MonoBehaviour
{
    [SerializeField] private Text _playerRotationText;
    [SerializeField] private Text _playerRotationDir;
    [SerializeField] private Slider _playerRotationSlider;
    [SerializeField] private Text[] _matrixValues;

    public void UpdatePlayerRotation(float rotation)
    {
        _playerRotationText.text = "Rotation: " + rotation + "°";
        if (rotation <= 22.5) _playerRotationDir.text = "Right";
        else if (rotation <= 67.5) _playerRotationDir.text = "UpRight";
        else if (rotation <= 112.5) _playerRotationDir.text = "Up";
        else if (rotation <= 157.5) _playerRotationDir.text = "UpLeft";
        else if (rotation <= 202.5) _playerRotationDir.text = "Left";
        else if (rotation <= 247.5) _playerRotationDir.text = "DownLeft";
        else if (rotation <= 292.5) _playerRotationDir.text = "Down";
        else if (rotation <= 337.5) _playerRotationDir.text = "DownRight";
        else _playerRotationDir.text = "Right";
    }

    public void UpdateMatrix(Vector2 iHead, Vector2 jHead)
    {
        _matrixValues[0].text = iHead.x.ToString("0.00");
        _matrixValues[1].text = iHead.y.ToString("0.00");
        _matrixValues[2].text = jHead.x.ToString("0.00");
        _matrixValues[3].text = jHead.y.ToString("0.00");
    }

    public void OpenHelpVideo()
    {
        Application.OpenURL("https://youtu.be/kYB8IZa5AuE");
    }
}
