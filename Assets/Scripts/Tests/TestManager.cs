using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Tests;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    private List<ITest> _tests;

    private void Awake()
    {
        Debug.LogWarning("Test Manager is enabled!");
        _tests = new List<ITest>() { new MatrixTest() };

        foreach (var test in _tests)
        {
            test.Execute();
        }

        Debug.LogWarning("All Tests were executed successfully!");
    }
}
