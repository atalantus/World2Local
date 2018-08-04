using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Matrix : ICloneable
{
    private List<Vector4> _vectors;
    public List<Vector4> Vectors
    {
        get { return _vectors; }
    }

    public Matrix(params Vector4[] vectors)
    {
        _vectors = vectors.ToList();
    }

    public static Matrix operator *(Matrix matrix, float scalar)
    {
        for (var i = 0; i < matrix.Vectors.Count; i++)
        {
            matrix.Vectors[i] *= scalar;
        }

        return matrix;
    }

    public static Vector4 operator *(Matrix matrix, Vector4 vector)
    {
        var newVector = new Vector4();
        var vectors = new List<Vector4>();

        for (var i = 0; i < matrix.Vectors.Count && i <= 3; i++)
        {
            var temp = matrix.Vectors[i];
            vectors.Add(temp * vector[i]);
        }

        foreach (var v in vectors)
        {
            newVector += v;
        }

        return newVector;
    }

    public static Matrix operator *(Matrix matrix01, Matrix matrix02)
    {
        var newMatrix = new Matrix();

        return newMatrix;
    }

    public object Clone()
    {
        return MemberwiseClone();
    }
}
