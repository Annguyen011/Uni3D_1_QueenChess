using System;
using UnityEngine;

[Serializable]
public class Helper
{
    public static bool CheckBound(Vector2 vector2)
    {
        if (vector2.x >= 0 && vector2.y >= 0 && vector2.x <= 7 && vector2.y <= 7)
        {
            return true;
        }
        return false;
    }
}