using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Matrix : ICloneable
{
    public List<Vector4> Vectors { get; set; }

    public Matrix(params Vector4[] vectors)
    {
        Vectors = vectors.ToList();
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

    public object Clone()
    {
        return MemberwiseClone();
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder("|");

        foreach (var v in Vectors)
        {
            stringBuilder.Append(" " + v.ToString() + " |");
        }

        return stringBuilder.ToString();
    }
}
