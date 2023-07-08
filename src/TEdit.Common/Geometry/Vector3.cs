﻿/* 
Copyright (c) 2011 BinaryConstruct
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
 */

using System;

namespace TEdit.Geometry;

[Serializable]
public struct Vector3
{

    public float X;
    public float Y;
    public float Z;

    public Vector3(float x, float y, float z)
        : this()
    {
        X = x;
        Y = y;
        Z = z;
    }

    public override string ToString()
    {
        return $"({X:0.000},{Y:0.000},{Z:0.000})";
    }

    public static bool Parse(string text, out Vector3 vector)
    {
        vector = new Vector3();
        if (string.IsNullOrWhiteSpace(text)) return false;

        var split = text.Split(',', 'x');
        if (split.Length != 3) return false;
        float x, y, z;
        if (float.TryParse(split[0], out x) ||
            float.TryParse(split[1], out y) ||
            float.TryParse(split[2], out z))
            return false;

        vector = new Vector3(x, y, z);
        return true;
    }

    public static Vector3 operator -(Vector3 a, Vector3 b)
    {
        return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Vector3 operator +(Vector3 a, Vector3 b)
    {
        return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Vector3 operator *(Vector3 a, float scale)
    {
        return new Vector3(a.X * scale, a.Y * scale, a.Z * scale);
    }

    public static Vector3 operator /(Vector3 a, float scale)
    {
        if (scale == 0) { throw new DivideByZeroException(); }
        return new Vector3(a.X / scale, a.Y / scale, a.Z / scale);
    }

    public bool Equals(Vector3 other)
    {
        return other.X.Equals(X) && other.Y.Equals(Y) && other.Z.Equals(Z);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (obj.GetType() != typeof(Vector3)) return false;
        return Equals((Vector3)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int result = X.GetHashCode();
            result = result * 397 ^ Y.GetHashCode();
            result = result * 397 ^ Z.GetHashCode();
            return result;
        }
    }

    public static bool operator ==(Vector3 left, Vector3 right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Vector3 left, Vector3 right)
    {
        return !left.Equals(right);
    }
}
